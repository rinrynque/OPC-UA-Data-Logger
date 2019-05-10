using IAADL_Core;
using Opc.Ua;
using Opc.Ua.Client.Controls;
using Quickstarts;
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
    public partial class ObjectsForm : Form
    {
        private System.Windows.Forms.ImageList imageList1;

        public ObjectsForm()
        {
            InitializeComponent();
            imageList1 = new ImageList();

            imageList1.Images.Add("no_icon", Properties.Resources.no_image_dots);
            imageList1.Images.Add("label_icon", Properties.Resources.label_icon);
            BrowseNodesTV.ImageList = imageList1;
            BrowseNodesTV.ImageList = imageList1;
        }
        private GroupLog m_groupLog;

        public async Task showForm(GroupLog group)
        {
            m_groupLog = group;
            await PopulateBranch(ObjectIds.ObjectsFolder, BrowseNodesTV.Nodes);

            ShowDialog();
        }


        /// <summary>
        /// Populates the branch in the tree view.
        /// </summary>
        /// <param name="sourceId">The NodeId of the Node to browse.</param>
        /// <param name="nodes">The node collect to populate.</param>
        private async Task PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            try
            {
                nodes.Clear();

                // find all of the components of the node.
                BrowseDescription nodeToBrowse1 = new BrowseDescription();

                nodeToBrowse1.NodeId = sourceId;
                nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
                nodeToBrowse1.IncludeSubtypes = true;
                nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

                // find all nodes organized by the node.
                BrowseDescription nodeToBrowse2 = new BrowseDescription();

                nodeToBrowse2.NodeId = sourceId;
                nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
                nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
                nodeToBrowse2.IncludeSubtypes = true;
                nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable);
                nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

                BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
                nodesToBrowse.Add(nodeToBrowse1);
                nodesToBrowse.Add(nodeToBrowse2);

                Cursor.Current = Cursors.WaitCursor;
                // fetch references from the server.
                ReferenceDescriptionCollection references = await Task.Run(() => FormUtils.Browse(m_groupLog.Server.Connection.Session, nodesToBrowse, false));
                Cursor.Current = Cursors.Default;

                // process results.
                for (int ii = 0; ii < references.Count; ii++)
                {
                    ReferenceDescription target = references[ii];

                    // add node.
                    TreeNode child = new TreeNode(Utils.Format("{0}", target));
                    child.Tag = target;

                    child.Nodes.Add(new TreeNode());
                    nodes.Add(child);

                    if (target.NodeClass == NodeClass.Variable)
                    {
                        child.ImageKey = "label_icon";
                        child.SelectedImageKey = "label_icon";
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Fetches the children for a node the first time the node is expanded in the tree view.
        /// </summary>
        private void BrowseNodesTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != String.Empty)
                {
                    return;
                }

                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        /// <summary>
        /// Updates the display after a node is selected.
        /// </summary>
        private void BrowseNodesTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.ImageKey == "label_icon")
                {
                    okBTN.Enabled = true;
                    addBTN.Enabled = true;
                }
                else
                {
                    okBTN.Enabled = false;
                    addBTN.Enabled = false;
                }
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Ensures the correct node is selected before displaying the context menu.
        /// </summary>
        private void BrowseNodesTV_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                BrowseNodesTV.SelectedNode = BrowseNodesTV.GetNodeAt(e.X, e.Y);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void closeBTN_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void okBTN_Click(object sender, EventArgs e)
        {
            addBTN_Click(sender, e);
            this.Hide();
        }

        private void addBTN_Click(object sender, EventArgs e)
        {

            try
            {
                // check if operation is currently allowed.
                if (m_groupLog.Server.Connection.Session == null || BrowseNodesTV.SelectedNode == null)
                {
                    return;
                }

                // can only subscribe to local variables. 
                ReferenceDescription reference = (ReferenceDescription)BrowseNodesTV.SelectedNode.Tag;

                if (reference.NodeId.IsAbsolute || reference.NodeClass != NodeClass.Variable)
                {
                    return;
                }

                m_groupLog.CreateMonitoredItem((NodeId)reference.NodeId, Utils.Format("{0}", reference));
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
    }
}
