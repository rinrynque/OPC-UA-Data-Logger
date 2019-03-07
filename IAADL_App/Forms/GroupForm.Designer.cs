namespace IAADL_App.Forms
{
    partial class GroupForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalTP = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nameLBL = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.saveToLBL = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.filePathTB = new System.Windows.Forms.TextBox();
            this.selectFileCtrl1 = new IAADL_App.Controls.SelectFileSaveCTRL();
            this.label1 = new System.Windows.Forms.Label();
            this.updatePeriodNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.logRateNUD = new System.Windows.Forms.NumericUpDown();
            this.advancedTP = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.appendDateCB = new System.Windows.Forms.CheckBox();
            this.appendTimeCB = new System.Windows.Forms.CheckBox();
            this.afterDurationCB = new System.Windows.Forms.CheckBox();
            this.afterDurationNUD = new System.Windows.Forms.NumericUpDown();
            this.okBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.generalTP.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePeriodNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logRateNUD)).BeginInit();
            this.advancedTP.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afterDurationNUD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTP);
            this.tabControl.Controls.Add(this.advancedTP);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(459, 293);
            this.tabControl.TabIndex = 8;
            // 
            // generalTP
            // 
            this.generalTP.Controls.Add(this.flowLayoutPanel1);
            this.generalTP.Location = new System.Drawing.Point(4, 22);
            this.generalTP.Name = "generalTP";
            this.generalTP.Padding = new System.Windows.Forms.Padding(3);
            this.generalTP.Size = new System.Drawing.Size(451, 267);
            this.generalTP.TabIndex = 0;
            this.generalTP.Text = "General";
            this.generalTP.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.nameLBL);
            this.flowLayoutPanel1.Controls.Add(this.nameTB);
            this.flowLayoutPanel1.Controls.Add(this.saveToLBL);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.updatePeriodNUD);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.logRateNUD);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(15, 5, 15, 15);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 261);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // nameLBL
            // 
            this.nameLBL.AutoSize = true;
            this.nameLBL.Location = new System.Drawing.Point(20, 10);
            this.nameLBL.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.nameLBL.Name = "nameLBL";
            this.nameLBL.Size = new System.Drawing.Size(35, 13);
            this.nameLBL.TabIndex = 0;
            this.nameLBL.Text = "Name";
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(20, 26);
            this.nameTB.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(396, 20);
            this.nameTB.TabIndex = 1;
            // 
            // saveToLBL
            // 
            this.saveToLBL.AutoSize = true;
            this.saveToLBL.Location = new System.Drawing.Point(20, 54);
            this.saveToLBL.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.saveToLBL.Name = "saveToLBL";
            this.saveToLBL.Size = new System.Drawing.Size(48, 13);
            this.saveToLBL.TabIndex = 2;
            this.saveToLBL.Text = "Save To";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.filePathTB);
            this.flowLayoutPanel2.Controls.Add(this.selectFileCtrl1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(18, 70);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(398, 30);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // filePathTB
            // 
            this.filePathTB.Location = new System.Drawing.Point(3, 3);
            this.filePathTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.filePathTB.Name = "filePathTB";
            this.filePathTB.Size = new System.Drawing.Size(339, 20);
            this.filePathTB.TabIndex = 4;
            // 
            // selectFileCtrl1
            // 
            this.selectFileCtrl1.CurrentDirectory = null;
            this.selectFileCtrl1.DefaultExt = null;
            this.selectFileCtrl1.FilePathControl = null;
            this.selectFileCtrl1.Filter = null;
            this.selectFileCtrl1.Location = new System.Drawing.Point(348, 0);
            this.selectFileCtrl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.selectFileCtrl1.Name = "selectFileCtrl1";
            this.selectFileCtrl1.Size = new System.Drawing.Size(24, 24);
            this.selectFileCtrl1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Update Period (ms)";
            // 
            // updatePeriodNUD
            // 
            this.updatePeriodNUD.Location = new System.Drawing.Point(18, 119);
            this.updatePeriodNUD.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
            this.updatePeriodNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updatePeriodNUD.Name = "updatePeriodNUD";
            this.updatePeriodNUD.Size = new System.Drawing.Size(120, 20);
            this.updatePeriodNUD.TabIndex = 8;
            this.updatePeriodNUD.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Log Data Rate (ms)";
            // 
            // logRateNUD
            // 
            this.logRateNUD.Location = new System.Drawing.Point(18, 158);
            this.logRateNUD.Maximum = new decimal(new int[] {
            36000000,
            0,
            0,
            0});
            this.logRateNUD.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.logRateNUD.Name = "logRateNUD";
            this.logRateNUD.Size = new System.Drawing.Size(120, 20);
            this.logRateNUD.TabIndex = 11;
            this.logRateNUD.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // advancedTP
            // 
            this.advancedTP.Controls.Add(this.flowLayoutPanel3);
            this.advancedTP.Location = new System.Drawing.Point(4, 22);
            this.advancedTP.Name = "advancedTP";
            this.advancedTP.Padding = new System.Windows.Forms.Padding(3);
            this.advancedTP.Size = new System.Drawing.Size(451, 267);
            this.advancedTP.TabIndex = 1;
            this.advancedTP.Text = "Advanced";
            this.advancedTP.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.appendDateCB);
            this.flowLayoutPanel3.Controls.Add(this.appendTimeCB);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.afterDurationCB);
            this.flowLayoutPanel3.Controls.Add(this.afterDurationNUD);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(445, 261);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Log File Name";
            // 
            // appendDateCB
            // 
            this.appendDateCB.AutoSize = true;
            this.appendDateCB.Checked = true;
            this.appendDateCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendDateCB.Location = new System.Drawing.Point(18, 31);
            this.appendDateCB.Name = "appendDateCB";
            this.appendDateCB.Size = new System.Drawing.Size(89, 17);
            this.appendDateCB.TabIndex = 0;
            this.appendDateCB.Text = "Append Date";
            this.appendDateCB.UseVisualStyleBackColor = true;
            // 
            // appendTimeCB
            // 
            this.appendTimeCB.AutoSize = true;
            this.appendTimeCB.Checked = true;
            this.appendTimeCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendTimeCB.Location = new System.Drawing.Point(18, 54);
            this.appendTimeCB.Name = "appendTimeCB";
            this.appendTimeCB.Size = new System.Drawing.Size(89, 17);
            this.appendTimeCB.TabIndex = 2;
            this.appendTimeCB.Text = "Append Time";
            this.appendTimeCB.UseVisualStyleBackColor = true;
            // 
            // afterDurationCB
            // 
            this.afterDurationCB.AutoSize = true;
            this.afterDurationCB.Location = new System.Drawing.Point(18, 101);
            this.afterDurationCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 1);
            this.afterDurationCB.Name = "afterDurationCB";
            this.afterDurationCB.Size = new System.Drawing.Size(147, 17);
            this.afterDurationCB.TabIndex = 5;
            this.afterDurationCB.Text = "After Duration (in minutes)";
            this.afterDurationCB.UseVisualStyleBackColor = true;
            // 
            // afterDurationNUD
            // 
            this.afterDurationNUD.Location = new System.Drawing.Point(18, 119);
            this.afterDurationNUD.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.afterDurationNUD.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.afterDurationNUD.Name = "afterDurationNUD";
            this.afterDurationNUD.Size = new System.Drawing.Size(120, 20);
            this.afterDurationNUD.TabIndex = 9;
            this.afterDurationNUD.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // okBTN
            // 
            this.okBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBTN.Location = new System.Drawing.Point(372, 299);
            this.okBTN.Name = "okBTN";
            this.okBTN.Size = new System.Drawing.Size(75, 23);
            this.okBTN.TabIndex = 6;
            this.okBTN.Text = "OK";
            this.okBTN.UseVisualStyleBackColor = true;
            this.okBTN.Click += new System.EventHandler(this.okBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.okBTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 334);
            this.panel1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "New Log File Creation";
            // 
            // GroupForm
            // 
            this.ClientSize = new System.Drawing.Size(459, 334);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GroupForm";
            this.Text = "Group Settings";
            this.tabControl.ResumeLayout(false);
            this.generalTP.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePeriodNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logRateNUD)).EndInit();
            this.advancedTP.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afterDurationNUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTP;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label nameLBL;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label saveToLBL;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox filePathTB;
        private Controls.SelectFileSaveCTRL selectFileCtrl1;
        private System.Windows.Forms.TabPage advancedTP;
        private System.Windows.Forms.Button okBTN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown updatePeriodNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown logRateNUD;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox appendDateCB;
        private System.Windows.Forms.CheckBox appendTimeCB;
        private System.Windows.Forms.CheckBox afterDurationCB;
        private System.Windows.Forms.NumericUpDown afterDurationNUD;
        private System.Windows.Forms.Label label4;
    }
}