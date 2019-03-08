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

namespace IAADL_App
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Serveurs");
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionTS = new System.Windows.Forms.ToolStrip();
            this.newFileBTN = new System.Windows.Forms.ToolStripButton();
            this.openFileBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newServerBTN = new System.Windows.Forms.ToolStripButton();
            this.newGroupBTN = new System.Windows.Forms.ToolStripButton();
            this.newItemBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.startLoggingBTN = new System.Windows.Forms.ToolStripButton();
            this.pauseLoggingBTN = new System.Windows.Forms.ToolStripButton();
            this.stopLoggingBTN = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.itemsTV = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.actionTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusBar.Location = new System.Drawing.Point(0, 524);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(884, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newConfigFile);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.loadConfigFile);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveConfigFile);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // actionTS
            // 
            this.actionTS.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.actionTS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.actionTS.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.actionTS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileBTN,
            this.openFileBTN,
            this.toolStripSeparator3,
            this.newServerBTN,
            this.newGroupBTN,
            this.newItemBTN,
            this.toolStripSeparator4,
            this.preferencesBTN,
            this.toolStripSeparator5,
            this.startLoggingBTN,
            this.pauseLoggingBTN,
            this.stopLoggingBTN});
            this.actionTS.Location = new System.Drawing.Point(0, 24);
            this.actionTS.Name = "actionTS";
            this.actionTS.Size = new System.Drawing.Size(884, 27);
            this.actionTS.TabIndex = 4;
            this.actionTS.Text = "Actions";
            // 
            // newFileBTN
            // 
            this.newFileBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileBTN.Image = ((System.Drawing.Image)(resources.GetObject("newFileBTN.Image")));
            this.newFileBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileBTN.Name = "newFileBTN";
            this.newFileBTN.Size = new System.Drawing.Size(24, 24);
            this.newFileBTN.Text = "New File";
            this.newFileBTN.Click += new System.EventHandler(this.newConfigFile);
            // 
            // openFileBTN
            // 
            this.openFileBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileBTN.Image = ((System.Drawing.Image)(resources.GetObject("openFileBTN.Image")));
            this.openFileBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileBTN.Name = "openFileBTN";
            this.openFileBTN.Size = new System.Drawing.Size(24, 24);
            this.openFileBTN.Text = "Open File";
            this.openFileBTN.Click += new System.EventHandler(this.loadConfigFile);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // newServerBTN
            // 
            this.newServerBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newServerBTN.Image = ((System.Drawing.Image)(resources.GetObject("newServerBTN.Image")));
            this.newServerBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newServerBTN.Name = "newServerBTN";
            this.newServerBTN.Size = new System.Drawing.Size(24, 24);
            this.newServerBTN.Text = "New Server";
            this.newServerBTN.Click += new System.EventHandler(this.newServerBTN_Click);
            // 
            // newGroupBTN
            // 
            this.newGroupBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newGroupBTN.Enabled = false;
            this.newGroupBTN.Image = ((System.Drawing.Image)(resources.GetObject("newGroupBTN.Image")));
            this.newGroupBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newGroupBTN.Name = "newGroupBTN";
            this.newGroupBTN.Size = new System.Drawing.Size(24, 24);
            this.newGroupBTN.Text = "New Group";
            this.newGroupBTN.Click += new System.EventHandler(this.newGroupBTN_Click);
            // 
            // newItemBTN
            // 
            this.newItemBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newItemBTN.Enabled = false;
            this.newItemBTN.Image = ((System.Drawing.Image)(resources.GetObject("newItemBTN.Image")));
            this.newItemBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newItemBTN.Name = "newItemBTN";
            this.newItemBTN.Size = new System.Drawing.Size(24, 24);
            this.newItemBTN.Text = "New Item";
            this.newItemBTN.Click += new System.EventHandler(this.newItemBTN_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // preferencesBTN
            // 
            this.preferencesBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.preferencesBTN.Enabled = false;
            this.preferencesBTN.Image = ((System.Drawing.Image)(resources.GetObject("preferencesBTN.Image")));
            this.preferencesBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.preferencesBTN.Name = "preferencesBTN";
            this.preferencesBTN.Size = new System.Drawing.Size(24, 24);
            this.preferencesBTN.Text = "Properties";
            this.preferencesBTN.Click += new System.EventHandler(this.preferencesBTN_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // startLoggingBTN
            // 
            this.startLoggingBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startLoggingBTN.Enabled = false;
            this.startLoggingBTN.Image = ((System.Drawing.Image)(resources.GetObject("startLoggingBTN.Image")));
            this.startLoggingBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startLoggingBTN.Name = "startLoggingBTN";
            this.startLoggingBTN.Size = new System.Drawing.Size(24, 24);
            this.startLoggingBTN.Text = "Start Logging";
            this.startLoggingBTN.Click += new System.EventHandler(this.startLoggingBTN_Click);
            // 
            // pauseLoggingBTN
            // 
            this.pauseLoggingBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseLoggingBTN.Enabled = false;
            this.pauseLoggingBTN.Image = ((System.Drawing.Image)(resources.GetObject("pauseLoggingBTN.Image")));
            this.pauseLoggingBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseLoggingBTN.Name = "pauseLoggingBTN";
            this.pauseLoggingBTN.Size = new System.Drawing.Size(24, 24);
            this.pauseLoggingBTN.Text = "Pause Logging";
            this.pauseLoggingBTN.Click += new System.EventHandler(this.pauseLoggingBTN_Click);
            // 
            // stopLoggingBTN
            // 
            this.stopLoggingBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopLoggingBTN.Enabled = false;
            this.stopLoggingBTN.Image = ((System.Drawing.Image)(resources.GetObject("stopLoggingBTN.Image")));
            this.stopLoggingBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopLoggingBTN.Name = "stopLoggingBTN";
            this.stopLoggingBTN.Size = new System.Drawing.Size(24, 24);
            this.stopLoggingBTN.Text = "Stop Logging";
            this.stopLoggingBTN.Click += new System.EventHandler(this.stopLoggingBTN_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemsTV);
            this.splitContainer1.Size = new System.Drawing.Size(884, 473);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 5;
            // 
            // itemsTV
            // 
            this.itemsTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTV.Location = new System.Drawing.Point(0, 0);
            this.itemsTV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.itemsTV.Name = "itemsTV";
            treeNode1.Name = "RootNode";
            treeNode1.Text = "Serveurs";
            this.itemsTV.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.itemsTV.Size = new System.Drawing.Size(435, 473);
            this.itemsTV.TabIndex = 0;
            this.itemsTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.itemsTV_AfterSelect);
            this.itemsTV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemsTV_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.actionTS);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "IAA Data Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.actionTS.ResumeLayout(false);
            this.actionTS.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip actionTS;
        private System.Windows.Forms.ToolStripButton newFileBTN;
        private System.Windows.Forms.ToolStripButton openFileBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton startLoggingBTN;
        private System.Windows.Forms.ToolStripButton pauseLoggingBTN;
        private System.Windows.Forms.ToolStripButton stopLoggingBTN;
        private System.Windows.Forms.ToolStripButton newServerBTN;
        private System.Windows.Forms.ToolStripButton newGroupBTN;
        private System.Windows.Forms.ToolStripButton newItemBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton preferencesBTN;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView itemsTV;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
    }
}
