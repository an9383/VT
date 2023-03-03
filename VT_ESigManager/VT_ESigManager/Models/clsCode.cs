﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VT_ESigManager.Common;

namespace VT_ESigManager.Models
{
    public class clsCode
    {
        Database db = new Database();
        string query = "";

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        ~clsCode()
        {
            this.Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                db.Dispose();
                db = null;

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~WrCategories()
        // {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public void ExecuteQry(string _query)
        {
            db.ExecuteQuery(_query);
        }
        public int ExecuteQryList(List<string> queryList)
        {
            return db.ExecuteQueryList(queryList);
        }
        public DataView GetFilterTags()
        {
            query = string.Format("select FactoryName 명칭, FactoryId 코드 From CAMDBsh.Factory");
            return db.GetDataView("사업부", query);
        }

        public DataView GetEmployeeByFilter(string factoryId)
        {
            query = string.Format("select Employee.EmployeeName 코드, Employee.FullName 명칭, Employee.EmployeeId "
                            + "From CAMDBsh.Employee Inner Join CAMDBsh.SessionValues on Employee.EmployeeId = SessionValues.EmployeeId where SessionValues.FactoryId = '{0}'", factoryId);
            return db.GetDataView("작업자", query);
        }

        public DataView GetEmployeeByEsigRole(string factoryId)
        {
            query = string.Format("select Employee.EmployeeName 코드, Employee.FullName 명칭, Employee.EmployeeId, ESigRoleGroup.ESigRoleGroupName "
                            + "From CAMDBsh.Employee "
                                + "Inner Join CAMDBsh.SessionValues on Employee.EmployeeId = SessionValues.EmployeeId " 
                                + "INNER JOIN CAMDBsh.ESigRoleGroup ON Employee.ESigRoleGroupId = ESigRoleGroup.ESigRoleGroupId "
                            + "where SessionValues.FactoryId = '{0}' AND ESigRoleGroupName IN (N'검토자',N'승인자')", factoryId);
            return db.GetDataView("결재자", query);
        }

        public DataView GetWorkflowStepByFilter(string factoryName)
        {
            query = string.Format("Select ItemCode, ItemName From IFSYS.dbo.VM_ItemDef Where FactoryName = N'{0}' and ItemGubun = 'ESigWorkflowStepName' Order by SortOrder", factoryName);
            return db.GetDataView("공정", query);
        }

        public DataRowView GetNowWorkTimeByContainer(string containerName)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_GetNowWorkTimeByContainer N'{0}'", containerName);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionTimeByEmployee(string employeeName)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_GetNoOpeartionTimeByEmployee N'{0}'", employeeName);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionStart(string workType, string employeeName, string reason)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_SetNoOperation '{0}', '0', N'{1}', N'{2}'", workType, employeeName, reason);
            return db.GetDataRecord(query);
        }

        public DataRowView GetNoOpeartionEnd(string workType, string employeeName, string reason)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_SetNoOperation '{0}', '1', N'{1}', N'{2}'", workType, employeeName, reason);
            return db.GetDataRecord(query);
        }

        public int GetRoleIndexByEmployee(string employeeName, string roleName)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_RoleIndexByEmployee N'{0}', N'{1}'", employeeName, roleName);
            DataRowView drv = db.GetDataRecord(query);

            if (drv == null)
            {
                return -1;
            }
            else
            {
                return (int)drv["idx"];
            }
        }

        public DataView GetReleaseReason()
        {
            query = string.Format("select ReleaseReasonName From CAMDBsh.ReleaseReason order by ReleaseReasonName");
            return db.GetDataView("ReleaseReason", query);
        }

        public DataRowView GetQuickGuideByContainer(string containerName)
        {
            query = string.Format("exec CAMDBSh.VM_Proc_GetQuickGuideByContainer N'{0}'", containerName);
            return db.GetDataRecord(query);
        }

        public DataView GetDataViewByQuery(string tblName, string _query)
        {
            return db.GetDataView(tblName, _query);
        }
    }
}
