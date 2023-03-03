using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VT_ESigManager.Common;
using VT_ESigManager.Models;

namespace VT_ESigManager.View
{
    public partial class frmChangeUser : DevExpress.XtraEditors.XtraForm
    {
        private string InitFile = Application.StartupPath + @"\login.ini";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        clsCode code = new clsCode();

        DataView roleDv;

        bool isFirst = true;
        string factoryId = "";
        string employeeId = "";

        public frmChangeUser()
        {
            InitializeComponent();

            try
            {
                DataView dvFactory = code.GetFilterTags();

                factoryLookUpEdit.Properties.DataSource = dvFactory;
                factoryLookUpEdit.Properties.DisplayMember = "명칭";
                factoryLookUpEdit.Properties.ValueMember = "코드";


                if (System.IO.File.Exists(InitFile))
                {
                    factoryId = IniReadValue("LOGIN", "FactoryId").Trim();
                    employeeId = IniReadValue("LOGIN", "EmployeeId").Trim();
                }

                factoryLookUpEdit.Properties.ForceInitialize();

                if (factoryId == "")
                {
                    foreach (DataRowView item in dvFactory)
                    {
                        if (item["명칭"].ToString() == "시스템사업부")
                        {
                            factoryLookUpEdit.EditValue = item["코드"];
                            break;
                        }
                    }
                }
                else
                {
                    factoryLookUpEdit.EditValue = factoryId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void factoryLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            roleDv = code.GetEmployeeByEsigRole((factoryLookUpEdit.EditValue ?? "").ToString());

            employeeLookUpEdit.Properties.DataSource = roleDv;
            employeeLookUpEdit.Properties.DisplayMember = "명칭";
            employeeLookUpEdit.Properties.ValueMember = "EmployeeId";

            if (isFirst)
            {
                isFirst = false;
                employeeLookUpEdit.Properties.ForceInitialize();
                employeeLookUpEdit.EditValue = employeeId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((factoryLookUpEdit.EditValue ?? "").ToString() == "")
            {
                txtMsg.Text = "! 사업부를 선택하세요.";
                return;
            }
            if ((employeeLookUpEdit.EditValue ?? "").ToString() == "")
            {
                txtMsg.Text = "! 사용자를 선택하세요.";
                return;
            }

            roleDv.RowFilter = string.Format("EmployeeId = '{0}'", employeeLookUpEdit.EditValue.ToString());

            if (roleDv.Count != 1)
            {
                txtMsg.Text = "! 사용자를 찾을수 없습니다.";
                return;
            }

            WrGlobal.FactoryId = factoryLookUpEdit.EditValue.ToString();
            WrGlobal.FactoryName = factoryLookUpEdit.Text;
            WrGlobal.EmployeeId = employeeLookUpEdit.EditValue.ToString();
            WrGlobal.EmployeeName = employeeLookUpEdit.Text;
            WrGlobal.RoleName = roleDv[0]["ESigRoleGroupName"].ToString();

            WritePrivateProfileString("LOGIN", "FactoryId", (factoryLookUpEdit.EditValue ?? "").ToString(), InitFile);
            WritePrivateProfileString("LOGIN", "EmployeeId", (employeeLookUpEdit.EditValue ?? "").ToString(), InitFile);

            this.DialogResult = DialogResult.OK;
        }

        private string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, InitFile);
            return temp.ToString();
        }
    }
}