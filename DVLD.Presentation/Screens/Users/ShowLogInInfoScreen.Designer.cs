namespace DVLD_WindowsForms.Screens.UsersManagement
{
    partial class ShowLogInInfoScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowLogInInfoScreen));
            this.ctrlShowPersonInfo1 = new DVLD_WindowsForms.UserControls.ctrlPersonInfo();
            this.ctrlShowLoginInfo1 = new DVLD_WindowsForms.UserControls.ctrlLoginInfo();
            this.btnSignout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(842, 17);
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlShowPersonInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.ctrlShowPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlShowPersonInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(17, 106);
            this.ctrlShowPersonInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(867, 289);
            this.ctrlShowPersonInfo1.TabIndex = 2;
            // 
            // ctrlShowLoginInfo1
            // 
            this.ctrlShowLoginInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlShowLoginInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlShowLoginInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlShowLoginInfo1.Location = new System.Drawing.Point(17, 411);
            this.ctrlShowLoginInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlShowLoginInfo1.Name = "ctrlShowLoginInfo1";
            this.ctrlShowLoginInfo1.Size = new System.Drawing.Size(867, 88);
            this.ctrlShowLoginInfo1.TabIndex = 3;
            // 
            // btnSignout
            // 
            this.btnSignout.BackColor = System.Drawing.Color.White;
            this.btnSignout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(171)))), ((int)(((byte)(220)))));
            this.btnSignout.Location = new System.Drawing.Point(17, 523);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(279, 45);
            this.btnSignout.TabIndex = 5;
            this.btnSignout.Text = "Sign Out";
            this.btnSignout.UseVisualStyleBackColor = false;
            this.btnSignout.Click += new System.EventHandler(this.btnSignout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.White;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(171)))), ((int)(((byte)(220)))));
            this.btnChangePassword.Location = new System.Drawing.Point(302, 523);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(279, 45);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(308, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "User Details";
            // 
            // ShowLogInInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 579);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnSignout);
            this.Controls.Add(this.ctrlShowLoginInfo1);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "ShowLogInInfoScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserInfoScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShowLogInInfoScreen_FormClosed);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.ctrlShowPersonInfo1, 0);
            this.Controls.SetChildIndex(this.ctrlShowLoginInfo1, 0);
            this.Controls.SetChildIndex(this.btnSignout, 0);
            this.Controls.SetChildIndex(this.btnChangePassword, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlPersonInfo ctrlShowPersonInfo1;
        private UserControls.ctrlLoginInfo ctrlShowLoginInfo1;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label1;
    }
}