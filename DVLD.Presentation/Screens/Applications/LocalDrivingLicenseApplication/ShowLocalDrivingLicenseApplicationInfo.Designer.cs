namespace DVLD_WindowsForms.Screens.Applications.LocalDrivingLicenseApplication
{
    partial class ShowLocalDrivingLicenseApplicationInfo
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.localDrivingLicenseApplicationInfo1 = new DVLD_WindowsForms.UserControls.ctrlLocalDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(831, 12);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblTitle.Location = new System.Drawing.Point(25, 44);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(806, 42);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Local Driving License Application Information";
            // 
            // localDrivingLicenseApplicationInfo1
            // 
            this.localDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.Transparent;
            this.localDrivingLicenseApplicationInfo1.ForeColor = System.Drawing.Color.White;
            this.localDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(47, 94);
            this.localDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.localDrivingLicenseApplicationInfo1.Name = "localDrivingLicenseApplicationInfo1";
            this.localDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(762, 615);
            this.localDrivingLicenseApplicationInfo1.TabIndex = 1;
            // 
            // ShowLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 697);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.localDrivingLicenseApplicationInfo1);
            this.Name = "ShowLocalDrivingLicenseApplicationInfo";
            this.Text = "ShowLocalDrivingLicenseApplicationInfo";
            this.Load += new System.EventHandler(this.ShowLocalDrivingLicenseApplicationInfo_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.localDrivingLicenseApplicationInfo1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlLocalDrivingLicenseApplicationInfo localDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label lblTitle;
    }
}