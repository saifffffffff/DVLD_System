namespace DVLD_WindowsForms.UserControls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpDriverLicense = new System.Windows.Forms.GroupBox();
            this.DriverLicenses = new System.Windows.Forms.TabControl();
            this.tcLocal = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStripForLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextShowLicenseInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tcInternational = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStripForInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextShowInternationalLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.gpDriverLicense.SuspendLayout();
            this.DriverLicenses.SuspendLayout();
            this.tcLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.contextMenuStripForLocalLicenses.SuspendLayout();
            this.tcInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).BeginInit();
            this.contextMenuStripForInternationalLicense.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpDriverLicense
            // 
            this.gpDriverLicense.Controls.Add(this.DriverLicenses);
            this.gpDriverLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDriverLicense.ForeColor = System.Drawing.Color.White;
            this.gpDriverLicense.Location = new System.Drawing.Point(3, 3);
            this.gpDriverLicense.Name = "gpDriverLicense";
            this.gpDriverLicense.Size = new System.Drawing.Size(1112, 318);
            this.gpDriverLicense.TabIndex = 0;
            this.gpDriverLicense.TabStop = false;
            this.gpDriverLicense.Tag = "";
            this.gpDriverLicense.Text = "Driver Licenses";
            // 
            // DriverLicenses
            // 
            this.DriverLicenses.Controls.Add(this.tcLocal);
            this.DriverLicenses.Controls.Add(this.tcInternational);
            this.DriverLicenses.Location = new System.Drawing.Point(11, 23);
            this.DriverLicenses.Name = "DriverLicenses";
            this.DriverLicenses.SelectedIndex = 0;
            this.DriverLicenses.Size = new System.Drawing.Size(1090, 286);
            this.DriverLicenses.TabIndex = 0;
            // 
            // tcLocal
            // 
            this.tcLocal.BackColor = System.Drawing.SystemColors.WindowText;
            this.tcLocal.Controls.Add(this.label2);
            this.tcLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tcLocal.Location = new System.Drawing.Point(4, 27);
            this.tcLocal.Name = "tcLocal";
            this.tcLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tcLocal.Size = new System.Drawing.Size(1082, 255);
            this.tcLocal.TabIndex = 0;
            this.tcLocal.Text = "Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Local Licenses History";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvLocalLicensesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicensesHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvLocalLicensesHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLocalLicensesHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.contextMenuStripForLocalLicenses;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalLicensesHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLocalLicensesHistory.EnableHeadersVisualStyles = false;
            this.dgvLocalLicensesHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(6, 49);
            this.dgvLocalLicensesHistory.MultiSelect = false;
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1068, 200);
            this.dgvLocalLicensesHistory.TabIndex = 5;
            // 
            // contextMenuStripForLocalLicenses
            // 
            this.contextMenuStripForLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextShowLicenseInformation});
            this.contextMenuStripForLocalLicenses.Name = "contextMenuStrip";
            this.contextMenuStripForLocalLicenses.Size = new System.Drawing.Size(228, 42);
            // 
            // contextShowLicenseInformation
            // 
            this.contextShowLicenseInformation.Image = global::DVLD_WindowsForms.Properties.Resources.LocalDriving_License;
            this.contextShowLicenseInformation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextShowLicenseInformation.Name = "contextShowLicenseInformation";
            this.contextShowLicenseInformation.Size = new System.Drawing.Size(227, 38);
            this.contextShowLicenseInformation.Text = "Show License Information";
            this.contextShowLicenseInformation.Click += new System.EventHandler(this.contextShowLicenseInformation_Click);
            // 
            // tcInternational
            // 
            this.tcInternational.BackColor = System.Drawing.Color.Black;
            this.tcInternational.Controls.Add(this.label1);
            this.tcInternational.Controls.Add(this.dgvInternationalLicensesHistory);
            this.tcInternational.Location = new System.Drawing.Point(4, 27);
            this.tcInternational.Name = "tcInternational";
            this.tcInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tcInternational.Size = new System.Drawing.Size(1082, 255);
            this.tcInternational.TabIndex = 1;
            this.tcInternational.Text = "International";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(-1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = " International Licenses History";
            // 
            // dgvInternationalLicensesHistory
            // 
            this.dgvInternationalLicensesHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesHistory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvInternationalLicensesHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInternationalLicensesHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicensesHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInternationalLicensesHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvInternationalLicensesHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvInternationalLicensesHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInternationalLicensesHistory.ContextMenuStrip = this.contextMenuStripForInternationalLicense;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicensesHistory.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInternationalLicensesHistory.EnableHeadersVisualStyles = false;
            this.dgvInternationalLicensesHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvInternationalLicensesHistory.Location = new System.Drawing.Point(6, 49);
            this.dgvInternationalLicensesHistory.MultiSelect = false;
            this.dgvInternationalLicensesHistory.Name = "dgvInternationalLicensesHistory";
            this.dgvInternationalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInternationalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicensesHistory.Size = new System.Drawing.Size(1070, 200);
            this.dgvInternationalLicensesHistory.TabIndex = 16;
            // 
            // contextMenuStripForInternationalLicense
            // 
            this.contextMenuStripForInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextShowInternationalLicenseInfo});
            this.contextMenuStripForInternationalLicense.Name = "contextMenuStripForInternationalLicense";
            this.contextMenuStripForInternationalLicense.Size = new System.Drawing.Size(228, 42);
            // 
            // contextShowInternationalLicenseInfo
            // 
            this.contextShowInternationalLicenseInfo.Image = global::DVLD_WindowsForms.Properties.Resources.LocalDriving_License;
            this.contextShowInternationalLicenseInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextShowInternationalLicenseInfo.Name = "contextShowInternationalLicenseInfo";
            this.contextShowInternationalLicenseInfo.Size = new System.Drawing.Size(227, 38);
            this.contextShowInternationalLicenseInfo.Text = "Show License Information";
            this.contextShowInternationalLicenseInfo.Click += new System.EventHandler(this.contextShowInternationalLicenseInfo_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gpDriverLicense);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1128, 354);
            this.gpDriverLicense.ResumeLayout(false);
            this.DriverLicenses.ResumeLayout(false);
            this.tcLocal.ResumeLayout(false);
            this.tcLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.contextMenuStripForLocalLicenses.ResumeLayout(false);
            this.tcInternational.ResumeLayout(false);
            this.tcInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesHistory)).EndInit();
            this.contextMenuStripForInternationalLicense.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpDriverLicense;
        private System.Windows.Forms.TabControl DriverLicenses;
        private System.Windows.Forms.TabPage tcLocal;
        private System.Windows.Forms.TabPage tcInternational;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesHistory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForLocalLicenses;
        private System.Windows.Forms.ToolStripMenuItem contextShowLicenseInformation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripForInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem contextShowInternationalLicenseInfo;
    }
}
