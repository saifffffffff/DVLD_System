using System;
using System.Data;
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

        private DataTable _apps = clsLocalDrivingLicenseApplication.GetAll();
        private DataView _view;

        public LocalDrivingLicenseApplicationsManagementScreen()
        {
            InitializeComponent();
        }

        private void _refreshAppsGrid()
        {
            _view = clsLocalDrivingLicenseApplication.GetAll().DefaultView;
            dgvApps.DataSource = _view;
        }

        private void LocalDrivingLicenseApplicationsManagement_Load(object sender, EventArgs e)
        {
            _view = _apps.DefaultView;
            
            dgvApps.DataSource = _view;

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
            _refreshAppsGrid();
        }


        // Filtering 
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filter = cbFilter.SelectedItem.ToString();

            _view.RowFilter = "";
            
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
                _view.RowFilter = "";

            else if ( FilterColumn.Contains("ID")) 
                    _view.RowFilter = $"{FilterColumn }= {SearchText}";
            
            else
                _view.RowFilter = $"{FilterColumn} Like '{SearchText}%'";
        
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
                _view.RowFilter = "";
                return;
            }

            _view.RowFilter = $"Status Like '{Status}'";

            
            
        }


        // Context Menu 
        private void contextShowDetails_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new ShowLocalDrivingLicenseApplicationInfo((int)dgvApps.SelectedRows[0].Cells[0].Value));
            _refreshAppsGrid();
        }

        private void contextVisionTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId , (int)clsTestType.enTestTypes.VisionTest));
            _refreshAppsGrid();
        }

        private void contextWrittenTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId, (int)clsTestType.enTestTypes.WrittenTest));
            _refreshAppsGrid();

        }

        private void contextStreetTest_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowAllTestAppointmentsScreen(SelectedAppId, (int)clsTestType.enTestTypes.PracticalTest));
            _refreshAppsGrid();

        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new AddUpdateLocalDrivingLicenseApplicationScreen(SelectedAppId));
            _refreshAppsGrid();
        }
       
        private void contextIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new IssueDrivingLicenseScreen(SelectedAppId));
            _refreshAppsGrid();

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;

            var Application = clsLocalDrivingLicenseApplication.GetById(SelectedAppId);

            if (Application.Status != clsApplication.enApplicationStatus.New)
            {
                contextEdit.Enabled = false;
                contextDelete.Enabled = false;
                contextScheduleTest.Enabled = false;
                contextIssueDrivingLicense.Enabled = false;
                contextCancelApplication.Enabled = false;
                
                contextShowLicenseInfo.Enabled = Application.Status == clsApplication.enApplicationStatus.Completed ?  true : false;
                    return;
            }

            // New Status 

            contextIssueDrivingLicense.Enabled = false;
            contextEdit.Enabled = true;
            contextDelete.Enabled = true;
            contextScheduleTest.Enabled = true;
            contextCancelApplication.Enabled = true;
            contextShowLicenseInfo.Enabled = false ;

            if (Application.PassedTestsCount == 0)
            {
                contextVisionTest.Enabled = true;
                contextWrittenTest.Enabled = false;
                contextStreetTest.Enabled = false;
            }
            
            else if (Application.PassedTestsCount == 1)
            {
                contextVisionTest.Enabled = false;
                contextWrittenTest.Enabled = true;
                contextStreetTest.Enabled = false;
            }
            
            else if (Application.PassedTestsCount == 2)
            {
                contextVisionTest.Enabled = false;
                contextWrittenTest.Enabled = false;
                contextStreetTest.Enabled = true;
            }

            // Issue a local driving license
            else
            {
                contextEdit.Enabled = true;
                contextDelete.Enabled = true;
                contextScheduleTest.Enabled = false;
                contextIssueDrivingLicense.Enabled = true;
            }
            
          
        }

        private void contextCancelApplication_Click(object sender, EventArgs e)
        {
            int SelectedAppId = (int)dgvApps.SelectedRows[0].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to cancel this application ?" , "" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsLocalDrivingLicenseApplication.GetById(SelectedAppId).Cancel())
                {
                    MessageBox.Show("Application Canceled Successfully");
                    _refreshAppsGrid();
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
            string SelectedNationalNo = dgvApps.SelectedRows[0].Cells[2].Value.ToString();

            clsGlobal.ShowDialog(new ShowPersonLicenseHistoryScreen(clsPerson.GetByNationalNo(SelectedNationalNo).Id));

        }
    }
}
