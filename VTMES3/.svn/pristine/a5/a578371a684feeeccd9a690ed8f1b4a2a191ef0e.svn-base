using Camstar.XMLClient.API;
using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTMES3_RE.Common
{
    public class CamstarCommon
    {
        csiClient gClient = new csiClient();
        csiConnection gConnection = null;
        csiSession gSession = null;
        csiDocument gDocument = null;
        csiService gService = null;
        string gStrSessionID = "";

        string gHost = WrGlobal.Camstar_Host;
        int gPort = WrGlobal.Camstar_Port;

        CamstarMessage camMessage = new CamstarMessage();

        public bool IsExecuting = false;
        public CamstarCommon()
        {
            try
            {
                gConnection = gClient.createConnection(gHost, gPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Camstar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateDocumentandService(string documentName, string serviceName)
        {
            if (documentName.Length > 0)
            {
                gSession.removeDocument(documentName);
            }

            if (gService != null)
            {
                gService = null;
            }

            gDocument = gSession.createDocument(documentName);

            if (serviceName.Length > 0)
            {
                gService = gDocument.createService(serviceName);
            }
        }

        public void PrintDoc(string strDoc, bool isInputDoc)
        {
            string strDocFileName = "";
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (isInputDoc)
            {
                strDocFileName = "inputDoc.xml";
            }
            else
            {
                strDocFileName = "responseDoc.xml";
            }

            if (File.Exists(path + "\\" + strDocFileName))
            {
                File.Delete(path + "\\" + strDocFileName);
            }

            File.WriteAllText(path + "\\" + strDocFileName, strDoc, Encoding.Default);
        }

        private void ErrorsCheck(csiDocument ResponseDocument)
        {
            csiExceptionData csiexceptiondata;

            if (ResponseDocument.checkErrors())
            {
                camMessage.Result = false;
                csiexceptiondata = ResponseDocument.exceptionData();
                camMessage.Message = "Severity: " + csiexceptiondata.getSeverity() + " Description: " + csiexceptiondata.getDescription();
            }
            else
            {
                camMessage.Result = true;
                camMessage.Message = "성공!";
            }
        }

        public string CreateSession()
        {
            try
            {
                gStrSessionID = Guid.NewGuid().ToString();
                gSession = gConnection.createSession(WrGlobal.Camstar_UserName, WrGlobal.Camstar_Password, gStrSessionID);

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DestroySession()
        {
            try
            {
                gConnection.removeSession(gStrSessionID);

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void DestroyConnection()
        {
            gConnection.removeSession(gStrSessionID);
            gClient.removeConnection(gHost, gPort);
        }

        #region Role Function
        public CamstarMessage RoleDelete(string employeeName, int idx)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiNamedSubentityList Roles = null;

            try
            {
                CreateDocumentandService("EmployeeMaintTrans", "EmployeeMaint");

                InputData = gService.inputData();
                InputData.namedObjectField("ObjectToChange").setRef(employeeName);

                gService.perform("Load");

                InputData2 = gService.inputData();

                ObjectChanges = InputData2.subentityField("ObjectChanges");
                Roles = ObjectChanges.namedSubentityList("Roles");

                Roles.deleteItemByIndex(idx);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);
                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message; 
            }

            return camMessage;
        }

        public CamstarMessage RoleAdd(string employeename, string roleName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiObject InputData2 = null;
            csiSubentity ObjectChanges = null;
            csiSubentity Members = null;

            try
            {
                CreateDocumentandService("EmployeeMaintTrans", "EmployeeMaint");

                InputData = gService.inputData();
                InputData.namedObjectField("ObjectToChange").setRef(employeename);

                gService.perform("Load");

                InputData2 = gService.inputData();

                ObjectChanges = InputData2.subentityField("ObjectChanges");
                Members = ObjectChanges.subentityList("Roles").appendItem();
                Members.namedObjectField("Role").setRef(roleName);
                Members.dataField("PropagateToChildOrgs").setValue(false.ToString());

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);
                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }
        #endregion

        #region Container Function

        public int ContainerStart(DataTable table)
        {
            int successCnt = 0;

            csiDocument ResponseDocument = null;
            csiObject InputData = null;
            csiSubentity Details = null;
            csiSubentity CurrentStatusDetails = null;

            try
            {
                CreateSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "세션 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {             
                //foreach (DataRow dr in table.Rows)
                //{
                //    // Set Service Type
                //    CreateDocumentandService("StartDoc", "Start");

                //    // Set Input Data
                //    InputData = gService.inputData();
                //    //Set CurrentStatusDetails
                //    CurrentStatusDetails = InputData.subentityField("CurrentStatusDetails");
                //    CurrentStatusDetails.revisionedObjectField("Workflow").setRef((dr["Workflow"] ?? "").ToString(), "", true);
                //    // Set Start Details
                //    Details = InputData.subentityField("Details");

                //    //Set Auto Container Name
                //    if ((dr["Container"] ?? "").ToString() == "Auto")
                //    {
                //        Details.dataField("AutoNumber").setValue("True");
                //        Details.dataField("IsContainer").setValue("True");
                //    }
                //    else
                //    {
                //        Details.dataField("ContainerName").setValue((dr["Container"] ?? "").ToString());
                //    }

                //    // Set Start Element
                //    Details.namedObjectField("Owner").setRef((dr["Owner"] ?? "").ToString());
                //    Details.dataField("Qty").setValue((dr["Qty"] ?? "0").ToString());
                //    Details.namedObjectField("StartReason").setRef((dr["StartReason"] ?? "").ToString());
                //    Details.namedObjectField("UOM").setRef((dr["UOM"] ?? "").ToString());
                //    Details.namedObjectField("Level").setRef((dr["Level"] ?? "").ToString());
                //    Details.namedObjectField("PriorityCode").setRef((dr["PriorityCode"] ?? "").ToString());
                //    Details.namedObjectField("MfgOrder").setRef((dr["MfgOrder"] ?? "").ToString());
                //    Details.revisionedObjectField("Product").setRef((dr["Product"] ?? "").ToString(), "", true);

                //    // Set Factory 
                //    InputData.namedObjectField("Factory").setRef((dr["Factory"] ?? "").ToString());

                //    // Service Excute and request Completion Msg
                //    gService.setExecute();
                //    gService.requestData().requestField("CompletionMsg");

                //    // Print XMl Dcoument
                //    PrintDoc(gDocument.asXML(), true);
                //    ResponseDocument = gDocument.submit();
                //    PrintDoc(ResponseDocument.asXML(), false);

                //    ErrorsCheck(ResponseDocument);

                //    dr.BeginEdit();
                //    if (camMessage.Result)
                //    {
                //        csiService csiservice = ResponseDocument.getService();
                //        if (csiservice != null && (dr["Container"] ?? "").ToString() == "Auto")
                //        {
                //            csiDataField csidatafield = (csiDataField)csiservice.responseData().getResponseFieldByName("CompletionMsg");
                //            dr["Container"] = csidatafield.getValue().Split(new char[] { ' ' })[0].Trim();
                //        }
                //        successCnt++;
                //    }
                //    else
                //    {
                //        dr["Container"] = "";
                //    }

                //    dr["Result"] = camMessage.Message;
                //    dr["BoolResult"] = camMessage.Result;
                //    dr.EndEdit();
                //}
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            DestroySession();

            return successCnt;
        }

        public CamstarMessage ContainerHoldLoop(string containerName, string holdReasonName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;

            try
            {
                CreateDocumentandService("HoldDoc", "Hold");

                InputData = gService.inputData();

                InputData.namedObjectField("Container").setRef(containerName);
                InputData.namedObjectField("HoldReason").setRef(holdReasonName);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);

                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }

        public CamstarMessage ContainerReleaseLoop(string containerName, string releaseReasonName)
        {
            csiDocument ResponseDocument = null;
            csiObject InputData = null;

            try
            {
                CreateDocumentandService("ReleaseDoc", "Release");

                InputData = gService.inputData();

                InputData.namedObjectField("Container").setRef(containerName);
                InputData.namedObjectField("ReleaseReason").setRef(releaseReasonName);

                gService.setExecute();
                gService.requestData().requestField("CompletionMsg");

                PrintDoc(gDocument.asXML(), true);
                ResponseDocument = gDocument.submit();
                PrintDoc(ResponseDocument.asXML(), false);

                ErrorsCheck(ResponseDocument);
            }
            catch (Exception ex)
            {
                camMessage.Result = false;
                camMessage.Message = ex.Message;
            }

            return camMessage;
        }

        #endregion
    }
}
