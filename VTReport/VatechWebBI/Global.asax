<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) {
        DevExpress.Web.ASPxWebControl.CallbackError += new EventHandler(Application_Error);
        DevExpress.Security.Resources.AccessSettings.DataResources.SetRules(DevExpress.Security.Resources.DirectoryAccessRule.Allow(Server.MapPath("~/Content")), DevExpress.Security.Resources.UrlAccessRule.Allow());
        DevExpress.DashboardWeb.DashboardConfigurator.PassCredentials = true;
        
        DevExpress.XtraReports.Web.ReportDesigner.DefaultReportDesignerContainer.EnableCustomSql();
    }

    void Application_End(object sender, EventArgs e) {
        // Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e) {
        // Code that runs when an unhandled error occurs
    }

    void Session_Start(object sender, EventArgs e) {
        // Code that runs when a new session is started

        Session["CorpId"] = "VT";
        Session["EmpNo"] = "";
        Session["EmpName"] = "";
        Session["EmpIp"] = "";
        Session["Author"] = null;

        Session["SessionNo"] = "";

        Session["ProgramType"] = "1";

        Session["DbServer"] = "10.50.50.53";
        Session["DbName"] = "RPT_CAMDB";
        Session["DbId"] =  "sa";
        Session["DbPw"] = "infodba";

        Session["tabs"] = null;

        DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new CustomReportStorageWebExtension(Session["CorpId"].ToString()));
        DevExpress.XtraReports.Web.ASPxReportDesigner.StaticInitialize();
    }

    void Session_End(object sender, EventArgs e) {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
</script>