using IAADL_Core;
using Opc.Ua;
using Opc.Ua.Client.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAADL_App.Forms
{
    public partial class ServerForm : Form
    {
        private ApplicationConfiguration m_configuration;

        public ServerForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }

        public ServerConf NewServerDialog(ApplicationConfiguration configuration, string serverName = "Server")
        {
            m_configuration = configuration;
            serverNameTB.Text = serverName;
            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            var conf = new ServerConf
            {
                Name = serverNameTB.Text,
                URI = serverURITB.Text
            };
            return conf;
        }

        public void EditServerDialog(ServerLog server)
        {
            serverNameTB.Text = server.Name;
            serverURITB.Text = server.URI;
            serverURITB.Enabled = false;
            discoverBTN.Enabled = false;

            if (ShowDialog() != DialogResult.OK)
            {
                return;
            }
            server.Name = serverNameTB.Text;
        }

        private void discoverBTN_Click(object sender, EventArgs e)
        {
            string endpointUrl = new DiscoverServerDlg().ShowDialog(m_configuration, "");

            if (endpointUrl != null)
            {
                serverURITB.Text = endpointUrl;
            }
        }

        private void OKBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void applyBTN_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
