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
        int _LocalDrivingLicenseApplicationId;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsTestType.enTestTypes _TestType;

        public ShowAllTestAppointmentsScreen(int LocalDrivingLicenseApplicationId, int TestTypeId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationId= LocalDrivingLicenseApplicationId;
            _TestType = (clsTestType.enTestTypes)TestTypeId;
        }

        private void _InitDataGrid()
        {

            var view = clsTestAppointment.GetAllByLocalDrivingLicenseAppIdAndTestTypeId(_LocalDrivingLicenseApplicationId, (int)_TestType).DefaultView;
            
            dgvApps.DataSource = view.ToTable("TestAppoitn" , false , "TestAppointmentID", "AppointmentDate" , "PaidFees" ,  "IsLocked");
            
            dgvApps.Columns[0].HeaderText = "Appointment ID";
            dgvApps.Columns[1].HeaderText = "Appointment Date";
            dgvApps.Columns[2].HeaderText = "Paid Fees";
            dgvApps.Columns[3].HeaderText = "Is Locked";
        }
        private void _LoadTestTypeImage()
        {
            switch (_TestType)
            {
                case clsTestType.enTestTypes.VisionTest:
                    pictureBox1.Image = Resources.Vision_512;
                    break;
                case clsTestType.enTestTypes.WrittenTest:
                    pictureBox1.Image = Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointments Management";
                    break;
                case clsTestType.enTestTypes.PracticalTest:
                    pictureBox1.Image = Resources.driving_test_512;
                    lblTitle.Text = "Street Test Appointments Management";
                    break;
            } 
        }
       
        private void ShowAllTestAppointmentsScreen_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_LocalDrivingLicenseApplicationId);
            
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error loading application data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            localDrivingLicenseApplicationInfo1.LoadInfo(_LocalDrivingLicenseApplicationId);
            
            _InitDataGrid();
            _LoadTestTypeImage();

        }
        
        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            bool IsLastTestAppointmentActive = clsLocalDrivingLicenseApplication.IsLastScheduledTestActive(_LocalDrivingLicenseApplicationId , (int)_TestType);
            
            if (IsLastTestAppointmentActive)
            {
                MessageBox.Show("The last scheduled test appointment is not yet locked. You cannot schedule a new appointment until the previous one is completed and locked.", "Cannot Schedule New Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (_LocalDrivingLicenseApplication.IsTestPassed(_TestType))
            {
                MessageBox.Show("The person already passed this test before, you can only retake failed tests", "Cannot Schedule New Appointment" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsGlobal.ShowDialog(new AddUpdateTestAppointmentScreen((int)_TestType, _LocalDrivingLicenseApplicationId), true);
            
            _InitDataGrid();
            
        }

        private void contextEdit_Click(object sender, EventArgs e)
        {
           int TestAppointmentId = (int)dgvApps.CurrentRow.Cells[0].Value;

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
