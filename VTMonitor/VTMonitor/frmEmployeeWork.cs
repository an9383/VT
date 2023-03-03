using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonsPanelControl;
using SmartMES.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMonitor.Common;
using VTMonitor.Models;

namespace VTMonitor
{
    public partial class frmEmployeeWork : DevExpress.XtraEditors.XtraForm
    {
        clsCode code = new clsCode();
        //clsCamstarCommon camstarCommon = new clsCamstarCommon();

        string containerName = "";

        DateTime noStartDate;

        public frmEmployeeWork()
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

            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width - Size.Width - 40, 4);

            try
            {
                factorySearchLookUpEdit.Properties.DataSource = code.GetFilterTags();
                factorySearchLookUpEdit.Properties.DisplayMember = "명칭";
                factorySearchLookUpEdit.Properties.ValueMember = "코드";

                DataView reasonView = code.GetReleaseReason();

                foreach (DataRowView item in reasonView)
                {
                    reasonComobBoxEdit.Properties.Items.Add(item[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEmployeeWork_Load(object sender, EventArgs e)
        {
            txtContainerName.Focus();

        }

        private void txtContainerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (txtContainerName.Text == "")
                {
                    timer1.Enabled = false;
                    txtStep.Text = "";
                    txtWorkTime.Text = "";
                    txtNonWorkTime.Text = "";

                    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = false;
                    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = false;

                    containerName = "";
                }
                else
                {
                    containerName = txtContainerName.Text;
                    DisplayWorkData();
                }
            }
        }

        private string ConvertBySecond(int sec)
        {
            int hours = sec / 3600;
            int minute = sec % 3600 / 60;

            return string.Format("{0} : {1}", hours.ToString("00"), minute.ToString("00"));
        }

        private void InitWorkControl()
        {
            txtContainerName.Text = "";
            txtStep.Text = "";
            txtWorkTime.Text = "";
            txtNonWorkTime.Text = "";
            timer1.Enabled = false;

            //((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = false;
            //((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = false;

            txtContainerName.Focus();
        }

        private void DisplayWorkData()
        {
            timer1.Enabled = false;
            DataRowView item = null;
            try
            {
                item = code.GetNowWorkTimeByContainer(containerName);
                layoutErrorItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            catch (Exception ex)
            {
                layoutErrorItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ((DevExpress.Utils.ToolTipTitleItem)errSvgImage.SuperTip.Items[0]).Text = ex.GetType().ToString();
                ((DevExpress.Utils.ToolTipItem)errSvgImage.SuperTip.Items[1]).Text = ex.Message;

                txtContainerName.Focus();
                timer1.Enabled = true;

                return;
            }

            if (item == null)
            {
                InitWorkControl();

                ((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = true;
                ((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = true;
            }
            else
            {
                txtStep.Text = item["StepName"].ToString();

                ((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = true;
                ((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = true;

                //if (txtStep.Text.Replace(" ", "") == "IO공정" || txtStep.Text.Replace(" ", "") == "DD공정")
                //{
                //    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = true;
                //    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = true;
                //}
                //else
                //{
                //    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[0]).Visible = false;
                //    ((GroupBoxButton)lcgContainer.CustomHeaderButtons[1]).Visible = false;
                //}

                txtWorkTime.Text = ConvertBySecond(Convert.ToInt32(item["WorkSecond"]));
                txtNonWorkTime.Text = ConvertBySecond(Convert.ToInt32(item["NonWorkSecond"]));

                if (item["Status"].ToString() == "2")
                {   //비가동
                    Root.AppearanceGroup.BackColor = Color.Red;
                }
                else if (item["Status"].ToString() == "1")
                {   //가동
                    Root.AppearanceGroup.BackColor = Color.DodgerBlue;
                }
                else
                {   // 완료
                    Root.AppearanceGroup.BackColor = Color.FromArgb(0, 0, 0, 0);
                }

                txtContainerName.Focus();
                timer1.Enabled = true;
            }
        }

        private void frmEmployeeWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void factorySearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            employeeSearchLookUpEdit.Properties.DataSource = code.GetEmployeeByFilter((factorySearchLookUpEdit.EditValue ?? "").ToString());
            employeeSearchLookUpEdit.Properties.DisplayMember = "명칭";
            employeeSearchLookUpEdit.Properties.ValueMember = "코드";
        }

        private void employeeSearchLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            reasonComobBoxEdit.EditValue = null;

            if ((employeeSearchLookUpEdit.EditValue ?? "").ToString() == "")
            {
                timer2.Enabled = false;
            }
            else
            {
                timer2.Enabled = true;
            }

            DisplayNoData(false);
        }
        //무가동 시작
        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((employeeSearchLookUpEdit.EditValue ?? "").ToString() == "" || (employeeSearchLookUpEdit.EditValue ?? "").ToString() == "--작업자--")
            {
                this.Text = "!알림 : 작업자를 선택하세요.";
                return;
            }

            //int idx = code.GetRoleIndexByEmployee((employeeSearchLookUpEdit.EditValue ?? "").ToString(), "Default Mfg");

            //if (idx < 0)
            //{
            //    this.Text = "!알림 : 작업자의 Role을 확인할 수 없습니다." + "(" + (employeeSearchLookUpEdit.EditValue ?? "").ToString() + " Default Mfg)";
            //    return;
            //}

            this.Text = "";

            //string msg = camstarCommon.RoleDelete((employeeSearchLookUpEdit.EditValue ?? "").ToString(), idx);
            //if (msg == "")
            //{
            //    code.GetNoOpeartionStart("0", (employeeSearchLookUpEdit.EditValue ?? "").ToString(), "");
            //    this.Text = "!알림 : 무가동 시작.";
            //}
            //else
            //{
            //    this.Text = msg;
            //}

            code.GetNoOpeartionStart("0", (employeeSearchLookUpEdit.EditValue ?? "").ToString(), "");
            this.Text = "!알림 : 무가동 시작.";

            DisplayNoData(false);
        }
        // 무가동 종료
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if ((employeeSearchLookUpEdit.EditValue ?? "").ToString() == "" || (employeeSearchLookUpEdit.EditValue ?? "").ToString() == "--작업자--")
            {
                this.Text = "!알림 : 작업자를 선택하세요.";
                return;
            }
            if ((reasonComobBoxEdit.EditValue ?? "").ToString() == "" || (reasonComobBoxEdit.EditValue ?? "").ToString() == "--무가동사유--")
            {
                this.Text = "!알림 : 무가동 사유를 선택하세요.";
                return;
            }

            this.Text = "";

            //string msg = camstarCommon.RoleAdd((employeeSearchLookUpEdit.EditValue ?? "").ToString(), "Default Mfg");
            //if (msg == "")
            //{
            //    code.GetNoOpeartionEnd("0", (employeeSearchLookUpEdit.EditValue ?? "").ToString(), (reasonComobBoxEdit.EditValue ?? "").ToString());
            //    this.Text = "!알림 : 가동 시작.";
            //    reasonComobBoxEdit.EditValue = null;
            //}
            //else
            //{
            //    this.Text = msg;
            //}

            code.GetNoOpeartionEnd("0", (employeeSearchLookUpEdit.EditValue ?? "").ToString(), (reasonComobBoxEdit.EditValue ?? "").ToString());
            this.Text = "!알림 : 가동 시작.";
            reasonComobBoxEdit.EditValue = null;

            DisplayNoData(false);
        }

        private void DisplayNoData(bool isTimer = false)
        {
            DataRowView item = null;
            try
            {
                item = code.GetNoOpeartionTimeByEmployee((employeeSearchLookUpEdit.EditValue ?? "").ToString());
                layoutErrorItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            catch (Exception ex)
            {
                layoutErrorItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ((DevExpress.Utils.ToolTipTitleItem)errSvgImage2.SuperTip.Items[0]).Text = ex.GetType().ToString();
                ((DevExpress.Utils.ToolTipItem)errSvgImage2.SuperTip.Items[1]).Text = ex.Message;
                return;
            }

            if (item == null)
            {
                btnStart.Enabled = true;
                btnEnd.Enabled = false;
            }
            else
            {
                if (item["Gubun"].ToString() == "0")
                {   // 무가동중
                    noStartDate = Convert.ToDateTime(item["StartDate"]).AddSeconds(-1 * Convert.ToInt32(item["NoTime"]));
                    TimeSpan dateDiff = DateTime.Now - noStartDate;
                    txtNoTime.Text = ConvertBySecond(Convert.ToInt32(dateDiff.TotalSeconds));
                    btnStart.Enabled = false;
                    btnEnd.Enabled = true;
                    Root2.AppearanceGroup.BackColor = Color.Red;
                }
                else
                {   // 가동중
                    txtNoTime.Text = ConvertBySecond(Convert.ToInt32(item["NoTime"]));
                    btnStart.Enabled = true;
                    btnEnd.Enabled = false;
                    Root2.AppearanceGroup.BackColor = Color.DodgerBlue;
                }
            }

            if (!isTimer)
            {
                txtContainerName.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayWorkData();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DisplayNoData(true);
        }
        //USB 퀵가이드 저장
        private void lcgContainer_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {

            if (((DevExpress.XtraEditors.ButtonPanel.BaseButton)e.Button).Tag.ToString() == "저장")
            {
                if (txtContainerName.Text == "") return;

                DataRowView item = null;
                try
                {
                    item = code.GetQuickGuideByContainer(txtContainerName.Text);
                    layoutErrorItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                catch (Exception ex)
                {
                    layoutErrorItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    ((DevExpress.Utils.ToolTipTitleItem)errSvgImage.SuperTip.Items[0]).Text = ex.GetType().ToString();
                    ((DevExpress.Utils.ToolTipItem)errSvgImage.SuperTip.Items[1]).Text = ex.Message;

                    return;
                }

                if (item == null)
                {
                    return;
                }

                if (item["SerialNo"].ToString() == "")
                {
                    this.Text = "!알림 : 제조번호를 찾을수 없습니다.";
                    return;
                }

                if (!Directory.Exists(Properties.Settings.Default.DownPath))
                {
                    this.Text = string.Format("!알림 : 디렉토리를 찾을수 없습니다.({0})", Properties.Settings.Default.DownPath);
                    return;
                }

                string fileLocation = Properties.Settings.Default.DownPath + @"\" + item["SerialNo"].ToString() + ".txt";

                if (File.Exists(fileLocation))
                {
                    File.Delete(fileLocation);
                }

                using (StreamWriter sw = File.CreateText(fileLocation))
                {
                    sw.WriteLine("┌───────────┬───────────────────────────────────────────────────────┐");
                    sw.WriteLine("  Ez3D Plus Sta		│ " + item["Ez3DPlusSta"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Ez3D Plus Prof	│ " + item["Ez3DPlusProf"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Ez3D Plus Pre		│ " + item["Ez3DPlusPre"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Ez3D i		│ " + item["Ez3Di"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Model			│ " + item["Model"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Modality		│ " + item["Modality"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  CT Sensor Type	│ " + item["CTSensorType"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Pano Sensor Type	│ " + item["PanoSensorType"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Ceph Sensor Type	│ " + item["CephSensorType"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Frame Grabber Type	│ " + item["FrameGrabberType"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Additional Options 1	│ " + item["AdditionalOptions1"].ToString());
                    sw.WriteLine("├───────────┼───────────────────────────────────────────────────────┤");
                    sw.WriteLine("  Additional Options 2	│ " + item["AdditionalOptions2"].ToString());
                    sw.WriteLine("└───────────┴───────────────────────────────────────────────────────┘");
                }

                this.Text = string.Format("!알림 : 디렉토리({0})에 {1} 파일을 저장했습니다.", Properties.Settings.Default.DownPath, item["SerialNo"].ToString() + ".txt");

            }
            else if (((DevExpress.XtraEditors.ButtonPanel.BaseButton)e.Button).Tag.ToString() == "설정")
            {
                if (fbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.DownPath = fbDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }

        }

    }
}