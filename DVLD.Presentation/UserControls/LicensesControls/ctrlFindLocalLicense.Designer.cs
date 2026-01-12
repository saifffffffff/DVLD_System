namespace DVLD_WindowsForms.UserControls
{
    partial class ctrlFindLocalLicense
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctrlLicenseInfo1 = new DVLD_WindowsForms.UserControls.ctrlLicenseInfo();
            this.gpFilter = new System.Windows.Forms.GroupBox();
            this.tbSearch = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLicenseInfo1.CloseIfNotFound = true;
            this.ctrlLicenseInfo1.ForeColor = System.Drawing.Color.White;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(8, 111);
            this.ctrlLicenseInfo1.Margin = new System.Windows.Forms.Padding(8);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(1240, 379);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // gpFilter
            // 
            this.gpFilter.BackColor = System.Drawing.Color.Transparent;
            this.gpFilter.Controls.Add(this.tbSearch);
            this.gpFilter.Controls.Add(this.btnSearch);
            this.gpFilter.Controls.Add(this.label1);
            this.gpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpFilter.ForeColor = System.Drawing.Color.White;
            this.gpFilter.Location = new System.Drawing.Point(13, 26);
            this.gpFilter.Name = "gpFilter";
            this.gpFilter.Size = new System.Drawing.Size(544, 87);
            this.gpFilter.TabIndex = 1;
            this.gpFilter.TabStop = false;
            this.gpFilter.Text = "Filter";
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(156, 31);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(301, 31);
            this.tbSearch.TabIndex = 60;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbSearch_KeyPress);
            this.tbSearch.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearch_Validating);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::DVLD_WindowsForms.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(474, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 54);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.UseMnemonic = false;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 56;
            this.label1.Text = "License ID : ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlFindLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gpFilter);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlFindLocalLicense";
            this.Size = new System.Drawing.Size(1239, 477);
            this.gpFilter.ResumeLayout(false);
            this.gpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.GroupBox gpFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tbSearch;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
