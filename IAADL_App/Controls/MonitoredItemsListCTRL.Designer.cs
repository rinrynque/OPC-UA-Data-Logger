namespace IAADL_App.Controls
{
    partial class MonitoredItemsListCTRL
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
            this.MonitoredItemsLV = new System.Windows.Forms.ListView();
            this.MonitoredItemIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VariableNameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualityCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimestampCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastOperationStatusCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // MonitoredItemsLV
            // 
            this.MonitoredItemsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MonitoredItemIdCH,
            this.VariableNameCH,
            this.ValueCH,
            this.QualityCH,
            this.TimestampCH,
            this.DateCH,
            this.LastOperationStatusCH});
            this.MonitoredItemsLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonitoredItemsLV.FullRowSelect = true;
            this.MonitoredItemsLV.Location = new System.Drawing.Point(0, 0);
            this.MonitoredItemsLV.Name = "MonitoredItemsLV";
            this.MonitoredItemsLV.Size = new System.Drawing.Size(450, 150);
            this.MonitoredItemsLV.TabIndex = 3;
            this.MonitoredItemsLV.UseCompatibleStateImageBehavior = false;
            this.MonitoredItemsLV.View = System.Windows.Forms.View.Details;
            // 
            // MonitoredItemIdCH
            // 
            this.MonitoredItemIdCH.Text = "ID";
            this.MonitoredItemIdCH.Width = 40;
            // 
            // VariableNameCH
            // 
            this.VariableNameCH.Text = "Variable";
            this.VariableNameCH.Width = 100;
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "Value";
            // 
            // QualityCH
            // 
            this.QualityCH.Text = "Quality";
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            this.TimestampCH.Width = 75;
            // 
            // DateCH
            // 
            this.DateCH.Text = "Date";
            this.DateCH.Width = 80;
            // 
            // LastOperationStatusCH
            // 
            this.LastOperationStatusCH.Text = "Last Error";
            this.LastOperationStatusCH.Width = 109;
            // 
            // MonitoredItemsListCTRL
            // 
            this.Controls.Add(this.MonitoredItemsLV);
            this.Name = "MonitoredItemsListCTRL";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView MonitoredItemsLV;
        private System.Windows.Forms.ColumnHeader MonitoredItemIdCH;
        private System.Windows.Forms.ColumnHeader VariableNameCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.ColumnHeader QualityCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
        private System.Windows.Forms.ColumnHeader DateCH;
        private System.Windows.Forms.ColumnHeader LastOperationStatusCH;
    }
}
