/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using IAADL_App;
using IAADL_App.Forms;
using System.Linq;
using System.Threading.Tasks;
using IAADL_Core;
using IAADL_App.Controls;

namespace IAADL_App
{
    /// <summary>
    /// The main form for a simple Quickstart Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        private MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }

        /// <summary>
        /// Creates a form which uses the specified client configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();

            m_configuration = configuration;
            this.Text = m_configuration.ApplicationName;

            try
            {
                //var configPath = Path.Combine(Directory.GetCurrentDirectory(), "configuration.json");
                //m_serviceConf = MainConf.LoadConf(configPath);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private MainConf m_serviceConf = new MainConf();
        
        private System.Collections.Generic.List<ServerLog> m_servers = new List<ServerLog>();
        #endregion

        #region Event Handlers
        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit ?", "IAA Data Logger", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //var configPath = Path.Combine(Directory.GetCurrentDirectory(), "configuration.json");
                    //m_serviceConf.SaveConf(configPath);

                    foreach(var server in m_servers)
                    {
                        server.Connection.Disconnect();
                    }

                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newConfigFile(object sender, EventArgs e)
        {
            try
            {
                preferencesBTN.Enabled = false;
                newItemBTN.Enabled = false;
                newGroupBTN.Enabled = false;
                newServerBTN.Enabled = true;
                startLoggingBTN.Enabled = false;
                pauseLoggingBTN.Enabled = false;
                stopLoggingBTN.Enabled = false;
                splitContainer1.Panel2.Controls.Clear();
                itemsTV.Nodes[0].Nodes.Clear();
                foreach (var server in m_servers)
                {
                    server.Connection.Disconnect();
                    //server.Connection.ServerStatusControl.Text = "";
                    //server.Connection.StatusUpateTimeControl.Text = "";
                    //server.Connection.Dispose();
                }
                m_servers = new List<ServerLog>();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        private void saveConfigFile(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(m_serviceConf.ConfigFilePath))
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                if (String.IsNullOrEmpty(m_serviceConf.ConfigFilePath))
                {
                    return;
                }
                ConfigFile.SaveToFile(m_servers, m_serviceConf.ConfigFilePath);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        private void loadConfigFile(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        //Get the path of specified file
                        var filePath = openFileDialog.FileName;
                        m_serviceConf.ConfigFilePath = filePath;
                        var ServerConfs = ConfigFile.LoadFromFile(filePath);

                        Cursor.Current = Cursors.WaitCursor;
                        itemsTV.BeginUpdate();

                        newConfigFile(sender, e);

                        foreach (ServerConf serverConf in ServerConfs)
                        {
                            addServer(serverConf);
                        }
                        itemsTV.EndUpdate();
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Default;
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (SaveFileDialog openFileDialog = new SaveFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    m_serviceConf.ConfigFilePath = openFileDialog.FileName;
                    saveConfigFile(sender, e);
                }
            }

        }

        private async void newServerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new IAADL_App.Forms.ServerForm())
                {
                    var newServerConf = frm.NewServerDialog(m_configuration, String.Format("Server{0}", itemsTV.Nodes[0].Nodes.Count + 1));

                    if(newServerConf == null)
                    {
                        return;
                    }

                    var newServer = await addServer(newServerConf);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void itemsTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                preferencesBTN.Enabled = true;
                if (itemsTV.SelectedNode.Tag == null)
                {
                    newToolStripMenuItem1.Enabled = true;
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    return;
                }
                if (itemsTV.SelectedNode.Tag.GetType() == typeof(GroupLog))
                {
                    newToolStripMenuItem1.Enabled = true;
                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;

                    GroupLog selectedGroup = (GroupLog)itemsTV.SelectedNode.Tag;
                    newItemBTN.Enabled = true;
                    newGroupBTN.Enabled = false;

                    splitContainer1.Panel2.Controls.Clear();
                    var listCtrl = (MonitoredItemsListCTRL)selectedGroup.Handle;
                    splitContainer1.Panel2.Controls.Add(listCtrl);
                    listCtrl.Dock = DockStyle.Fill;
                    if (selectedGroup.IsLogging && !selectedGroup.IsLoggingPaused)
                    {
                        startLoggingBTN.Enabled = false;
                        pauseLoggingBTN.Enabled = true;
                        stopLoggingBTN.Enabled = true;
                    }
                    else if (selectedGroup.IsLogging && selectedGroup.IsLoggingPaused)
                    {
                        startLoggingBTN.Enabled = true;
                        pauseLoggingBTN.Enabled = false;
                        stopLoggingBTN.Enabled = true;
                    }
                    else
                    {
                        startLoggingBTN.Enabled = true;
                        pauseLoggingBTN.Enabled = false;
                        stopLoggingBTN.Enabled = false;
                    }
                }
                else if (itemsTV.SelectedNode.Tag.GetType() == typeof(ServerLog))
                {
                    newToolStripMenuItem1.Enabled = true;
                    editToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;

                    startLoggingBTN.Enabled = false;
                    pauseLoggingBTN.Enabled = false;
                    stopLoggingBTN.Enabled = false;
                    newGroupBTN.Enabled = true;
                    newItemBTN.Enabled = false;
                }
                else if (itemsTV.SelectedNode.Tag.GetType() == typeof(ItemLog))
                {
                    newToolStripMenuItem1.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void newGroupBTN_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = itemsTV.SelectedNode;
                if (selectedNode == null || selectedNode.Tag == null || selectedNode.Tag.GetType() != typeof(ServerLog))
                {
                    return;
                }
                var newGroup = new GroupLog();
                newGroup.Name = "Group";
                newGroup.Server = (ServerLog)selectedNode.Tag;

                ;
                if (new GroupForm(newGroup).ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                newGroup.Server.GroupLogs.Add(newGroup);
                newGroup.ItemAction += itemAction;

                // add node.
                TreeNode groupNode = new TreeNode(newGroup.Name);
                groupNode.Tag = newGroup;
                selectedNode.Nodes.Add(groupNode);
                selectedNode.Expand();

                MonitoredItemsListCTRL listCTRL = new MonitoredItemsListCTRL();
                newGroup.Handle = listCTRL;
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void newItemBTN_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = itemsTV.SelectedNode;
                if (selectedNode == null || selectedNode.Tag == null)
                {
                    return;
                }
                else if (selectedNode.Tag.GetType() != typeof(ServerLog))
                {
                    GroupLog selectedGroup = (GroupLog)itemsTV.SelectedNode.Tag;
                    if (selectedGroup != null)
                    {
                        //selectedGroup.NewItemDialog();
                        var itemForm = new ObjectsForm();
                        itemForm.showForm(selectedGroup);
                    }
                    return;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void startLoggingBTN_Click(object sender, EventArgs e)
        {
            try
            {
                GroupLog selectedGroup = (GroupLog)itemsTV.SelectedNode.Tag;
                if (selectedGroup != null)
                {
                    selectedGroup.StartLogging();
                    startLoggingBTN.Enabled = false;
                    pauseLoggingBTN.Enabled = true;
                    stopLoggingBTN.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void pauseLoggingBTN_Click(object sender, EventArgs e)
        {
            try
            {
                GroupLog selectedGroup = (GroupLog)itemsTV.SelectedNode.Tag;
                if (selectedGroup != null)
                {
                    selectedGroup.PauseLogging();
                    startLoggingBTN.Enabled = true;
                    pauseLoggingBTN.Enabled = false;
                    stopLoggingBTN.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }

        }

        private void stopLoggingBTN_Click(object sender, EventArgs e)
        {
            try
            {
                GroupLog selectedGroup = (GroupLog)itemsTV.SelectedNode.Tag;
                if (selectedGroup != null)
                {
                    selectedGroup.StopLogging();
                    startLoggingBTN.Enabled = true;
                    pauseLoggingBTN.Enabled = false;
                    stopLoggingBTN.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private async Task<ServerLog> addServer(ServerConf serverConf)
        {
            ServerLog newServer = new ServerLog();
            newServer.Name = serverConf.Name;
            newServer.URI = serverConf.URI;
            newServer.Connection.Configuration = m_configuration;
            //newServer.control.StatusStrip = StatusBar;
            newServer.Connection.ServerUrl = newServer.URI;
            m_servers.Add(newServer);
            itemsTV.Nodes[0].Nodes.Add(newServer.Name).Tag = newServer;
            itemsTV.Nodes[0].Expand();
            try
            {
                await newServer.Connection.Connect();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
            foreach(GroupConf groupConf in serverConf.GroupConfs)
            {
                addGroup(groupConf, newServer);
            }
            return newServer;
        }

        private void addGroup(GroupConf groupConf, ServerLog server)
        {
            var searchNodes = itemsTV.Nodes[0].Nodes.OfType<TreeNode>();
            var serverNode = searchNodes.FirstOrDefault(node => node.Tag != null && node.Tag.Equals(server));
            if(serverNode == null)
            {
                return;
            }

            var newGroup = new GroupLog();
            newGroup.Name = groupConf.Name;
            newGroup.FilePath = groupConf.CSVPath;
            newGroup.UpdatePeriod = groupConf.UpdatePeriod;
            newGroup.LogRate = groupConf.LogRate;
            newGroup.LogFileSettings = groupConf.LogFileSettings;
            newGroup.Server = server;
            newGroup.Server.GroupLogs.Add(newGroup);
            newGroup.ItemAction += itemAction;

            // add node.
            TreeNode groupNode = new TreeNode(newGroup.Name);
            groupNode.Tag = newGroup;
            serverNode.Nodes.Add(groupNode);
            serverNode.Expand();
            MonitoredItemsListCTRL listCTRL = new MonitoredItemsListCTRL();
            newGroup.Handle = listCTRL;

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
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private TreeNode getNodeFromTag(TreeNode rootNode, object tag)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Tag != null && node.Tag.Equals(tag))
                {
                    return node;
                }
                TreeNode next = getNodeFromTag(node, tag);
                if (next != null)
                {
                    return next;
                }
            }
            return null;
        }

        private void itemAction(object sender, ItemEventArgs e)
        {
            try
            {
                var groupNode = getNodeFromTag(itemsTV.Nodes[0], sender);
                if (groupNode == null)
                {
                    return;
                }

                if (e.Action == ItemEventArgs.ItemActionEnum.Created)
                {
                    groupNode.Nodes.Add(e.Name).Tag = e.Item;
                    e.Item.MI.Notification += Item_Notification;

                    // add the attribute name/value to the list view.
                    ListViewItem item = new ListViewItem(e.Item.MI.ClientHandle.ToString());
                    item.UseItemStyleForSubItems = false;

                    item.SubItems.Add(e.Item.MI.DisplayName);
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);
                    item.SubItems.Add(String.Empty);
                    e.Item.Handle = item;

                    item.Tag = e.Item;

                    var group = (GroupLog) groupNode.Tag;

                    ((MonitoredItemsListCTRL) group.Handle).MonitoredItemsLV.Items.Add(item);
                }
                else if(e.Action == ItemEventArgs.ItemActionEnum.Deleted)
                {
                    var itemLV = (ListViewItem)e.Item.Handle;
                    itemLV.Remove();
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void Item_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            var itemLog = (ItemLog)monitoredItem.Handle;
            var group = itemLog.Group;
            var itemsListCTRL = (MonitoredItemsListCTRL)group.Handle;

            if (itemsListCTRL.MonitoredItemsLV.InvokeRequired)
            {
                itemsListCTRL.MonitoredItemsLV.BeginInvoke(new MonitoredItemNotificationEventHandler(Item_Notification), monitoredItem, e);
            }
            else
            {
                var itemLV = (ListViewItem)itemLog.Handle;
                if (itemLV == null)
                {
                    return;
                }
                var notification = (MonitoredItemNotification)monitoredItem.LastValue;
                itemLV.SubItems[2].Text = Utils.Format("{0}", notification.Value.WrappedValue);
                itemLV.SubItems[3].Text = Utils.Format("{0}", notification.Value.StatusCode);
                if (notification.Value.StatusCode.ToString() == "Good")
                {
                    itemLV.SubItems[3].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    itemLV.SubItems[3].ForeColor = System.Drawing.Color.Red;
                }
                itemLV.SubItems[5].Text = Utils.Format("{0:dd/MM/yyyy}", notification.Value.SourceTimestamp.ToLocalTime());
                itemLV.SubItems[4].Text = Utils.Format("{0:HH:mm:ss}", notification.Value.SourceTimestamp.ToLocalTime());

                if (ServiceResult.IsBad(monitoredItem.Status.Error))
                {
                    itemLV.SubItems[6].Text = monitoredItem.Status.Error.StatusCode.ToString();
                }
            }

        }

        private void preferencesBTN_Click(object sender, EventArgs e)
        {
            var selectedNode = itemsTV.SelectedNode;
            if (selectedNode == null || selectedNode.Tag == null)
            {
                return;
            }
            if(selectedNode.Tag.GetType() == typeof(ServerLog))
            {
                var server = (ServerLog)selectedNode.Tag;
                using (var frm = new IAADL_App.Forms.ServerForm())
                {
                    frm.EditServerDialog(server);
                    selectedNode.Text = server.Name;
                }
            }
            else if(selectedNode.Tag.GetType() == typeof(GroupLog))
            {
                var group = (GroupLog)selectedNode.Tag;
                var editGroupForm = new GroupForm(group);
                if(editGroupForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                // add node.
                selectedNode.Text = group.Name;
            }

        }

        /// <summary>
        /// Ensures the correct node is selected before displaying the context menu.
        /// </summary>
        private void ItemsTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                itemsTV.SelectedNode = itemsTV.GetNodeAt(e.X, e.Y);
                if(e.Button == MouseButtons.Right && itemsTV.SelectedNode != null)
                {
                    contextMenuStrip1.Show(itemsTV, e.Location);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = itemsTV.SelectedNode;
                if (selectedNode == null)
                {
                    return;
                }

                if (selectedNode.Tag.GetType() == typeof(ServerLog))
                {
                    var server = (ServerLog)selectedNode.Tag;
                    server.Connection.Disconnect();
                    //server.Connection.ServerStatusControl.Text = "";
                    //server.Connection.StatusUpateTimeControl.Text = "";

                    foreach(var group in server.GroupLogs)
                    {
                        if (group.IsLogging)
                        {
                            group.StopLogging();
                        }
                    }
                    server.Connection.Disconnect();
                    //server.Connection.Dispose();
                    m_servers.Remove(server);
                }
                else if (selectedNode.Tag.GetType() == typeof(GroupLog))
                {
                    var group = (GroupLog)selectedNode.Tag;
                    var server = (ServerLog)selectedNode.Parent.Tag;
                    if(group.IsLogging)
                    {
                        group.StopLogging();
                    }
                    server.GroupLogs.Remove(group);
                }
                else if (selectedNode.Tag.GetType() == typeof(ItemLog))
                {
                    var group = (GroupLog)selectedNode.Parent.Tag;
                    var itemLog = (ItemLog)selectedNode.Tag;

                    group.DeleteMonitoredItem(itemLog);
                }

                selectedNode.Remove();
                splitContainer1.Panel2.Controls.Clear();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            preferencesBTN_Click(sender, e);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedNode = itemsTV.SelectedNode;
                if (selectedNode == null || selectedNode.Tag == null)
                {
                    newServerBTN_Click(sender, e);
                    return;
                }

                if (selectedNode.Tag.GetType() == typeof(ServerLog))
                {
                    var server = (ServerLog)selectedNode.Tag;
                    newGroupBTN_Click(sender, e);
                }
                else if (selectedNode.Tag.GetType() == typeof(GroupLog))
                {
                    var group = (GroupLog)selectedNode.Tag;
                    newItemBTN_Click(sender, e);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.CommonApplicationData), @"manuel.pdf"));
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void saveThisAsServiceConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var settingsConfigPath = Path.Combine(Environment.GetFolderPath(
                      Environment.SpecialFolder.CommonApplicationData), @"IAADL\Service.Parameters.json");
                ConfigFile.SaveToFile(m_servers, settingsConfigPath);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void clearServiceConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                    var settingsConfigPath = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.CommonApplicationData), @"IAADL\Service.Parameters.json");
                if (File.Exists(settingsConfigPath))
                {
                    // If file found, delete it    
                    File.Delete(settingsConfigPath);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
    }

    #endregion
}
