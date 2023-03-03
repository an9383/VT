﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraWaitForm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMES3_RE.Common;
using VTMES3_RE.Models;

namespace VTMES3_RE.View.Approval
{
    public partial class frmInno_ESigManager : DevExpress.XtraEditors.XtraForm
    {
        clsWork camWork = new clsWork();
        string query = "";

        XtraReport report = null;

        public frmInno_ESigManager()
        {
            InitializeComponent();

            barEditStartDate.EditValue = DateTime.Today.AddDays(-1);
            barEditEndDate.EditValue = DateTime.Today;
        }

        private void frmESigManager_Load(object sender, EventArgs e)
        {
            searchStepLookUpEdit.Properties.DataSource = camWork.GetWorkflowStepByFilter("이노딕스");
            searchStepLookUpEdit.Properties.DisplayMember = "구분";
            searchStepLookUpEdit.Properties.ValueMember = "공정";
            searchStepLookUpEdit.Properties.ForceInitialize();
            searchStepLookUpEdit.EditValue = "전체";

            if (WrGlobal.Camstar_RoleName == "검토자")
            {
                cmdCheck.Visible = true;
                searchApprovaYnComboBoxEdit.EditValue = "검토대기";
            }
            else if (WrGlobal.Camstar_RoleName == "승인자")
            {
                cmdApprove.Visible = true;
                searchApprovaYnComboBoxEdit.EditValue = "검토완료";
            }

            DisplayEsigHistory();
        }

        private void DisplayEsigHistory()
        {
            query = string.Format("exec CAMDBsh.VM_Proc_Inno_GetESigHistory '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}', N'{2}', N'{3}', N'{4}'",
                (DateTime)barEditStartDate.EditValue, (DateTime)barEditEndDate.EditValue, "이노딕스", (searchStepLookUpEdit.EditValue ?? "").ToString(), searchApprovaYnComboBoxEdit.Text);

            gcESigHistory.DataSource = camWork.GetDataViewByQuery("EsigHistory", query);
        }

        //엑셀출력
        private void cmdExcel_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Worksheets|*.Xls";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XlsExportOptionsEx o = new XlsExportOptionsEx { ExportType = DevExpress.Export.ExportType.WYSIWYG };

                gvESigHistory.ExportToXls(sfd.FileName, o);
                System.Diagnostics.Process.Start(sfd.FileName);
            }//end fnction
        }
        //닫기
        private void cmdClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }
        //검토 처리 버튼클릭
        private void cmdCheck_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (gvESigHistory.SelectedRowsCount == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] idxs = gvESigHistory.GetSelectedRows();
            int cnt = 0;
            List<string> queryList = new List<string>();

            foreach (int idx in idxs)
            {
                if (!gvESigHistory.IsDataRow(idx)) continue;

                if ((gvESigHistory.GetRowCellValue(idx, "CheckUser") ?? "").ToString() == "")
                {   // 미검토
                    if ((gvESigHistory.GetRowCellValue(idx, "ApporveUser") ?? "").ToString() == "")
                    {   //미승인 : Insert
                        query = string.Format("INSERT INTO IFSYS.dbo.VM_ESigHistory(StepEntryTxnId, FactoryId, ContainerId, WorkflowStepId, CheckUser, CheckDate, CheckComment, CheckUserName) "
                                            + "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), '{5}', '{6}')"
                                            , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "WorkflowStepId").ToString()
                                            , WrGlobal.EmployeeId
                                            , gvESigHistory.GetRowCellValue(idx, "CheckComment").ToString()
                                            , WrGlobal.LoginID);

                        queryList.Add(query);

                        cnt++;
                    }
                    else
                    {   // 승인 : Update x -> 에러
                        MessageBox.Show("승인완료된 항목이 선택되었습니다.\n처리에 실패했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("검토완료된 항목이 선택되었습니다.\n처리에 실패했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cnt > 0)
            {
                int success = camWork.ExecuteQryList(queryList);

                if (cnt == success)
                {
                    MessageBox.Show(string.Format("{0}건 검토 처리되었습니다.", success), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("{0}건 검토 처리되었습니다. ({1}건 처리 실패)", success, cnt - success), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success > 0)
                {
                    DisplayEsigHistory();
                }
            }

        }
        //승인 처리 버튼클릭
        private void cmdApprove_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            if (gvESigHistory.SelectedRowsCount == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] idxs = gvESigHistory.GetSelectedRows();
            int cnt = 0;
            List<string> queryList = new List<string>();

            foreach (int idx in idxs)
            {
                if (!gvESigHistory.IsDataRow(idx)) continue;

                if ((gvESigHistory.GetRowCellValue(idx, "ApproveUser") ?? "").ToString() == "")
                {   // 미승인
                    if ((gvESigHistory.GetRowCellValue(idx, "CheckUser") ?? "").ToString() == "")
                    {   //미검토 : Insert x -> 에러
                        MessageBox.Show("검토완료 처리되지 않은 항목이 선택되었습니다.\n처리에 실패했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {   // 검토 : Update
                        query = string.Format("Update IFSYS.dbo.VM_ESigHistory "
                                                + "Set ApproveUser = '{3}', "
                                                + "ApproveDate = GETDATE(), "
                                                + "ApproveComment = '{4}', "
                                                + "ApproveUserName = '{5}' "
                                        + "Where StepEntryTxnId = '{0}' and FactoryId = '{1}' and ContainerId = '{2}'"
                                        , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                                        , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                                        , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                                        , WrGlobal.EmployeeId
                                        , gvESigHistory.GetRowCellValue(idx, "ApproveComment").ToString()
                                        , WrGlobal.LoginID);

                        queryList.Add(query);

                        cnt++;
                    }
                }
                else
                {
                    MessageBox.Show("승인완료된 항목이 선택되었습니다.\n처리에 실패했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cnt > 0)
            {
                int success = camWork.ExecuteQryList(queryList);

                if (cnt == success)
                {
                    MessageBox.Show(string.Format("{0}건 승인 처리되었습니다.", success), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("{0}건 승인 처리되었습니다. ({1}건 처리 실패)", success, cnt - success), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (success > 0)
                {
                    DisplayEsigHistory();
                }
            }
        }

        private void gvESigHistory_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView gridView = sender as GridView;;

            if (e.RowHandle < 0) return;

            if ((gridView.GetRowCellValue(e.RowHandle, "CheckUser") ?? "").ToString() != "" && (gridView.GetRowCellValue(e.RowHandle, "ApproveUser") ?? "").ToString() != "")
            {
                e.Appearance.BackColor = Color.Orange;
                e.HighPriority = true;
            }
            else if ((gridView.GetRowCellValue(e.RowHandle, "CheckUser") ?? "").ToString() != "" || (gridView.GetRowCellValue(e.RowHandle, "ApproveUser") ?? "").ToString() != "")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void gvESigHistory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (!gvESigHistory.IsDataRow(e.FocusedRowHandle)) return;

            //SplashScreenManager.ShowForm(this, typeof(frmWait), true, true, false);

            DataRowView drv = (DataRowView)gvESigHistory.GetRow(e.FocusedRowHandle);

            //if (drv["WorkflowStepName"].ToString().IndexOf("출하검사") < 0)
            //{
 
            //}
            //else
            //{
            //    report = camWork.GetSelectedReport("Inno_OQC_" + drv["ModelName"].ToString());

            //    if (report == null)
            //    {
            //        SplashScreenManager.CloseForm(false);
            //        MessageBox.Show("해당 모델의 성적서가 등록되지 않았습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    report.Parameters["AttributeValue"].Value = drv["ModelName"].ToString();
            //    report.Parameters["ContainerId"].Value = drv["ContainerId"].ToString();
            //    report.Parameters["Gubun"].Value = drv["Gubun"].ToString();
            //    report.Parameters["StepEntryTxnId"].Value = drv["StepEntryTxnId"].ToString();
            //}

            //foreach (DevExpress.XtraReports.Parameters.Parameter param in report.Parameters)
            //{
            //    param.Visible = false;
            //}

            //report.CreateDocument();
            //reportViewer.DocumentSource = report;

            //SplashScreenManager.CloseForm(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayEsigHistory();
        }
    }
}