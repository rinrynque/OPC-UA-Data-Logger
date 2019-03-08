using IAADL_Core;
using Opc.Ua;
using Opc.Ua.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IAADL_Service
{
    public partial class IAADL_Service : ServiceBase
    {
        public IAADL_Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Client;
            application.ConfigSectionName = "IAA_DataLogger";

            try
            {
                var installedConfigPath = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData), @"IAADL\Service.Config.xml");
                if (File.Exists(installedConfigPath))
                {
                    application.LoadApplicationConfiguration(installedConfigPath, false).Wait();
                }
                else
                {
                    application.LoadApplicationConfiguration(false).Wait();
                }

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0).Wait();
                //application.ApplicationConfiguration = new ApplicationConfiguration();
                m_configuration = application.ApplicationConfiguration;
                var settingsConfigPath = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData), @"IAADL\Service.Parameters.json");
                if (File.Exists(settingsConfigPath))
                {
                    loadConfigFile(settingsConfigPath);
                }
            }
            catch (Exception e)
            {
                //ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }

        protected override void OnStop()
        {
            foreach(var server in m_servers)
            {
                foreach(var group in server.GroupLogs)
                {
                    group.StopLogging();
                }
                server.Connection.Disconnect();
            }
        }

        private ApplicationConfiguration m_configuration;
        private System.Collections.Generic.List<ServerLog> m_servers = new List<ServerLog>();

        private async void loadConfigFile(string filePath)
        {
            try
            {
                var ServerConfs = ConfigFile.LoadFromFile(filePath);
                foreach (ServerConf serverConf in ServerConfs)
                {
                    await addServer(serverConf);
                }                    
                foreach(var server in m_servers)
                {
                    foreach(var group in server.GroupLogs)
                    {
                        group.StartLogging();
                    }
                }
            }
            catch (Exception exception)
            {
                //Opc.Ua.Client.CoreClientUtils.HandleException(m_configuration.ApplicationName, exception);
            }
        }
        private async Task<ServerLog> addServer(ServerConf serverConf)
        {
            ServerLog newServer = new ServerLog();
            newServer.Name = serverConf.Name;
            newServer.URI = serverConf.URI;
            newServer.Connection.Configuration = m_configuration;
            newServer.Connection.ServerUrl = newServer.URI;
            m_servers.Add(newServer);
            try
            {
                await newServer.Connection.Connect();
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
            foreach (GroupConf groupConf in serverConf.GroupConfs)
            {
                addGroup(groupConf, newServer);
            }
            return newServer;
        }

        private void addGroup(GroupConf groupConf, ServerLog server)
        {
            var newGroup = new GroupLog();
            newGroup.Name = groupConf.Name;
            newGroup.FilePath = groupConf.CSVPath;
            newGroup.UpdatePeriod = groupConf.UpdatePeriod;
            newGroup.LogRate = groupConf.LogRate;
            newGroup.LogFileSettings = groupConf.LogFileSettings;
            newGroup.Server = server;
            newGroup.Server.GroupLogs.Add(newGroup);

            foreach (ItemConf itemConf in groupConf.ItemConfs)
            {
                addItem(itemConf, newGroup);
            }

        }
        private void addItem(ItemConf itemConf, GroupLog groupLog)
        {
            try
            {
                groupLog.CreateMonitoredItem(itemConf.ID, itemConf.Name);
            }
            catch (Exception exception)
            {
                //ClientUtils.HandleException(this.Text, exception);
            }
        }
    }
}
