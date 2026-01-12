using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Properties;
using DVLD_WindowsForms.Screens.Core;
using DVLD_WindowsForms.Screens.TestAppointments;
using DVLD_WindowsForms.Screens.Tests;
using DVLD_WindowsForms.UserControls;

namespace DVLD_WindowsForms.Screens.TestsManagement
{
    public partial class ShowAllTestAppointmentsScreen : DialogToInherit
    {
        int _LocalDrivingLicenseId = -1;
        int _TestTypeId = -1;

        public ShowAllTestAppointmentsScreen(int LocalDrivingLicenseId, int TestTypeId)
        {
            InitializeComponent();
            _LocalDrivingLicenseId = LocalDrivingLicenseId;
            _TestTypeId = TestTypeId;
        }

        private void _InitDataGrid()
        {

            var view = clsTestAppointment.GetAllByLocalDrivingLicenseAppIdAndTestTypeId(_LocalDrivingLicenseId, _TestTypeId).DefaultView;
            
            dgvApps.DataSource = view.ToTable("TestAppoitn" , false , "TestAppointmentID", "AppointmentDate" , "PaidFees" ,  "IsLocked");
            
            dgvApps.Columns[0].HeaderText = "Appointment ID";
            dgvApps.Columns[1].HeaderText = "Appointment Date";
            dgvApps.Columns[2].HeaderText = "Paid Fees";
            dgvApps.Columns[3].HeaderText = "Is Locked";
        }

        private void VisionTestScreen_Load(object sender, EventArgs e)
        {
            localDrivingLicenseApplicationInfo1.LoadInfo(_LocalDrivingLicenseId);
            _InitDataGrid();

            if (_TestTypeId == 2)
            {
                pictureBox1.Image = Resources.Written_Test_512;
            }

            else if (  _TestTypeId == 3)
            {
                pictureBox1.Image = Resources.driving_test_512;
            }

        }
        
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            bool IsLastTestAppointmentLocked = dgvApps.Rows.Count == 0 ? true : (bool)dgvApps.Rows[0].Cells["IsLocked"].Value;
            bool IsPassed = clsLocalDrivingLicenseApplication.CountPassedTests(_LocalDrivingLicenseId) >= _TestTypeId;
            
            if (!IsLastTestAppointmentLocked)
            {
                MessageBox.Show("The last scheduled test appointment is not yet locked. You cannot schedule a new appointment until the previous one is completed and locked.", "Cannot Schedule New Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsPassed)
            {
                MessageBox.Show("The person already passed this test before, you can only retake failed tests", "Cannot Schedule New Appointment" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsGlobal.ShowDialog(new AddUpdateTestAppointmentScreen(_TestTypeId, _LocalDrivingLicenseId), true);
            
            _InitDataGrid();
            
            

        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
           int TestAppointmentId = (int)dgvApps.SelectedRows[0].Cells[0].Value;

            clsGlobal.ShowDialog(new AddUpdateTestAppointmentScreen(TestAppointmentId), true);
            
            _InitDataGrid();
        }

        private void contextTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentId = (int)dgvApps.SelectedRows[0].Cells[0].Value;
            
            clsGlobal.ShowDialog(new TakeTestScreen(TestAppointmentId), true);
          
            _InitDataGrid();
            localDrivingLicenseApplicationInfo1.RefreshApplicationInfo();
        }
    }
}
