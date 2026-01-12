namespace DVLD_WindowsForms.Screens.InternationalLicenses
{
    partial class ShowInternationalLicenseInfo
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
            this.ctrlInternationalLicenseInfo1 = new DVLD_WindowsForms.UserControls.InternationalLicenses.ctrlInternationalLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(852, 12);
            // 
            // ctrlInternationalLicenseInfo1
            // 
            this.ctrlInternationalLicenseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInternationalLicenseInfo1.CloseIfNotFound = false;
            this.ctrlInternationalLicenseInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlInternationalLicenseInfo1.Location = new System.Drawing.Point(20, 89);
            this.ctrlInternationalLicenseInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlInternationalLicenseInfo1.Name = "ctrlInternationalLicenseInfo1";
            this.ctrlInternationalLicenseInfo1.Size = new System.Drawing.Size(871, 287);
            this.ctrlInternationalLicenseInfo1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(70, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(771, 51);
            this.label1.TabIndex = 4;
            this.label1.Text = "International Driving License Applications";
            // 
            // ShowInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 379);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlInternationalLicenseInfo1);
            this.Name = "ShowInternationalLicenseInfo";
            this.Text = "ShowInternationalLicenseInfo";
            this.Load += new System.EventHandler(this.ShowInternationalLicenseInfo_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.ctrlInternationalLicenseInfo1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.InternationalLicenses.ctrlInternationalLicenseInfo ctrlInternationalLicenseInfo1;
        private System.Windows.Forms.Label label1;
    }
}