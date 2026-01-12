namespace DVLD_WindowsForms.Screens.Licenses
{
    partial class IssueDrivingLicenseScreen
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
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD_WindowsForms.UserControls.ctrlLocalDrivingLicenseApplicationInfo();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(719, 12);
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLocalDrivingLicenseApplicationInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(4, 64);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(762, 615);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 1;
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(111, 643);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(643, 127);
            this.tbNotes.TabIndex = 18;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(10, 643);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(66, 20);
            this.label.TabIndex = 19;
            this.label.Text = "Notes :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_WindowsForms.Properties.Resources.Notes_32;
            this.pictureBox4.Location = new System.Drawing.Point(74, 643);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::DVLD_WindowsForms.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(613, 776);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 35);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(188, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 51);
            this.label1.TabIndex = 34;
            this.label1.Text = "Issue Driving License";
            // 
            // IssueDrivingLicenseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 831);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Name = "IssueDrivingLicenseScreen";
            this.Text = "IssueDrivingLicenseScreen";
            this.Load += new System.EventHandler(this.IssueDrivingLicenseScreen_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.ctrlLocalDrivingLicenseApplicationInfo1, 0);
            this.Controls.SetChildIndex(this.tbNotes, 0);
            this.Controls.SetChildIndex(this.label, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}