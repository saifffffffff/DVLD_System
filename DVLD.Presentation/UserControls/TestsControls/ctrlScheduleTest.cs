using System;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlScheduleTest : UserControlToInherite
    {
    
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApp;
        clsTestType _TestType;
        clsTestAppointment _TestAppointment;


        public clsTestAppointment TestAppointment
        {
            get { return _TestAppointment; }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        
        // Add 
        public void LoadTest( int LocalDrivingLicenseApplicationId , int TestTypeId )
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.GetById( LocalDrivingLicenseApplicationId );
            _TestType = clsTestType.GetById( TestTypeId );
            _TestAppointment = new clsTestAppointment();

            if ( _LocalDrivingLicenseApp == null || _TestType == null )
            {
                MessageBox.Show("Unable to load LocalDrivingLicenseApplication or TestType.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ParentForm.Close();
            }

            _FillFromTestAppointment();

        }
        
        // Update
        public void LoadTest(int TestAppointmentId)
        {
            _TestAppointment = clsTestAppointment.GetById( TestAppointmentId );

            if ( _TestAppointment == null)
            {
                MessageBox.Show($"Test Appointment with id {TestAppointmentId} not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ParentForm.Close();
            }

            _TestType = _TestAppointment.TestType;
            _LocalDrivingLicenseApp = _TestAppointment.LocalDrivingLicenseApplication;
            
            _FillFromTestAppointment();

        }

        void _FillFromTestAppointment()
        {
            decimal totalFees = 0;

            lblTitle.Text = $"Schedule {_TestType.Title}";
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApp.Id.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApp.LicenseClass.Name;
            lblFullName.Text = _LocalDrivingLicenseApp.ApplicantPerson.FullName;
            lblFees.Text = _TestType.Fees.ToString("F2");

            int testTrials = clsTestAppointment.GetTestTrials(_LocalDrivingLicenseApp.Id, _TestType.Id);
            lblTrial.Text = testTrials.ToString();

            
            if (_TestAppointment.Id != -1)
                dtpTestDate.Value = _TestAppointment.AppointmentDate;
            else 
                dtpTestDate.Value = DateTime.Now;
            
            
            totalFees += _TestType.Fees;
            
            if ( testTrials > 0)
            {
                totalFees += 5 ;  

            }
            
            else
            {
                lblRetakeAppFees.Text = "0.00";
                lblRetakeTestAppID.Text ="N/A";
            }

            lblTotalFees.Text = totalFees.ToString("F2");

        }
        
        void _FillToTestAppointment()
        {
            _TestAppointment.TestTypeId = _TestType.Id;
            _TestAppointment.LocalDrivingLicenseApplicationId = _LocalDrivingLicenseApp.Id;
            _TestAppointment.CreatedByUserId = clsGlobal.SystemUser.Id;
            _TestAppointment.PaidFees = decimal.Parse(lblTotalFees.Text);
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.IsLocked = false;
            _TestAppointment.RetakeTestApplicationId = lblRetakeTestAppID.Text == "N/A" ? 0 : int.Parse(lblRetakeTestAppID.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _FillToTestAppointment();

            if (_TestAppointment.Save())
            {
                MessageBox.Show("Test Appointment Scheduled Successfully.");
                this.ParentForm.Close();
            }
                
            

            else
                MessageBox.Show("Failed to Schedule Test Appointment.");

        }
    }
}
