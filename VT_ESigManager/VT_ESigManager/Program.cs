using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VT_ESigManager.Common;
using VT_ESigManager.View;

namespace VT_ESigManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            InstalledFontCollection installedFontCollection = new InstalledFontCollection();
            bool isFontInstall = false;
            foreach (FontFamily fontFamily in installedFontCollection.Families)
            {
                if (fontFamily.Name.Equals("Pretendard SemiBold"))
                {
                    isFontInstall = true;
                }
            }

            if (!isFontInstall)
            {
                Shell32.Shell shell = new Shell32.Shell();
                Shell32.Folder fontFolder = shell.NameSpace(0x14);
                fontFolder.CopyHere(Application.StartupPath + @"\Fonts\Pretendard-SemiBold.ttf");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mutex mutex = new Mutex(true, "VTMonitor", out bool isExecuted);

            if (isExecuted)
            {
                try
                {
                    ////테스트서버
                    //WrGlobal.reportRootUrl = @"http://10.10.50.53";

                    //WrGlobal.SQL_SERVER = "10.10.50.53";
                    //WrGlobal.SQL_Database = "CAMDB";
                    //WrGlobal.SQL_Id = "Vatech";
                    //WrGlobal.SQL_Password = "Dentalimageno.1";

                    //운영서버
                    WrGlobal.reportRootUrl = @"http://vtmes30.vatech.com";

                    WrGlobal.SQL_SERVER = "10.10.50.61";
                    WrGlobal.SQL_Database = "CAMDB";
                    WrGlobal.SQL_Id = "Vatech";
                    WrGlobal.SQL_Password = "Rkddkwl2014!@";

                    if (new frmChangeUser().ShowDialog() == DialogResult.OK)
                    {
                        if (WrGlobal.FactoryName == "시스템사업부")
                        {
                            Application.Run(new View.frmSys_ESigManager());
                        }
                        else
                        {
                            Application.Run(new View.frmInno_ESigManager());
                        }
                        
                    }
                        
                    mutex.ReleaseMutex();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("프로그램이 이미 실행중 입니다.");
                Application.Exit();
            }

        }
    }
}
