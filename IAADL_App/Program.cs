using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client.Controls;
using System.IO;

namespace IAADL_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize the user interface.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType   = ApplicationType.Client;
            application.ConfigSectionName = "IAA_DataLogger";

            try
            {
                // load the application configuration.
                var installedConfigPath = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData), @"IAADL\App.Config.xml");
                if (File.Exists(installedConfigPath))
                {
                    application.LoadApplicationConfiguration(installedConfigPath, false).Wait();
                }
                else
                {
                    application.LoadApplicationConfiguration(false).Wait();
                }

                var logFilePath = application.ApplicationConfiguration.TraceConfiguration.OutputFilePath;
                if (!Path.IsPathRooted(logFilePath))
                {
                    application.ApplicationConfiguration.TraceConfiguration.OutputFilePath = Path.Combine(Directory.GetCurrentDirectory(), logFilePath);
                }
                application.ApplicationConfiguration.TraceConfiguration.ApplySettings();

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();

                // run the application interactively.
                Application.Run(new MainForm(application.ApplicationConfiguration));
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }
    }
}
