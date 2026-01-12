using System.Drawing;
using DVLD_WindowsForms.Properties;

namespace DVLD_WindowsForms
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.UserstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.contextReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextInternationalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationTypes_ApplictionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.contextManageDetainedLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pbUserAccount = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAccount)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserstoolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.applicationsToolStripMenuItem,
            this.DriversToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(311, 922);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // UserstoolStripMenuItem
            // 
            this.UserstoolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserstoolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.UserstoolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Users_2_64;
            this.UserstoolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserstoolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.UserstoolStripMenuItem.Name = "UserstoolStripMenuItem";
            this.UserstoolStripMenuItem.Size = new System.Drawing.Size(290, 68);
            this.UserstoolStripMenuItem.Text = "Users";
            this.UserstoolStripMenuItem.Click += new System.EventHandler(this.UserstoolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peopleToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.peopleToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(290, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.manageApplicationTypes_ApplictionsToolStripMenuItem,
            this.contextManageTestTypes,
            this.contextManageDetainedLicenses});
            this.applicationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applicationsToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.applicationsToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Applications_64;
            this.applicationsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(290, 68);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextRenewDrivingLicense,
            this.contextReplace});
            this.drivingLicensesServicesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drivingLicensesServicesToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Driver_License_48;
            this.drivingLicensesServicesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(448, 70);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // contextRenewDrivingLicense
            // 
            this.contextRenewDrivingLicense.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextRenewDrivingLicense.Image = global::DVLD_WindowsForms.Properties.Resources.Renew_Driving_License_32;
            this.contextRenewDrivingLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contextRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextRenewDrivingLicense.Name = "contextRenewDrivingLicense";
            this.contextRenewDrivingLicense.Size = new System.Drawing.Size(348, 38);
            this.contextRenewDrivingLicense.Text = "Renew Driving License";
            this.contextRenewDrivingLicense.Click += new System.EventHandler(this.contextRenewDrivingLicense_Click);
            // 
            // contextReplace
            // 
            this.contextReplace.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextReplace.Image = global::DVLD_WindowsForms.Properties.Resources.Damaged_Driving_License_32;
            this.contextReplace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextReplace.Name = "contextReplace";
            this.contextReplace.Size = new System.Drawing.Size(348, 38);
            this.contextReplace.Text = "Replace Driving License For Lost or Damaged";
            this.contextReplace.Click += new System.EventHandler(this.contextReplace_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingToolStripMenuItem,
            this.contextInternationalDrivingLicenseApplications});
            this.manageApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Manage_Applications_64;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(448, 70);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingToolStripMenuItem
            // 
            this.localDrivingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localDrivingToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Driver_License_48;
            this.localDrivingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localDrivingToolStripMenuItem.Name = "localDrivingToolStripMenuItem";
            this.localDrivingToolStripMenuItem.Size = new System.Drawing.Size(340, 54);
            this.localDrivingToolStripMenuItem.Text = "Local Driving License Applications";
            this.localDrivingToolStripMenuItem.Click += new System.EventHandler(this.localDrivingToolStripMenuItem_Click);
            // 
            // contextInternationalDrivingLicenseApplications
            // 
            this.contextInternationalDrivingLicenseApplications.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextInternationalDrivingLicenseApplications.Image = global::DVLD_WindowsForms.Properties.Resources.International_32;
            this.contextInternationalDrivingLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextInternationalDrivingLicenseApplications.Name = "contextInternationalDrivingLicenseApplications";
            this.contextInternationalDrivingLicenseApplications.Size = new System.Drawing.Size(340, 54);
            this.contextInternationalDrivingLicenseApplications.Text = "International Driving License Applications";
            this.contextInternationalDrivingLicenseApplications.Click += new System.EventHandler(this.contextInternationalDrivingLicenseApplications_Click);
            // 
            // manageApplicationTypes_ApplictionsToolStripMenuItem
            // 
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Application_Types_64;
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Name = "manageApplicationTypes_ApplictionsToolStripMenuItem";
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Size = new System.Drawing.Size(448, 70);
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationTypes_ApplictionsToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationTypes_ApplictionsToolStripMenuItem_Click);
            // 
            // contextManageTestTypes
            // 
            this.contextManageTestTypes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextManageTestTypes.Image = global::DVLD_WindowsForms.Properties.Resources.Test_Type_64;
            this.contextManageTestTypes.Name = "contextManageTestTypes";
            this.contextManageTestTypes.Size = new System.Drawing.Size(448, 70);
            this.contextManageTestTypes.Text = "Manage Test Types";
            this.contextManageTestTypes.Click += new System.EventHandler(this.contextManageTestTypes_Click);
            // 
            // contextManageDetainedLicenses
            // 
            this.contextManageDetainedLicenses.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextManageDetainedLicenses.Image = global::DVLD_WindowsForms.Properties.Resources.Detain_64;
            this.contextManageDetainedLicenses.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.contextManageDetainedLicenses.Name = "contextManageDetainedLicenses";
            this.contextManageDetainedLicenses.Size = new System.Drawing.Size(448, 70);
            this.contextManageDetainedLicenses.Text = "Manage Detained Licenses";
            this.contextManageDetainedLicenses.Click += new System.EventHandler(this.contextManageDetainedLicenses_Click);
            // 
            // DriversToolStripMenuItem
            // 
            this.DriversToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriversToolStripMenuItem.ForeColor = System.Drawing.Color.SkyBlue;
            this.DriversToolStripMenuItem.Image = global::DVLD_WindowsForms.Properties.Resources.Drivers_64;
            this.DriversToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DriversToolStripMenuItem.Name = "DriversToolStripMenuItem";
            this.DriversToolStripMenuItem.Size = new System.Drawing.Size(290, 68);
            this.DriversToolStripMenuItem.Text = "Drivers";
            this.DriversToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.DriversToolStripMenuItem.Click += new System.EventHandler(this.DriversToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "People 400.png");
            // 
            // pbUserAccount
            // 
            this.pbUserAccount.Location = new System.Drawing.Point(1384, 19);
            this.pbUserAccount.Name = "pbUserAccount";
            this.pbUserAccount.Size = new System.Drawing.Size(114, 100);
            this.pbUserAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUserAccount.TabIndex = 3;
            this.pbUserAccount.TabStop = false;
            this.pbUserAccount.Click += new System.EventHandler(this.pbUserAccount_Click);
            this.pbUserAccount.MouseEnter += new System.EventHandler(this.pbUserAccount_MouseEnter);
            this.pbUserAccount.MouseLeave += new System.EventHandler(this.pbUserAccount_MouseLeave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(311, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1569, 922);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbUserAccount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1500, 123);
            this.panel1.TabIndex = 4;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1880, 922);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SteelBlue;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreen_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserAccount)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pbUserAccount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem UserstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationTypes_ApplictionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextManageDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextInternationalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem contextRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem contextReplace;
        private System.Windows.Forms.ToolStripMenuItem contextManageTestTypes;
    }
}

