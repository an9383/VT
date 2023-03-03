using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
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
using VTMES3_RE.Common;
using VTMES3_RE.Models;

namespace VTMES3_RE.View.WorkManager
{
    public partial class frmUsbLockKey3 : DevExpress.XtraEditors.XtraForm
    {
        string folderName = Application.StartupPath + @"\Templates\USBLockkey";
        string fileName = "USB_LockKey.xlsx";
        clsWork work = new clsWork();
        public frmUsbLockKey3()
        {
            InitializeComponent();
        }

        private void frmUsbLockKey_Load(object sender, EventArgs e)
        {
            excelSheetControl.LoadDocument(folderName + "\\" + fileName);
        }

        private void exporter_CellValueConversionError(object sender, CellValueConversionErrorEventArgs e)
        {
            DataTableExporter exporter = sender as DataTableExporter;
            CellValueToColumnTypeConverter defaultToColumnTypeConverter = exporter != null ? exporter.Options.DefaultCellValueToColumnTypeConverter : null;
            if (e.DataColumn.DataType == typeof(Double) && e.CellValue.IsText)
            {
                object newDataTableValue = CellValue.Empty;
                ConversionResult isConverted = defaultToColumnTypeConverter.Convert(e.Cell, e.CellValue, e.DataColumn.DataType, out newDataTableValue);
                e.DataTableValue = newDataTableValue;
                e.Action = isConverted == ConversionResult.Success ? DataTableExporterAction.Continue : DataTableExporterAction.SkipRow;
            }
        }

        private void cmdClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        private void cmdSave_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                Worksheet worksheet = excelSheetControl.Document.Worksheets[0];

                CellRange range = worksheet.GetDataRange();

                DataTable dataTable = worksheet.CreateDataTable(range, true);
                dataTable.TableName = "ExcelUpload";

                DataTableExporter exporter = worksheet.CreateDataTableExporter(range, dataTable, true);
                exporter.Options.ConvertEmptyCells = true;
                exporter.Options.DefaultCellValueToColumnTypeConverter.EmptyCellValue = 0;
                exporter.Options.DefaultCellValueToColumnTypeConverter.SkipErrorValues = true;

                exporter.CellValueConversionError += exporter_CellValueConversionError;
                exporter.Export();

                if (dataTable.Rows.Count < 1)
                {
                    MessageBox.Show("제출할 항목이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string strQuery ="";

                foreach (DataRow dr in dataTable.Rows)
                {
                    //merge into  ( 있으면 Update, 없으면 Insert ) 
                    strQuery += " MERGE INTO IFSYS.DBO.SW_LOCK_MASTER AS A ";
                    strQuery += " using (SELECT 1 AS dual) AS B on(A.LOCK_KEY_SN = '" + dr["LOCK_KEY_SN"].ToString() + "') ";
                    strQuery += " when MATCHED THEN ";
                    strQuery += " update set SW_KEY_CONTENT = '"+ dr["SW_KEY_CONTENT"].ToString() + "', UPDATE_DATE = getdate(), UPDATE_USER = '"+ WrGlobal.LoginID+"'" ;
                    strQuery += " WHEN NOT MATCHED THEN ";
                    strQuery += " insert(LOCK_KEY_SN, SW_KEY_CONTENT, CREATE_DATE, CREATE_USER) values('" + dr["LOCK_KEY_SN"].ToString() + "', '" + dr["SW_KEY_CONTENT"].ToString() + "', getdate(), '" + WrGlobal.LoginID + "');";              

                    work.ExecuteQry(strQuery);

                    //Sch Table                    
                    //work.ExecuteQry("select * from ifsys.dbo.SW_LOCK_MASTER where LOCK_KEY_SN = "+dr["LOCK_KEY_SN"].ToString()+"" );

                }

                MessageBox.Show("등록이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //excelSheetControl.CreateNewDocument();//새파일 열기

                excelSheetControl.LoadDocument(folderName + "\\" + fileName); // 템플릿 다시로드




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}