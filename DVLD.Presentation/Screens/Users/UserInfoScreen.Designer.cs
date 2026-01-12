namespace DVLD_WindowsForms.Screens.UsersManagement
{
    partial class UserInfoScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoScreen));
            this.ctrlLoginInfo1 = new DVLD_WindowsForms.UserControls.ctrlLoginInfo();
            this.ctrlPersonInfo1 = new DVLD_WindowsForms.UserControls.ctrlPersonInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(838, 12);
            // 
            // ctrlLoginInfo1
            // 
            this.ctrlLoginInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlLoginInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlLoginInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlLoginInfo1.Location = new System.Drawing.Point(17, 369);
            this.ctrlLoginInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlLoginInfo1.Name = "ctrlLoginInfo1";
            this.ctrlLoginInfo1.Size = new System.Drawing.Size(863, 88);
            this.ctrlLoginInfo1.TabIndex = 1;
            // 
            // ctrlPersonInfo1
            // 
            this.ctrlPersonInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlPersonInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlPersonInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlPersonInfo1.Location = new System.Drawing.Point(17, 81);
            this.ctrlPersonInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlPersonInfo1.Name = "ctrlPersonInfo1";
            this.ctrlPersonInfo1.Size = new System.Drawing.Size(863, 289);
            this.ctrlPersonInfo1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(306, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Details";
            // 
            // UserInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 478);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonInfo1);
            this.Controls.Add(this.ctrlLoginInfo1);
            this.Name = "UserInfoScreen";
            this.Text = "UserInfoScreen";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.ctrlLoginInfo1, 0);
            this.Controls.SetChildIndex(this.ctrlPersonInfo1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlLoginInfo ctrlLoginInfo1;
        private UserControls.ctrlPersonInfo ctrlPersonInfo1;
        private System.Windows.Forms.Label label1;
    }
}