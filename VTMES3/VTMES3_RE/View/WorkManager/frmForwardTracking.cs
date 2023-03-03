using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMES3_RE.Models;

namespace VTMES3_RE.View.WorkManager
{
    public partial class frmForwardTracking : DevExpress.XtraEditors.XtraForm
    {
        clsWork work = new clsWork();
        public frmForwardTracking()
        {
            InitializeComponent();
        }

        private void frmForwardTracking_Load(object sender, EventArgs e)
        {

        }

        private void cmdDisplay_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            DisplayList();
        }

        private void DisplayList()
        {
            if (SerialNoTextEdit.Text == "")
            {
                MessageBox.Show("제조번호를 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TrackingTreeList.DataSource = work.Get_Sys_ForwardTracking(SerialNoTextEdit.Text);
            TrackingTreeList.ExpandAll();
            TrackingTreeList.BestFitColumns();
        }

        private void cmdClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        private void SerialNoTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                DisplayList();
            }
        }

        private void TrackingTreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Selected)
                {
                    if (e.Node.HasChildren)
                    {
                        e.NodeImageIndex = 3;
                    }
                    else
                    {
                        e.NodeImageIndex = 4;
                    }//end if
                }
                else
                {
                    if (e.Node.HasChildren)
                    {
                        e.NodeImageIndex = 1;
                    }
                    else
                    {
                        e.NodeImageIndex = 0;
                    }//end if
                }//end if

            }//end if
        }

        private void cmdExcel_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Worksheets|*.Xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                TrackingTreeList.ExportToXlsx(sfd.FileName);
                System.Diagnostics.Process.Start(sfd.FileName);
            }//end fnction
        }
    }
}