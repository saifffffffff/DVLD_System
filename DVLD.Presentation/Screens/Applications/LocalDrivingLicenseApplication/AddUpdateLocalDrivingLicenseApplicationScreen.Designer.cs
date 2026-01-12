namespace DVLD_WindowsForms.Screens.Applications
{
    partial class AddUpdateLocalDrivingLicenseApplicationScreen
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
            this.tcLicenseInfo = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlFindPerson1 = new DVLD_WindowsForms.UserControls.ctrlFindPerson();
            this.tpApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblClassFees = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcLicenseInfo.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(924, 12);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblTitle.Location = new System.Drawing.Point(148, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(689, 42);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // tcLicenseInfo
            // 
            this.tcLicenseInfo.Controls.Add(this.tpPersonInfo);
            this.tcLicenseInfo.Controls.Add(this.tpApplicationInfo);
            this.tcLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcLicenseInfo.Location = new System.Drawing.Point(22, 66);
            this.tcLicenseInfo.Name = "tcLicenseInfo";
            this.tcLicenseInfo.SelectedIndex = 0;
            this.tcLicenseInfo.Size = new System.Drawing.Size(935, 537);
            this.tcLicenseInfo.TabIndex = 6;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.BackColor = System.Drawing.Color.Black;
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrlFindPerson1);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonInfo.Size = new System.Drawing.Size(927, 511);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Image = global::DVLD_WindowsForms.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(778, 464);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(129, 40);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlFindPerson1
            // 
            this.ctrlFindPerson1.BackColor = System.Drawing.Color.Black;
            this.ctrlFindPerson1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlFindPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlFindPerson1.ForeColor = System.Drawing.Color.White;
            this.ctrlFindPerson1.Location = new System.Drawing.Point(21, 56);
            this.ctrlFindPerson1.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.ctrlFindPerson1.Name = "ctrlFindPerson1";
            this.ctrlFindPerson1.Size = new System.Drawing.Size(887, 395);
            this.ctrlFindPerson1.TabIndex = 2;
            // 
            // tpApplicationInfo
            // 
            this.tpApplicationInfo.BackColor = System.Drawing.Color.Black;
            this.tpApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tpApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tpApplicationInfo.Controls.Add(this.lblClassFees);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tpApplicationInfo.Controls.Add(this.pictureBox5);
            this.tpApplicationInfo.Controls.Add(this.label5);
            this.tpApplicationInfo.Controls.Add(this.pictureBox4);
            this.tpApplicationInfo.Controls.Add(this.lblApplicationID);
            this.tpApplicationInfo.Controls.Add(this.pictureBox3);
            this.tpApplicationInfo.Controls.Add(this.pictureBox2);
            this.tpApplicationInfo.Controls.Add(this.pictureBox1);
            this.tpApplicationInfo.Controls.Add(this.label4);
            this.tpApplicationInfo.Controls.Add(this.label3);
            this.tpApplicationInfo.Controls.Add(this.label2);
            this.tpApplicationInfo.Controls.Add(this.label1);
            this.tpApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tpApplicationInfo.Name = "tpApplicationInfo";
            this.tpApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpApplicationInfo.Size = new System.Drawing.Size(927, 511);
            this.tpApplicationInfo.TabIndex = 1;
            this.tpApplicationInfo.Text = "Application Info";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(263, 149);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(297, 32);
            this.cbLicenseClass.TabIndex = 75;
            this.cbLicenseClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClass_SelectedIndexChanged);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(259, 248);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(40, 24);
            this.lblCreatedBy.TabIndex = 74;
            this.lblCreatedBy.Text = "???";
            // 
            // lblClassFees
            // 
            this.lblClassFees.AutoSize = true;
            this.lblClassFees.Location = new System.Drawing.Point(259, 202);
            this.lblClassFees.Name = "lblClassFees";
            this.lblClassFees.Size = new System.Drawing.Size(40, 24);
            this.lblClassFees.TabIndex = 73;
            this.lblClassFees.Text = "???";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(259, 107);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(40, 24);
            this.lblApplicationDate.TabIndex = 72;
            this.lblApplicationDate.Text = "???";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_WindowsForms.Properties.Resources.User_32__2;
            this.pictureBox5.Location = new System.Drawing.Point(219, 241);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 71;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 24);
            this.label5.TabIndex = 70;
            this.label5.Text = "Created By :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(219, 58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 31);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 69;
            this.pictureBox4.TabStop = false;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Location = new System.Drawing.Point(259, 62);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(40, 24);
            this.lblApplicationID.TabIndex = 67;
            this.lblApplicationID.Text = "???";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_WindowsForms.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(219, 199);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_WindowsForms.Properties.Resources.License_Type_32;
            this.pictureBox2.Location = new System.Drawing.Point(219, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Calendar_32;
            this.pictureBox1.Location = new System.Drawing.Point(219, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "D.L Application ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "License Class :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applicatoin Date :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::DVLD_WindowsForms.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(796, 610);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 47);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddUpdateLocalDrivingLicenseApplicationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 669);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcLicenseInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "AddUpdateLocalDrivingLicenseApplicationScreen";
            this.Text = "AddUpdateLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.AddUpdateLocalDrivingLicenseApplicationScreen_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.tcLicenseInfo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.tcLicenseInfo.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpApplicationInfo.ResumeLayout(false);
            this.tpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tcLicenseInfo;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private UserControls.ctrlFindPerson ctrlFindPerson1;
        private System.Windows.Forms.TabPage tpApplicationInfo;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblClassFees;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Button btnSave;
    }
}