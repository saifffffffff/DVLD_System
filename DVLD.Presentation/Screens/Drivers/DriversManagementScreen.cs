using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Licenses;
namespace DVLD_WindowsForms.Screens.Drivers
{
    public partial class DriversManagementScreen : ScreenToInherit
    {

        private DataTable _dtDrivers = clsDriver.GetAll();
        private DataView _view;

        public DriversManagementScreen()
        {
            InitializeComponent();
        }

        private void InitDataGridView()
        {

            _view = _dtDrivers.DefaultView;
            dgvDrivers.DataSource = _view;

            if (dgvDrivers.Rows.Count > 0)
            {

                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width= 125;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 125;

                dgvDrivers.Columns[2].HeaderText = "Create By User ID";
                dgvDrivers.Columns[2].Width= 125;

                dgvDrivers.Columns[3].HeaderText = "Created At";
                
                dgvDrivers.Columns[4].HeaderText = "Active Licenses";
                dgvDrivers.Columns[4].Width= 200;

                dgvDrivers.Columns[5].HeaderText = "Full Name";
                dgvDrivers.Columns[5].Width = 400;
                
                dgvDrivers.Columns[6].HeaderText = "National No";
                dgvDrivers.Columns[6].Width = 200;
                
            }



        }
        private void DriversScreen_Load(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void contextShowPersonLicensesHistory_Click(object sender, EventArgs e)
        {
            int SelectedPersonId = (int)dgvDrivers.SelectedRows[0].Cells[1].Value;

            clsGlobal.ShowDialog(new ShowPersonLicenseHistoryScreen(SelectedPersonId));
            
        }
    }
}
