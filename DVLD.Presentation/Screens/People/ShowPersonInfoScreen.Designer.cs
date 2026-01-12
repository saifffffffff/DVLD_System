namespace DVLD_WindowsForms.Screens.PeopleManagement
{
    partial class ShowPersonInfoScreen
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
            this.ctrlShowPersonInfo1 = new DVLD_WindowsForms.UserControls.ctrlPersonInfo();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(833, 12);
            // 
            // ctrlShowPersonInfo1
            // 
            this.ctrlShowPersonInfo1.BackColor = System.Drawing.Color.Black;
            this.ctrlShowPersonInfo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ctrlShowPersonInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlShowPersonInfo1.Location = new System.Drawing.Point(9, 119);
            this.ctrlShowPersonInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlShowPersonInfo1.Name = "ctrlShowPersonInfo1";
            this.ctrlShowPersonInfo1.Size = new System.Drawing.Size(866, 285);
            this.ctrlShowPersonInfo1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.LightBlue;
            this.lblTitle.Location = new System.Drawing.Point(267, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 55);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Person Details";
            // 
            // ShowPersonInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(883, 418);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlShowPersonInfo1);
            this.Name = "ShowPersonInfoScreen";
            this.Text = "ShowPersonInfoScreen";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.ctrlShowPersonInfo1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ctrlPersonInfo ctrlShowPersonInfo1;
        private System.Windows.Forms.Label lblTitle;
    }
}