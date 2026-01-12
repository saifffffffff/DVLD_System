namespace DVLD_WindowsForms.Screens.Applications
{
    partial class LocalDrivingLicenseApplicationsManagementScreen
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
            this.dgvApps = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.contextVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.contextWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.contextIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.contextCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.contextShowLicenseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddLocalDrivingLicenseApplications = new System.Windows.Forms.Button();
            this.mtbSearch = new System.Windows.Forms.MaskedTextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.contextShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApps)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(442, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(349, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Driving License Applications";
            // 
            // dgvApps
            // 
            this.dgvApps.AllowUserToAddRows = false;
            this.dgvApps.AllowUserToDeleteRows = false;
            this.dgvApps.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvApps.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvApps.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvApps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApps.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApps.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApps.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApps.EnableHeadersVisualStyles = false;
            this.dgvApps.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgvApps.Location = new System.Drawing.Point(12, 376);
            this.dgvApps.MultiSelect = false;
            this.dgvApps.Name = "dgvApps";
            this.dgvApps.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(160)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApps.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApps.Size = new System.Drawing.Size(1322, 387);
            this.dgvApps.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextShowDetails,
            this.toolStripMenuItem1,
            this.contextEdit,
            this.contextDelete,
            this.contextScheduleTest,
            this.contextIssueDrivingLicense,
            this.contextCancelApplication,
            this.contextShowLicenseInfo,
            this.contextShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(274, 336);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // contextShowDetails
            // 
            this.contextShowDetails.Image = global::DVLD_WindowsForms.Properties.Resources.PersonDetails_32;
            this.contextShowDetails.Name = "contextShowDetails";
            this.contextShowDetails.Size = new System.Drawing.Size(273, 38);
            this.contextShowDetails.Text = "Show Application Details";
            this.contextShowDetails.Click += new System.EventHandler(this.contextShowDetails_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(270, 6);
            // 
            // contextEdit
            // 
            this.contextEdit.Image = global::DVLD_WindowsForms.Properties.Resources.edit_32;
            this.contextEdit.Name = "contextEdit";
            this.contextEdit.Size = new System.Drawing.Size(273, 38);
            this.contextEdit.Text = "Edit";
            this.contextEdit.Click += new System.EventHandler(this.contextEdit_Click);
            // 
            // contextDelete
            // 
            this.contextDelete.Image = global::DVLD_WindowsForms.Properties.Resources.Delete_32_2;
            this.contextDelete.Name = "contextDelete";
            this.contextDelete.Size = new System.Drawing.Size(273, 38);
            this.contextDelete.Text = "Delete";
            // 
            // contextScheduleTest
            // 
            this.contextScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextVisionTest,
            this.contextWrittenTest,
            this.contextStreetTest});
            this.contextScheduleTest.Image = global::DVLD_WindowsForms.Properties.Resources.Schedule_Test_32;
            this.contextScheduleTest.Name = "contextScheduleTest";
            this.contextScheduleTest.Size = new System.Drawing.Size(273, 38);
            this.contextScheduleTest.Text = "Schedule Tests";
            // 
            // contextVisionTest
            // 
            this.contextVisionTest.Image = global::DVLD_WindowsForms.Properties.Resources.Vision_Test_32;
            this.contextVisionTest.Name = "contextVisionTest";
            this.contextVisionTest.Size = new System.Drawing.Size(212, 38);
            this.contextVisionTest.Text = "Schedule Vision Test";
            this.contextVisionTest.Click += new System.EventHandler(this.contextVisionTest_Click);
            // 
            // contextWrittenTest
            // 
            this.contextWrittenTest.Image = global::DVLD_WindowsForms.Properties.Resources.Written_Test_32;
            this.contextWrittenTest.Name = "contextWrittenTest";
            this.contextWrittenTest.Size = new System.Drawing.Size(212, 38);
            this.contextWrittenTest.Text = "Schedule Written Test";
            this.contextWrittenTest.Click += new System.EventHandler(this.contextWrittenTest_Click);
            // 
            // contextStreetTest
            // 
            this.contextStreetTest.Image = global::DVLD_WindowsForms.Properties.Resources.Street_Test_32;
            this.contextStreetTest.Name = "contextStreetTest";
            this.contextStreetTest.Size = new System.Drawing.Size(212, 38);
            this.contextStreetTest.Text = "Schedule Street Test";
            this.contextStreetTest.Click += new System.EventHandler(this.contextStreetTest_Click);
            // 
            // contextIssueDrivingLicense
            // 
            this.contextIssueDrivingLicense.Image = global::DVLD_WindowsForms.Properties.Resources.IssueDrivingLicense_32;
            this.contextIssueDrivingLicense.Name = "contextIssueDrivingLicense";
            this.contextIssueDrivingLicense.Size = new System.Drawing.Size(273, 38);
            this.contextIssueDrivingLicense.Text = "Issue Driving License (First Time)";
            this.contextIssueDrivingLicense.Click += new System.EventHandler(this.contextIssueDrivingLicense_Click);
            // 
            // contextCancelApplication
            // 
            this.contextCancelApplication.Image = global::DVLD_WindowsForms.Properties.Resources.Delete_32;
            this.contextCancelApplication.Name = "contextCancelApplication";
            this.contextCancelApplication.Size = new System.Drawing.Size(273, 38);
            this.contextCancelApplication.Text = "Cancel Application";
            this.contextCancelApplication.Click += new System.EventHandler(this.contextCancelApplication_Click);
            // 
            // contextShowLicenseInfo
            // 
            this.contextShowLicenseInfo.Image = global::DVLD_WindowsForms.Properties.Resources.LocalDriving_License;
            this.contextShowLicenseInfo.Name = "contextShowLicenseInfo";
            this.contextShowLicenseInfo.Size = new System.Drawing.Size(273, 38);
            this.contextShowLicenseInfo.Text = "Show License Info";
            this.contextShowLicenseInfo.Click += new System.EventHandler(this.contextShowLicenseInfo_Click);
            // 
            // btnAddLocalDrivingLicenseApplications
            // 
            this.btnAddLocalDrivingLicenseApplications.BackColor = System.Drawing.Color.Transparent;
            this.btnAddLocalDrivingLicenseApplications.Image = global::DVLD_WindowsForms.Properties.Resources.New_Application_64;
            this.btnAddLocalDrivingLicenseApplications.Location = new System.Drawing.Point(1258, 294);
            this.btnAddLocalDrivingLicenseApplications.Name = "btnAddLocalDrivingLicenseApplications";
            this.btnAddLocalDrivingLicenseApplications.Size = new System.Drawing.Size(75, 76);
            this.btnAddLocalDrivingLicenseApplications.TabIndex = 5;
            this.btnAddLocalDrivingLicenseApplications.UseVisualStyleBackColor = false;
            this.btnAddLocalDrivingLicenseApplications.Click += new System.EventHandler(this.btnAddLocalDrivingLicenseApplications_Click);
            // 
            // mtbSearch
            // 
            this.mtbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbSearch.Location = new System.Drawing.Point(379, 345);
            this.mtbSearch.Name = "mtbSearch";
            this.mtbSearch.Size = new System.Drawing.Size(210, 26);
            this.mtbSearch.TabIndex = 16;
            this.mtbSearch.TextChanged += new System.EventHandler(this.mtbSearch_TextChanged);
            this.mtbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbSearch_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Local Driving License Application ID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilter.Location = new System.Drawing.Point(126, 345);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(247, 26);
            this.cbFilter.TabIndex = 15;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Location = new System.Drawing.Point(7, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By :";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(379, 345);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(98, 26);
            this.cbStatus.TabIndex = 17;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // contextShowPersonLicenseHistory
            // 
            this.contextShowPersonLicenseHistory.Image = global::DVLD_WindowsForms.Properties.Resources.PersonLicenseHistory_32;
            this.contextShowPersonLicenseHistory.Name = "contextShowPersonLicenseHistory";
            this.contextShowPersonLicenseHistory.Size = new System.Drawing.Size(273, 38);
            this.contextShowPersonLicenseHistory.Text = "Show Person License History";
            this.contextShowPersonLicenseHistory.Click += new System.EventHandler(this.contextShowPersonLicenseHistory_Click);
            // 
            // LocalDrivingLicenseApplicationsManagementScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1328, 753);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.mtbSearch);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddLocalDrivingLicenseApplications);
            this.Controls.Add(this.dgvApps);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "LocalDrivingLicenseApplicationsManagementScreen";
            this.Text = "LocalDrivingLicenseApplicationsManagement";
            this.Load += new System.EventHandler(this.LocalDrivingLicenseApplicationsManagement_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.dgvApps, 0);
            this.Controls.SetChildIndex(this.btnAddLocalDrivingLicenseApplications, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.Controls.SetChildIndex(this.mtbSearch, 0);
            this.Controls.SetChildIndex(this.cbStatus, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApps)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvApps;
        private System.Windows.Forms.Button btnAddLocalDrivingLicenseApplications;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contextShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contextEdit;
        private System.Windows.Forms.ToolStripMenuItem contextDelete;
        private System.Windows.Forms.MaskedTextBox mtbSearch;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ToolStripMenuItem contextScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem contextVisionTest;
        private System.Windows.Forms.ToolStripMenuItem contextWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem contextStreetTest;
        private System.Windows.Forms.ToolStripMenuItem contextIssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem contextCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem contextShowLicenseInfo;
        private System.Windows.Forms.ToolStripMenuItem contextShowPersonLicenseHistory;
    }
}