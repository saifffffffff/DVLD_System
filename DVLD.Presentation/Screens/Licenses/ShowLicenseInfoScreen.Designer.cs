namespace DVLD_WindowsForms.Screens.Licenses
{
    partial class ShowLicenseInfoScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseInfo1 = new DVLD_WindowsForms.UserControls.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1239, 12);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(334, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "Local Driving License Applications";
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLicenseInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(29, 78);
            this.ctrlLicenseInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(1240, 355);
            this.ctrlLicenseInfo1.TabIndex = 4;
            // 
            // ShowLicenseInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 450);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.label1);
            this.Name = "ShowLicenseInfoScreen";
            this.Text = "ShowLicenseInfoScreen";
            this.Load += new System.EventHandler(this.ShowLicenseInfoScreen_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ctrlLicenseInfo1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private UserControls.ctrlLicenseInfo ctrlLicenseInfo1;
    }
}