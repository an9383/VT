using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
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
using VT_ESigManager.Common;
using VT_ESigManager.Models;

namespace VT_ESigManager.View
{
    public partial class frmInno_ESigManager : DevExpress.XtraEditors.XtraForm
    {
        clsCode code = new clsCode();
        string query = "";

        public frmInno_ESigManager()
        {

            InitializeComponent();

            if (WrGlobal.SQL_SERVER == "10.10.50.61")
            {
                this.Text = this.Text + "(운영)";
            }
            else
            {
                this.Text = this.Text + "(개발)";
            }

            barEditStartDate.EditValue = DateTime.Today.AddDays(-1);
            barEditEndDate.EditValue = DateTime.Today;
        }

        private void frmESigManager_Load(object sender, EventArgs e)
        {

            string[] titles = this.Text.Split(new char[] { '_' });
            this.Text = string.Format("{0}_({1}, {2})", titles[0], WrGlobal.FactoryName, WrGlobal.EmployeeName);

            DataView workDv = code.GetWorkflowStepByFilter(WrGlobal.FactoryName);

            searchStepComboBoxEdit.Properties.Items.Clear();

            searchStepComboBoxEdit.Properties.Items.Add("전체");

            foreach (DataRowView item in workDv)
            {
                searchStepComboBoxEdit.Properties.Items.Add(item["ItemCode"]);
            }
            searchStepComboBoxEdit.EditValue = "전체";


            if (WrGlobal.RoleName == "검토자")
            {
                cmdCheck.Visible = true;
                searchApprovaYnComboBoxEdit.EditValue = "검토대기";
            }
            else if (WrGlobal.RoleName == "승인자")
            {
                cmdApprove.Visible = true;
                searchApprovaYnComboBoxEdit.EditValue = "검토완료";
            }

            DisplayEsigHistory();
        }

        private void DisplayEsigHistory()
        {
            query = string.Format("exec CAMDBsh.VM_Proc_Inno_GetESigHistory '{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}', N'{2}', N'{3}', N'{4}'",
                (DateTime)barEditStartDate.EditValue, (DateTime)barEditEndDate.EditValue, WrGlobal.FactoryName, searchStepComboBoxEdit.Text, searchApprovaYnComboBoxEdit.Text);

            gcESigHistory.DataSource = code.GetDataViewByQuery("EsigHistory", query);
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
                        query = string.Format("INSERT INTO IFSYS.dbo.VM_ESigHistory(StepEntryTxnId, FactoryId, ContainerId, WorkflowStepId, CheckUser, CheckDate, CheckComment) "
                                            + "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), '{5}')"
                                            , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                                            , gvESigHistory.GetRowCellValue(idx, "WorkflowStepId").ToString()
                                            , WrGlobal.EmployeeId
                                            , gvESigHistory.GetRowCellValue(idx, "CheckComment").ToString());

                        queryList.Add(query);

                        cnt++;
                    }
                    else
                    {   // 승인 : Update x -> 에러
                        //query = string.Format("Update IFSYS.dbo.VM_ESigHistory "
                        //                        + "Set CheckUser = '{3}', CheckDate = GETDATE(), CheckComment = '{4}' "
                        //                + "Where StepEntryTxnId = '{0}' and FactoryId = '{1}' and ContainerId = '{2}'"
                        //                , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                        //                , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                        //                , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                        //                , WrGlobal.EmployeeId
                        //                , gvESigHistory.GetRowCellValue(idx, "CheckComment").ToString());

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
                int success = code.ExecuteQryList(queryList);

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
                        //query = string.Format("INSERT INTO IFSYS.dbo.VM_ESigHistory(StepEntryTxnId, FactoryId, ContainerId, WorkflowStepId, ApproveUser, ApproveDate, ApproveComment) "
                        //                    + "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', GETDATE(), '{5}')"
                        //                    , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                        //                    , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                        //                    , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                        //                    , gvESigHistory.GetRowCellValue(idx, "WorkflowStepId").ToString()
                        //                    , WrGlobal.EmployeeId
                        //                    , gvESigHistory.GetRowCellValue(idx, "ApproveComment").ToString());

                        MessageBox.Show("검토완료 처리되지 않은 항목이 선택되었습니다.\n처리에 실패했습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {   // 검토 : Update
                        query = string.Format("Update IFSYS.dbo.VM_ESigHistory "
                                                + "Set ApproveUser = '{3}', ApproveDate = GETDATE(), ApproveComment = '{4}' "
                                        + "Where StepEntryTxnId = '{0}' and FactoryId = '{1}' and ContainerId = '{2}'"
                                        , gvESigHistory.GetRowCellValue(idx, "StepEntryTxnId").ToString()
                                        , gvESigHistory.GetRowCellValue(idx, "FactoryId").ToString()
                                        , gvESigHistory.GetRowCellValue(idx, "ContainerId").ToString()
                                        , WrGlobal.EmployeeId
                                        , gvESigHistory.GetRowCellValue(idx, "ApproveComment").ToString());

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
                int success = code.ExecuteQryList(queryList);

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

            DataRowView drv = (DataRowView)gvESigHistory.GetRow(e.FocusedRowHandle);

            string reportUrl = "";

            reportUrl = String.Format(@"{0}/ReportServer/Pages/ReportViewer.aspx?/Inno/ReportViewer/OQC_{1}&rc:showbackbutton=true&Model={1}&Gubun={2}&ContainerId={3}&StepEntryTxnId={4}",
                            WrGlobal.reportRootUrl, drv["ModelName"].ToString() == "" ? "VEX-P300" : drv["ModelName"].ToString(), drv["Gubun"].ToString(), drv["ContainerId"].ToString(), drv["StepEntryTxnId"].ToString());

            webBrowser1.Url = new Uri(reportUrl);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayEsigHistory();
        }
    }
}