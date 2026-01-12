namespace DVLD_WindowsForms.Screens.DetainedLicenses
{
    partial class DetainedLicensesManagementScreen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextPesonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.contextShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.contextShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1274, 12);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(433, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(360, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "Detained Licenses Management";
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvDetainedLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainedLicenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvDetainedLicenses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDetainedLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmsApplications;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainedLicenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainedLicenses.EnableHeadersVisualStyles = false;
            this.dgvDetainedLicenses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(11, 353);
            this.dgvDetainedLicenses.MultiSelect = false;
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1322, 387);
            this.dgvDetainedLicenses.TabIndex = 8;
            // 
            // cmsApplications
            // 
            this.cmsApplications.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextPesonDetails,
            this.contextShowDetails,
            this.contextShowPersonLicenseHistory,
            this.toolStripMenuItem1,
            this.contextReleaseDetainedLicense});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(286, 184);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // contextPesonDetails
            // 
            this.contextPesonDetails.Image = global::DVLD_WindowsForms.Properties.Resources.PersonDetails_32;
            this.contextPesonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextPesonDetails.Name = "contextPesonDetails";
            this.contextPesonDetails.Size = new System.Drawing.Size(285, 38);
            this.contextPesonDetails.Text = "Show Person Details";
            this.contextPesonDetails.Click += new System.EventHandler(this.contextPesonDetails_Click);
            // 
            // contextShowDetails
            // 
            this.contextShowDetails.Image = global::DVLD_WindowsForms.Properties.Resources.LocalDriving_License;
            this.contextShowDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextShowDetails.Name = "contextShowDetails";
            this.contextShowDetails.Size = new System.Drawing.Size(285, 38);
            this.contextShowDetails.Text = "&Show License Details";
            this.contextShowDetails.Click += new System.EventHandler(this.contextShowDetails_Click);
            // 
            // contextShowPersonLicenseHistory
            // 
            this.contextShowPersonLicenseHistory.Image = global::DVLD_WindowsForms.Properties.Resources.PersonLicenseHistory_32;
            this.contextShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextShowPersonLicenseHistory.Name = "contextShowPersonLicenseHistory";
            this.contextShowPersonLicenseHistory.Size = new System.Drawing.Size(285, 38);
            this.contextShowPersonLicenseHistory.Text = "Show Person License History";
            this.contextShowPersonLicenseHistory.Click += new System.EventHandler(this.contextShowPersonLicenseHistory_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(282, 6);
            // 
            // contextReleaseDetainedLicense
            // 
            this.contextReleaseDetainedLicense.Image = global::DVLD_WindowsForms.Properties.Resources.Release_Detained_License_32;
            this.contextReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextReleaseDetainedLicense.Name = "contextReleaseDetainedLicense";
            this.contextReleaseDetainedLicense.Size = new System.Drawing.Size(285, 38);
            this.contextReleaseDetainedLicense.Text = "Release Detained License";
            this.contextReleaseDetainedLicense.Click += new System.EventHandler(this.contextReleaseDetainedLicense_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Image = global::DVLD_WindowsForms.Properties.Resources.Detain_32;
            this.btnDetainLicense.Location = new System.Drawing.Point(1271, 299);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(62, 48);
            this.btnDetainLicense.TabIndex = 9;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Image = global::DVLD_WindowsForms.Properties.Resources.Release_Detained_License_32;
            this.btnRelease.Location = new System.Drawing.Point(1203, 299);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(62, 48);
            this.btnRelease.TabIndex = 10;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // DetainedLicensesManagementScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1328, 753);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "DetainedLicensesManagementScreen";
            this.Text = "DetainedLicensesManagement";
            this.Load += new System.EventHandler(this.DetainedLicensesManagement_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.dgvDetainedLicenses, 0);
            this.Controls.SetChildIndex(this.btnDetainLicense, 0);
            this.Controls.SetChildIndex(this.btnRelease, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem contextPesonDetails;
        private System.Windows.Forms.ToolStripMenuItem contextShowDetails;
        private System.Windows.Forms.ToolStripMenuItem contextShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contextReleaseDetainedLicense;
    }
}