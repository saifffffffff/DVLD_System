namespace DVLD_WindowsForms.Screens.UsersManagement
{
    partial class ChangePasswordScreen
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
            this.ctrlShowLoginInfo1 = new DVLD_WindowsForms.UserControls.ctrlLoginInfo();
            this.ctrlShowPersonInfo1 = new DVLD_WindowsForms.UserControls.ctrlPersonInfo();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(842, 12);
            // 
            // ctrlShowLoginInfo1
            // 
            this.ctrlShowLoginInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlShowLoginInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlShowLoginInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlShowLoginInfo1.Location = new System.Drawing.Point(17, 369);
            this.ctrlShowLoginInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlShowLoginInfo1.Name = "ctrlShowLoginInfo1";
            this.ctrlShowLoginInfo1.Size = new System.Drawing.Size(867, 88);
            this.ctrlShowLoginInfo1.TabIndex = 5;
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlShowPersonInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlShowPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShowPersonInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(17, 64);
            this.ctrlShowPersonInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(867, 289);
            this.ctrlShowPersonInfo1.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(194, 535);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 72;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(194, 487);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 71;
            this.pictureBox2.TabStop = false;
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPassword.Location = new System.Drawing.Point(231, 537);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(265, 29);
            this.tbNewPassword.TabIndex = 70;
            this.tbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbNewPassword_Validating);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(231, 489);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(265, 29);
            this.tbPassword.TabIndex = 69;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(42, 535);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(146, 24);
            this.lbl.TabIndex = 68;
            this.lbl.Text = "New Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 67;
            this.label2.Text = "Password :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_WindowsForms.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(194, 583);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(231, 585);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(265, 29);
            this.tbConfirmPassword.TabIndex = 74;
            this.tbConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbConfirmPassword_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 73;
            this.label1.Text = "Confirm Password :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::DVLD_WindowsForms.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(723, 620);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 47);
            this.btnSave.TabIndex = 76;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ChangePasswordScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 679);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlShowLoginInfo1);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "ChangePasswordScreen";
            this.Text = "ChangePasswordScreen";
            this.Controls.SetChildIndex(this.ctrlShowPersonInfo1, 0);
            this.Controls.SetChildIndex(this.ctrlShowLoginInfo1, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.tbNewPassword, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbConfirmPassword, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlLoginInfo ctrlShowLoginInfo1;
        private UserControls.ctrlPersonInfo ctrlShowPersonInfo1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}