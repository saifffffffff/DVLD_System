using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Applications.LocalDrivingLicenseApplication;
using DVLD_WindowsForms.Screens.Licenses;
using DVLD_WindowsForms.Screens.TestsManagement;

namespace DVLD_WindowsForms.Screens.Applications
{
    public partial class LocalDrivingLicenseApplicationsManagementScreen : ScreenToInherit
    {

        private DataTable _dtApps;

        public LocalDrivingLicenseApplicationsManagementScreen()
        {
            InitializeComponent();
        }


        private void LocalDrivingLicenseApplicationsManagement_Load(object sender, EventArgs e)
        {
            _dtApps = clsLocalDrivingLicenseApplication.GetAll();
            
            dgvApps.DataSource = _dtApps;

            if (dgvApps.Columns.Count > 0) {

                dgvApps.Columns[0].HeaderText = "L.D.L.App ID";
                dgvApps.Columns[0].Width = 130;

                dgvApps.Columns[1].HeaderText = "Driving Class";
                dgvApps.Columns[1].Width= 300;

                dgvApps.Columns[2].HeaderText = "National No.";
                dgvApps.Columns[2].Width= 130;

                dgvApps.Columns[3].HeaderText = "Full Name";
                dgvApps.Columns[3].Width= 300;

                dgvApps.Columns[4].HeaderText = "Application Date";
                dgvApps.Columns[4].Width= 170;

                dgvApps.Columns[5].HeaderText= "Passed Tests Count";
                dgvApps.Columns[5].Width = 180;

                dgvApps.Columns[6].Width = 100;

            }

            cbFilter.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

        }

        private void btnAddLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new AddUpdateLocalDrivingLicenseApplicationScreen());
            LocalDrivingLicenseApplicationsManagement_Load(null , null);
        }


        // Filtering 
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filter = cbFilter.SelectedItem.ToString();

            _dtApps.DefaultView.RowFilter = "";
            
            if (Filter == "None")
            {
                mtbSearch.Visible = cbStatus.Visible = false;
            }

            else if (Filter == "Status")
            {
                mtbSearch.Visible = false;
                cbStatus.Visible = true;
            }

            else
            {
                mtbSearch.Visible = true;
                cbStatus.Visible = false;
                mtbSearch.Text = "";
            }
        }

        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {
        
            string SearchText = mtbSearch.Text.Trim().Replace(" ", "");
            string FilterColumn = cbFilter.SelectedItem.ToString().Replace(" ", "");
            
            if ( SearchText == "")
                _dtApps.DefaultView.RowFilter = "";

            else if ( FilterColumn.Contains("ID")) 
                    _dtApps.DefaultView.RowFilter = $"{FilterColumn} = {SearchText}";
            
            else
                _dtApps.DefaultView.RowFilter = $"{FilterColumn} Like '{SearchText}%'";
        
        }

        private void mtbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString().Contains("ID"))
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Status = cbStatus.SelectedItem.ToString();

            if ( Status == "All" )
            {
                _dtApps.DefaultView.RowFilter = "";
                return;
            }

            _dtApps.DefaultView.RowFilter = $"Status Like '{Status}'";

            
            
        }


        // Context Menu 
        private void contextShowDetails_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new ShowLocalDrivingLicenseApplicationInfo((int)dgvApps.CurrentRow.Cells[0].Value));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);
        }

        private void contextVisionTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId , (int)clsTestType.enTestTypes.VisionTest));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);
        }

        private void contextWrittenTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId, (int)clsTestType.enTestTypes.WrittenTest));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);

        }

        private void contextStreetTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId, (int)clsTestType.enTestTypes.PracticalTest));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);

        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
            int SelectedApplicationId = (int)dgvApps.CurrentRow.Cells[0].Value;
            clsGlobal.ShowDialog(new AddUpdateLocalDrivingLicenseApplicationScreen(SelectedApplicationId));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);
        }
       
        private void contextIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new IssueDrivingLicenseScreen(SelectedAppId));
            LocalDrivingLicenseApplicationsManagement_Load(null, null);

        }

        private void contextCancelApplication_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to cancel this application ?" , "" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplication.GetById(SelectedAppId).Cancel())
                {
                    MessageBox.Show("Application Canceled Successfully");
                    LocalDrivingLicenseApplicationsManagement_Load(null, null);
                }

                else
                    MessageBox.Show("Application Can't Be Canceled");

            }
        }

        private void contextShowLicenseInfo_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            
            var LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(SelectedAppId);
            var ApplicationId = LocalDrivingLicenseApplication.ApplicationId;
            var License = clsLicense.GetByApplicationId(ApplicationId);
            
            clsGlobal.ShowDialog(new ShowLicenseInfoScreen(License.Id));

        }

        private void contextShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            string SelectedNationalNo = dgvApps.CurrentRow.Cells[2].Value.ToString();

            clsGlobal.ShowDialog(new ShowPersonLicenseHistoryScreen(clsPerson.GetByNationalNo(SelectedNationalNo).Id));

        }

        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            int SelectedAppId = (int)dgvApps.CurrentRow.Cells[0].Value;

            if ( clsApplication.Delete(SelectedAppId) )
            {
                MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LocalDrivingLicenseApplicationsManagement_Load(null, null);
            }
            else
            {
                MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            
            int SelectedApplicationId = (int)dgvApps.CurrentRow.Cells[0].Value;

            var LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(SelectedApplicationId);

            // is license issued -> application isLicenseIssued
            
            
            int PassedTestsCount = (int)dgvApps.CurrentRow.Cells[5].Value;
            
            bool IsLicenseIssued = LocalDrivingLicenseApplication.IsLicenseIssued();

            contextEdit.Enabled = !IsLicenseIssued && LocalDrivingLicenseApplication.Status != clsApplication.enApplicationStatus.Cancelled;
            
            contextDelete.Enabled = !IsLicenseIssued;
            
            contextScheduleTest.Enabled = !IsLicenseIssued && LocalDrivingLicenseApplication.Status == clsApplication.enApplicationStatus.New && PassedTestsCount != 3;
            
            contextIssueDrivingLicense.Enabled = !IsLicenseIssued && LocalDrivingLicenseApplication.Status != clsApplication.enApplicationStatus.Cancelled && PassedTestsCount == 3;
            contextCancelApplication.Enabled = !IsLicenseIssued && LocalDrivingLicenseApplication.Status == clsApplication.enApplicationStatus.New;

            contextShowLicenseInfo.Enabled = IsLicenseIssued;

            contextVisionTest.Enabled =  PassedTestsCount == 0;
            contextWrittenTest.Enabled = PassedTestsCount == 1;
            contextStreetTest.Enabled = PassedTestsCount == 2;
           
          
        }
    }
}
