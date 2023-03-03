﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using VTMES3_RE.Common;


namespace VTMES3_RE.Models
{
    public class clsWork
    {
        Database db = new Database();
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

        public DataView Get_Sys_ForwardTracking(string serialNo)
        {
            query = string.Format("exec CAMDBsh.VR_Proc_Sys_ForwardTracking '{0}'", serialNo);
            return db.GetDataView("Sys_ForwardTracking", query);
        }

        public DataView GetWorkflowStepByFilter(string factoryName)
        {
            query = string.Format("Select a.ItemCode 공정, a.ItemName 구분 "
                            + "From "
                                + "(Select N'전체' ItemCode, N'전체' ItemName, 0 SortOrder Union All "
                                    + "Select ItemCode, ItemName, SortORder From IFSYS.dbo.VM_ItemDef Where FactoryName = N'{0}' and ItemGubun = 'ESigWorkflowStepName') a "
                            + "Order By a.SortOrder", factoryName);
            return db.GetDataView("공정", query);
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
        public String getSWLockKeySAPCode(string SN)
        {
            query = string.Format("SELECT ItemCode FROM SAP.VATECH_SW.dbo.OSRN a where a.DistNumber = '{0}'", SN);
            DataRowView DRV = db.GetDataRecord(query);

            if (DRV == null)
            {
                return "";
            }
            else
            {
                return DRV["ITEMCODE"].ToString();
            }
            
        }

    }
}
