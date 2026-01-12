namespace DVLD_WindowsForms.Screens.TestAppointments
{
    partial class AddUpdateTestAppointmentScreen
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
            this.btnSave = new System.Windows.Forms.Button();
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.gbRetakeTestInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lblRetakeAppFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblRetakeTestAppID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblDrivingClass = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblLocalDrivingLicenseAppID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTrial = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dtpTestDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTestType.SuspendLayout();
            this.gbRetakeTestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(575, 14);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::DVLD_WindowsForms.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(452, 682);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 35);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbTestType
            // 
            this.gbTestType.BackColor = System.Drawing.Color.Transparent;
            this.gbTestType.Controls.Add(this.gbRetakeTestInfo);
            this.gbTestType.Controls.Add(this.pictureBox7);
            this.gbTestType.Controls.Add(this.lblDrivingClass);
            this.gbTestType.Controls.Add(this.label10);
            this.gbTestType.Controls.Add(this.pictureBox4);
            this.gbTestType.Controls.Add(this.lblLocalDrivingLicenseAppID);
            this.gbTestType.Controls.Add(this.label8);
            this.gbTestType.Controls.Add(this.lblFullName);
            this.gbTestType.Controls.Add(this.pictureBox2);
            this.gbTestType.Controls.Add(this.label6);
            this.gbTestType.Controls.Add(this.lblTrial);
            this.gbTestType.Controls.Add(this.label5);
            this.gbTestType.Controls.Add(this.pictureBox3);
            this.gbTestType.Controls.Add(this.lblFees);
            this.gbTestType.Controls.Add(this.label2);
            this.gbTestType.Controls.Add(this.pictureBox5);
            this.gbTestType.Controls.Add(this.dtpTestDate);
            this.gbTestType.Controls.Add(this.label3);
            this.gbTestType.Controls.Add(this.pictureBox8);
            this.gbTestType.Controls.Add(this.pbTestImage);
            this.gbTestType.Controls.Add(this.lblTitle);
            this.gbTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestType.ForeColor = System.Drawing.Color.White;
            this.gbTestType.Location = new System.Drawing.Point(26, 63);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(567, 605);
            this.gbTestType.TabIndex = 35;
            this.gbTestType.TabStop = false;
            this.gbTestType.Text = "Test Type";
            // 
            // gbRetakeTestInfo
            // 
            this.gbRetakeTestInfo.Controls.Add(this.lblTotalFees);
            this.gbRetakeTestInfo.Controls.Add(this.label9);
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox9);
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeAppFees);
            this.gbRetakeTestInfo.Controls.Add(this.label7);
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox6);
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox10);
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeTestAppID);
            this.gbRetakeTestInfo.Controls.Add(this.label4);
            this.gbRetakeTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRetakeTestInfo.ForeColor = System.Drawing.Color.White;
            this.gbRetakeTestInfo.Location = new System.Drawing.Point(7, 473);
            this.gbRetakeTestInfo.Name = "gbRetakeTestInfo";
            this.gbRetakeTestInfo.Size = new System.Drawing.Size(555, 126);
            this.gbRetakeTestInfo.TabIndex = 206;
            this.gbRetakeTestInfo.TabStop = false;
            this.gbRetakeTestInfo.Text = "Retake Test Info";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(457, 37);
            this.lblTotalFees.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(49, 20);
            this.lblTotalFees.TabIndex = 215;
            this.lblTotalFees.Text = "[$$$]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(298, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 213;
            this.label9.Text = "Total Fees:";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(417, 37);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(31, 26);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 214;
            this.pictureBox9.TabStop = false;
            // 
            // lblRetakeAppFees
            // 
            this.lblRetakeAppFees.AutoSize = true;
            this.lblRetakeAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeAppFees.Location = new System.Drawing.Point(191, 37);
            this.lblRetakeAppFees.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRetakeAppFees.Name = "lblRetakeAppFees";
            this.lblRetakeAppFees.Size = new System.Drawing.Size(49, 20);
            this.lblRetakeAppFees.TabIndex = 212;
            this.lblRetakeAppFees.Text = "[$$$]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 210;
            this.label7.Text = "R.App.Fees:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(151, 37);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 211;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Location = new System.Drawing.Point(151, 73);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(31, 26);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 209;
            this.pictureBox10.TabStop = false;
            // 
            // lblRetakeTestAppID
            // 
            this.lblRetakeTestAppID.AutoSize = true;
            this.lblRetakeTestAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeTestAppID.Location = new System.Drawing.Point(191, 73);
            this.lblRetakeTestAppID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRetakeTestAppID.Name = "lblRetakeTestAppID";
            this.lblRetakeTestAppID.Size = new System.Drawing.Size(39, 20);
            this.lblRetakeTestAppID.TabIndex = 208;
            this.lblRetakeTestAppID.Text = "[??]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 207;
            this.label4.Text = "R.Test.App.ID";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(122, 276);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(31, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 205;
            this.pictureBox7.TabStop = false;
            // 
            // lblDrivingClass
            // 
            this.lblDrivingClass.AutoSize = true;
            this.lblDrivingClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrivingClass.Location = new System.Drawing.Point(162, 276);
            this.lblDrivingClass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDrivingClass.Name = "lblDrivingClass";
            this.lblDrivingClass.Size = new System.Drawing.Size(89, 20);
            this.lblDrivingClass.TabIndex = 204;
            this.lblDrivingClass.Text = "[???????]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 276);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 203;
            this.label10.Text = "D. Class:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(122, 240);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 202;
            this.pictureBox4.TabStop = false;
            // 
            // lblLocalDrivingLicenseAppID
            // 
            this.lblLocalDrivingLicenseAppID.AutoSize = true;
            this.lblLocalDrivingLicenseAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDrivingLicenseAppID.Location = new System.Drawing.Point(154, 240);
            this.lblLocalDrivingLicenseAppID.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLocalDrivingLicenseAppID.Name = "lblLocalDrivingLicenseAppID";
            this.lblLocalDrivingLicenseAppID.Size = new System.Drawing.Size(39, 20);
            this.lblLocalDrivingLicenseAppID.TabIndex = 201;
            this.lblLocalDrivingLicenseAppID.Text = "[??]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 240);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 200;
            this.label8.Text = "D.L.App.ID:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(162, 312);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(89, 20);
            this.lblFullName.TabIndex = 199;
            this.lblFullName.Text = "[???????]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(122, 312);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 198;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 312);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 197;
            this.label6.Text = "Name:";
            // 
            // lblTrial
            // 
            this.lblTrial.AutoSize = true;
            this.lblTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrial.Location = new System.Drawing.Point(162, 348);
            this.lblTrial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTrial.Name = "lblTrial";
            this.lblTrial.Size = new System.Drawing.Size(39, 20);
            this.lblTrial.TabIndex = 196;
            this.lblTrial.Text = "[??]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 348);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 194;
            this.label5.Text = "Trial:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(122, 348);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 195;
            this.pictureBox3.TabStop = false;
            // 
            // lblFees
            // 
            this.lblFees.AutoSize = true;
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(162, 420);
            this.lblFees.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFees.Name = "lblFees";
            this.lblFees.Size = new System.Drawing.Size(49, 20);
            this.lblFees.TabIndex = 193;
            this.lblFees.Text = "[$$$]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 420);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 191;
            this.label2.Text = "Fees:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(122, 420);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 192;
            this.pictureBox5.TabStop = false;
            // 
            // dtpTestDate
            // 
            this.dtpTestDate.CustomFormat = "dd/M/yyyy";
            this.dtpTestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTestDate.Location = new System.Drawing.Point(163, 384);
            this.dtpTestDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTestDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpTestDate.Name = "dtpTestDate";
            this.dtpTestDate.Size = new System.Drawing.Size(163, 26);
            this.dtpTestDate.TabIndex = 190;
            this.dtpTestDate.Value = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 188;
            this.label3.Text = "Date:";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(122, 384);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 189;
            this.pictureBox8.TabStop = false;
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_WindowsForms.Properties.Resources.driving_test_512;
            this.pbTestImage.Location = new System.Drawing.Point(176, 16);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(240, 144);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestImage.TabIndex = 7;
            this.pbTestImage.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.LightBlue;
            this.lblTitle.Location = new System.Drawing.Point(26, 163);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(518, 45);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Schedule ------ Test Appointment";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddUpdateTestAppointmentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 758);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbTestType);
            this.Name = "AddUpdateTestAppointmentScreen";
            this.Text = "ScheduleTestAppointment";
            this.Load += new System.EventHandler(this.ScheduleTestAppointment_Load);
            this.Controls.SetChildIndex(this.gbTestType, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.gbTestType.ResumeLayout(false);
            this.gbTestType.PerformLayout();
            this.gbRetakeTestInfo.ResumeLayout(false);
            this.gbRetakeTestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbTestType;
        private System.Windows.Forms.GroupBox gbRetakeTestInfo;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblRetakeAppFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblRetakeTestAppID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblDrivingClass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblLocalDrivingLicenseAppID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTrial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DateTimePicker dtpTestDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblTitle;
    }
}