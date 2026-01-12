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

namespace DVLD_WindowsForms.Screens.TestAppointments
{
    public partial class AddUpdateTestAppointmentScreen : DialogToInherit
    {
        enum enMode         {
            AddAppointment,
            UpdateAppointment
        }

        enMode _Mode;

        private int _TestTypeId = -1;
        private clsTestType _TestType;

        private int _LocalDrivingLicenseApplicationId = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;

        private int _TestAppointmentId = -1;
        private clsTestAppointment _TestAppointment = null;

        int _TestTrials;
        
        clsApplication _RetakeTestApplication ;

        // Add
        public AddUpdateTestAppointmentScreen(int TestTypeId, int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            
            _TestTypeId = TestTypeId;
            _LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            
            _Mode = enMode.AddAppointment;
        }
        
        // Update
        public AddUpdateTestAppointmentScreen(int TestAppointmentId)
        {
            InitializeComponent();
            _TestAppointmentId = TestAppointmentId;
            _Mode = enMode.UpdateAppointment;
        }


        private void _SetDefaultValues()
        {

            decimal totalFees = 0;

            lblTitle.Text = $"Schedule {_TestType.Title} Appointment";
            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.Id.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClass.Name;
            lblFullName.Text = _LocalDrivingLicenseApplication.ApplicantPerson.FullName;
            lblFees.Text = _TestType.Fees.ToString("F2");

            _TestTrials = clsTestAppointment.GetTestTrials(_LocalDrivingLicenseApplication.Id, _TestType.Id);

            lblTrial.Text = _TestTrials.ToString();

            dtpTestDate.Value = DateTime.Now;


            totalFees += _TestType.Fees;

            // if we are updating a schedualed test appointment this its retake test app is not null and test trials bigger than zero
            // if we are scheduling new test appointment then the mode is add and test trails bigger than 0
            if (_TestTrials > 0 && (_RetakeTestApplication != null || _Mode == enMode.AddAppointment) ) 
            {                
                totalFees += 5;
                lblRetakeAppFees.Text = "5";
                lblRetakeTestAppID.Text = _RetakeTestApplication != null ? _RetakeTestApplication.Id.ToString() : "N/A";
            }

            else
            {
                lblRetakeAppFees.Text = "0.00";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblTotalFees.Text = totalFees.ToString("F2");


            
        }

        
        private void _FillFromTestAppointment()
        {

            _TestType = clsTestType.GetById(_TestAppointment.TestTypeId);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_TestAppointment.LocalDrivingLicenseApplicationId);
            _RetakeTestApplication = clsApplication.GetById(_TestAppointment.RetakeTestApplicationId);
            _SetDefaultValues();

            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            
            if ( _TestAppointment.IsLocked )
                btnSave.Enabled = false;
            
            

        }
        private void _FillToTestAppointment()
        {
            if (_Mode == enMode.AddAppointment)
            {
                _TestAppointment.AppointmentDate = dtpTestDate.Value;
                _TestAppointment.TestTypeId = _TestTypeId;
                _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
                _TestAppointment.IsLocked = false;
                _TestAppointment.CreatedByUserId = clsGlobal.SystemUser.Id;
                _TestAppointment.LocalDrivingLicenseApplicationId = _LocalDrivingLicenseApplicationId;


                // Handle This , if this is not the first time apply an application for retaking exam
                if  (_TestTrials > 0 )
                {
                    _RetakeTestApplication = new clsApplication();
                    _RetakeTestApplication.ApplicantPersonId = _LocalDrivingLicenseApplication.ApplicantPersonId;
                    _RetakeTestApplication.Status = clsApplication.enApplicationStatus.New;
                    _RetakeTestApplication.CreatedByUserId = clsGlobal.SystemUser.Id;
                    _RetakeTestApplication.ApplicationTypeId = (int)clsApplicationType.enApplicationType.RetakeTest;
                    _RetakeTestApplication.Date = DateTime.Now;
                    _RetakeTestApplication.LastStatusDate = DateTime.Now;
                    _RetakeTestApplication.PaidFees = 5;
                }
                else 
                    _TestAppointment.RetakeTestApplicationId = -1;
            }

            _TestAppointment.AppointmentDate = dtpTestDate.Value;

            

        }

        private void ScheduleTestAppointment_Load(object sender, EventArgs e)
        {



            if (_Mode == enMode.AddAppointment)
            {
                _TestType = clsTestType.GetById(_TestTypeId);
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_LocalDrivingLicenseApplicationId);
                _TestAppointment = new clsTestAppointment();
                _SetDefaultValues();
            }

            else
            {
                _TestAppointment = clsTestAppointment.GetById(_TestAppointmentId);
                if (_TestAppointment == null) {
                    MessageBox.Show($"Test Appointment with id {_TestAppointmentId} not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                _FillFromTestAppointment();
                lblTitle.Text = $"Update {_TestType.Title} Appointment";

            }

            clsTestType.enTestTypes testType = (clsTestType.enTestTypes)_TestTypeId;

            switch (testType)
            {

                case clsTestType.enTestTypes.VisionTest:
                    pbTestImage.Image = Resources.Vision_512;
                    break;

                case clsTestType.enTestTypes.WrittenTest:
                    pbTestImage.Image = Resources.Written_Test_512;
                    break;

                case clsTestType.enTestTypes.PracticalTest:
                    pbTestImage.Image = Resources.Schedule_Test_512;
                    break;

            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            _FillToTestAppointment();

            if (_RetakeTestApplication != null)
            {
                _RetakeTestApplication.Save();
                _TestAppointment.RetakeTestApplicationId = _RetakeTestApplication.Id;
            }

            if ( _TestAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully");
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Appointment Is not Saved");

            }
        }
    }
}
