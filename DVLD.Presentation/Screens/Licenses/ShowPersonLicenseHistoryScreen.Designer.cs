namespace DVLD_WindowsForms.Screens.Licenses
{
    partial class ShowPersonLicenseHistoryScreen
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlPersonInfo1 = new DVLD_WindowsForms.UserControls.ctrlPersonInfo();
            this.ctrlDriverLicenses1 = new DVLD_WindowsForms.UserControls.ctrlDriverLicenses();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1071, 12);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(375, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 65);
            this.label1.TabIndex = 4;
            this.label1.Text = "License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(-21, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ctrlPersonInfo1
            //             
            this.ctrlPersonInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(263, 88);
            this.ctrlPersonInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(863, 289);
            this.ctrlPersonInfo1.TabIndex = 8;
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDriverLicenses1.ForeColor = System.Drawing.Color.White;
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(-1, 366);
            this.ctrlDriverLicenses1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(1127, 334);
            this.ctrlDriverLicenses1.TabIndex = 9;
            // 
            // ShowPersonLicenseHistoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 697);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "ShowPersonLicenseHistoryScreen";
            this.Text = "ShowPersonLicenseHistoryScreen";
            this.Load += new System.EventHandler(this.ShowPersonLicenseHistoryScreen_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.ctrlPersonInfo1, 0);
            this.Controls.SetChildIndex(this.ctrlDriverLicenses1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControls.ctrlPersonInfo ctrlPersonInfo1;
        private UserControls.ctrlDriverLicenses ctrlDriverLicenses1;
    }
}