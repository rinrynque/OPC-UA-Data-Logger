namespace IAADL_App.Forms
{
    partial class ServerForm
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
            this.ServerOptionsPNL = new System.Windows.Forms.Panel();
            this.OKBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.discoverBTN = new System.Windows.Forms.Button();
            this.serverURITB = new System.Windows.Forms.TextBox();
            this.serverURILBL = new System.Windows.Forms.Label();
            this.serverNameTB = new System.Windows.Forms.TextBox();
            this.serverNameLBL = new System.Windows.Forms.Label();
            this.ServerOptionsPNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerOptionsPNL
            // 
            this.ServerOptionsPNL.Controls.Add(this.OKBTN);
            this.ServerOptionsPNL.Controls.Add(this.cancelBTN);
            this.ServerOptionsPNL.Controls.Add(this.discoverBTN);
            this.ServerOptionsPNL.Controls.Add(this.serverURITB);
            this.ServerOptionsPNL.Controls.Add(this.serverURILBL);
            this.ServerOptionsPNL.Controls.Add(this.serverNameTB);
            this.ServerOptionsPNL.Controls.Add(this.serverNameLBL);
            this.ServerOptionsPNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerOptionsPNL.Location = new System.Drawing.Point(0, 0);
            this.ServerOptionsPNL.Name = "ServerOptionsPNL";
            this.ServerOptionsPNL.Size = new System.Drawing.Size(584, 201);
            this.ServerOptionsPNL.TabIndex = 0;
            // 
            // OKBTN
            // 
            this.OKBTN.Location = new System.Drawing.Point(375, 157);
            this.OKBTN.Name = "OKBTN";
            this.OKBTN.Size = new System.Drawing.Size(95, 32);
            this.OKBTN.TabIndex = 6;
            this.OKBTN.Text = "OK";
            this.OKBTN.UseVisualStyleBackColor = true;
            this.OKBTN.Click += new System.EventHandler(this.OKBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(476, 157);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(95, 32);
            this.cancelBTN.TabIndex = 5;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // discoverBTN
            // 
            this.discoverBTN.Location = new System.Drawing.Point(13, 105);
            this.discoverBTN.Name = "discoverBTN";
            this.discoverBTN.Size = new System.Drawing.Size(168, 32);
            this.discoverBTN.TabIndex = 0;
            this.discoverBTN.Text = "Discover Servers";
            this.discoverBTN.UseVisualStyleBackColor = true;
            this.discoverBTN.Click += new System.EventHandler(this.discoverBTN_Click);
            // 
            // serverURITB
            // 
            this.serverURITB.Location = new System.Drawing.Point(13, 76);
            this.serverURITB.Name = "serverURITB";
            this.serverURITB.Size = new System.Drawing.Size(558, 22);
            this.serverURITB.TabIndex = 3;
            // 
            // serverURILBL
            // 
            this.serverURILBL.AutoSize = true;
            this.serverURILBL.Location = new System.Drawing.Point(16, 56);
            this.serverURILBL.Name = "serverURILBL";
            this.serverURILBL.Size = new System.Drawing.Size(85, 17);
            this.serverURILBL.TabIndex = 2;
            this.serverURILBL.Text = "Server URI :";
            // 
            // serverNameTB
            // 
            this.serverNameTB.Location = new System.Drawing.Point(13, 29);
            this.serverNameTB.Name = "serverNameTB";
            this.serverNameTB.Size = new System.Drawing.Size(558, 22);
            this.serverNameTB.TabIndex = 1;
            // 
            // serverNameLBL
            // 
            this.serverNameLBL.AutoSize = true;
            this.serverNameLBL.Location = new System.Drawing.Point(16, 9);
            this.serverNameLBL.Name = "serverNameLBL";
            this.serverNameLBL.Size = new System.Drawing.Size(99, 17);
            this.serverNameLBL.TabIndex = 0;
            this.serverNameLBL.Text = "Server Name :";
            // 
            // AddServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 201);
            this.Controls.Add(this.ServerOptionsPNL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AddServerForm";
            this.Text = "Server Properties";
            this.ServerOptionsPNL.ResumeLayout(false);
            this.ServerOptionsPNL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ServerOptionsPNL;
        private System.Windows.Forms.TextBox serverNameTB;
        private System.Windows.Forms.Label serverNameLBL;
        private System.Windows.Forms.TextBox serverURITB;
        private System.Windows.Forms.Label serverURILBL;
        private System.Windows.Forms.Button discoverBTN;
        private System.Windows.Forms.Button OKBTN;
        private System.Windows.Forms.Button cancelBTN;
    }
}