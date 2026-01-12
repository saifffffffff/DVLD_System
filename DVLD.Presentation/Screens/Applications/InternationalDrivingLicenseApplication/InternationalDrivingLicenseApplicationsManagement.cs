using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;

namespace DVLD_WindowsForms.Screens.Applications.InternationalDrivingLicenseApplication
{
    public partial class InternationalDrivingLicenseApplicationsManagement : ScreenToInherit
    {
        DataTable _dtInternationalLicenseApplications;
        public InternationalDrivingLicenseApplicationsManagement()
        {
            InitializeComponent();
        }


        
        private void InternationalDrivingLicenseApplicationsManagement_Load(object sender, EventArgs e)
        {
            _dtInternationalLicenseApplications = clsInternationalLicense.GetAll();
            cbFilter.SelectedIndex = 0;
            cbIsActive.Visible = false;

            dgvInternationalLicenses.DataSource = _dtInternationalLicenseApplications;

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;

            }


        }
   
        private void btnAddInternationalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new AddInternationalDrivingLicenseApplication());
            InternationalDrivingLicenseApplicationsManagement_Load(null,null);
        }
   
        
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbFilter.Text == "None")
            {
                tbSearch.Visible = cbIsActive.Visible = false;
            }

            else if ( cbFilter.Text == "Is Active")
            {
                tbSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }

            else
            {
                tbSearch.Visible = true;
                cbIsActive.Visible = false;
                tbSearch.Focus();
            }




        }
        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                    
                    

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                return;
            }


            _dtInternationalLicenseApplications.DefaultView.RowFilter = $" {FilterColumn} = {tbSearch.Text.Trim()}";

        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if ( cbIsActive.Text == "All")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                return;
            }
            
            string result = cbIsActive.Text == "Yes" ? "1" : "0";
            
            _dtInternationalLicenseApplications.DefaultView.RowFilter = $"IsActive = {result}";




        }
    
    }
}
