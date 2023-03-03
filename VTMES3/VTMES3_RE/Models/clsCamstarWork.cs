using DevExpress.CodeParser;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTMES3_RE.Common;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace VTMES3_RE.Models
{
    public class clsCamstarWork
    {
        CamstarDatabase db = new CamstarDatabase();
        string query = "";

        public DataView GetDataViewByQuery(string tblName, string _query)
        {
            return db.GetDataView(tblName, _query);
        }

        public void ExecuteQry(string _query)
        {
            db.ExecuteQuery(_query);
        }
        public int ExecuteQryList(List<string> queryList)
        {
            return db.ExecuteQueryList(queryList);
        }

        public XtraReport GetSelectedReport(string url)
        {
            // Return a report by a URL selected in the ListBox.
            if (url == "")
                return null;
            using (MemoryStream stream = new MemoryStream(Program.ReportStorage.GetData(url)))
            {
                return XtraReport.FromStream(stream, true);
            }
        }
    }
}
