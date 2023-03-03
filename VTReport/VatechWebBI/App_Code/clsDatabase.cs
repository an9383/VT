﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// clsDatabase의 요약 설명입니다.
/// </summary>
public class clsDatabase
{
    private SqlConnection adoCon = new SqlConnection();
    private DataView returnView = null;
    public String m_ConnectionString = "SERVER=10.10.50.53;Database=RPT_CAMDB;User ID=sa;Password=infodba";   //데이터베이스 연결 스트링

    int timeoutSec = 240;

    public clsDatabase()
    {
        adoCon.ConnectionString = m_ConnectionString;
    }

    public void DBconnection()
    {
        try
        {
            if (adoCon.State != ConnectionState.Open)
            {
                adoCon.Open();
            }
        }

        catch (Exception ex)
        {
            if (adoCon.State != ConnectionState.Open)
            {
                HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            }
        }//end try

    }//end function

    public void DBClose()
    {
        if (adoCon.State == ConnectionState.Open)
        {
            adoCon.Close();
        }

    }//end function

    public SqlCommand GetProcedure(string procedurename)
    {
        DBconnection();

        SqlCommand cmd = new SqlCommand(procedurename, adoCon);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = procedurename;
        cmd.CommandTimeout = timeoutSec;
        return cmd;
    }

    public DataView GetDataView(string tblName, string strQuery)
    {
        DBconnection();

        DataSet ds = new DataSet();
        SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);
        try
        {
            SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
            SqlAdapter.SelectCommand.CommandTimeout= timeoutSec;
            SqlAdapter.Fill(ds, tblName);

            returnView = ds.Tables[tblName].DefaultView;
            return returnView;
        }
        catch (Exception ex)
        {

            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            return null;
        }
        finally
        {
            DBClose();
        }
    }//end function

    public SqlDataReader GetDataReader(string strQuery)
    {
        try
        {
            DBconnection();

            SqlCommand cmd = new SqlCommand(strQuery, adoCon);
            cmd.CommandTimeout= timeoutSec;
            return cmd.ExecuteReader();

        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            return null;
        }
        finally
        {

        }
    }//end function


    public DataSet GetDataSet(string strTable, string strQuery)
    {
        DBconnection();

        DataSet ds = new DataSet();
        SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);
        try
        {
            SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
            SqlAdapter.SelectCommand.CommandTimeout = timeoutSec;
            SqlAdapter.Fill(ds, strTable);
            return ds;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            return null;
        }
        finally
        {
            DBClose();
        }
    }//end function


    public DataRowView GetDataRecord(string strQuery)
    {
        DBconnection();

        DataSet ds = new DataSet();
        SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);

        try
        {
            SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
            SqlAdapter.SelectCommand.CommandTimeout= timeoutSec;
            SqlAdapter.Fill(ds, "OneRow");

            returnView = ds.Tables["OneRow"].DefaultView;
            if (returnView != null && returnView.Count == 1)
            {
                return returnView[0];
            }
            return null;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            return null;
        }
        finally
        {
            DBClose();
        }
    }

    public int GetDataScalar(string strQuery)
    {
        int _scalar = 0;
        try
        {
            DBconnection();

            SqlCommand cmd = new SqlCommand(strQuery, adoCon);
            cmd.CommandTimeout= timeoutSec;
            _scalar = Int32.Parse(cmd.ExecuteScalar().ToString());
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            _scalar = 0;
        }
        finally
        {
            DBClose();
        }
        return _scalar;

    }

    public bool ExecuteQuery(string strQuery)
    {
        DBconnection();

        bool result = false;
        SqlCommand cmd = new SqlCommand(strQuery, adoCon);
        cmd.CommandTimeout = timeoutSec;

        try
        {
            cmd.ExecuteNonQuery();

            result = true;
        }
        catch (Exception ex)
        {
            //HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
        }
        finally
        {
            DBClose();
        }
        return result;
    }


    public string ExecProc(string _query)
    {
        string outString = "";
        try
        {
            DBconnection();

            SqlCommand cmd = new SqlCommand(_query, adoCon);
            cmd.CommandTimeout = timeoutSec;    
            outString = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            outString = "";
        }
        finally
        {
            DBClose();
        }
        return outString;

    }

    public string ExecAutoNumber(string _docType, DateTime _currentDate)
    {
        string returnValue = string.Empty;

        try
        {
            DBconnection();

            SqlCommand cmd = new SqlCommand("Code_AutoNumber", adoCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout= timeoutSec; 

            cmd.Parameters.Add(new SqlParameter("@pDocType", _docType));
            cmd.Parameters.Add(new SqlParameter("@pCurrentDate", _currentDate.ToString("yyyyMMdd")));

            var returnParam = new SqlParameter
            {
                ParameterName = "@pNumber",
                Size = 13,
                Direction = ParameterDirection.Output
            };

            cmd.Parameters.Add(returnParam);

            cmd.ExecuteNonQuery();

            returnValue = (string)returnParam.Value;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
            returnValue = "";
        }
        finally
        {
            DBClose();
        }

        return returnValue;
    }

    public bool ExecuteBulkCopy(DataTable dt)
    {
        bool result = false;

        DBconnection();
        SqlTransaction adoTran = adoCon.BeginTransaction();

        try
        {
            using (SqlBulkCopy bulk = new SqlBulkCopy(adoCon, SqlBulkCopyOptions.TableLock, adoTran))
            {
                bulk.BulkCopyTimeout = 0;
                bulk.BatchSize = dt.Rows.Count;
                bulk.DestinationTableName = dt.TableName;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    bulk.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                }

                bulk.WriteToServer(dt);
                dt.Clear();

                bulk.Close();
            }

            adoTran.Commit();

            result = true;
        }
        catch (Exception ex)
        {
            result = false;
            HttpContext.Current.Response.Write("<script language='JavaScript'>alert('" + ex.Message + "')</script>");
        }
        finally
        {
            adoTran.Dispose();
            DBClose();
        }

        return result;
    }


}