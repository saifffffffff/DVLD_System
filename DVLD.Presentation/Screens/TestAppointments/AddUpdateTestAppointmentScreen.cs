using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private int _testTypeId = -1;
        private clsTestType _testType;

        private int _localDrivingLicenseApplicationId = -1;
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication ;

        private int _testAppointmentId = -1;
        private clsTestAppointment _testAppointment ;

        bool _isRetakeTest;
        
        clsApplication _retakeTestApplication ;

        // Add
        public AddUpdateTestAppointmentScreen(int TestTypeId, int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            
            _testTypeId = TestTypeId;
            _localDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            
            _Mode = enMode.AddAppointment;
        }
        
        // Update
        public AddUpdateTestAppointmentScreen(int TestAppointmentId)
        {
            InitializeComponent();
            _testAppointmentId = TestAppointmentId;
            _Mode = enMode.UpdateAppointment;
        }


        private void _LoadTestTypeImageAndTitle()
        {
            switch ((clsTestType.enTestTypes)_testTypeId)
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
     
        private void _SetDefaultValues()
        {

            decimal totalFees = 0;

            lblTitle.Text = $"Schedule {_testType.Title} Appointment";
            lblLocalDrivingLicenseAppID.Text = _localDrivingLicenseApplication.Id.ToString();
            lblDrivingClass.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            lblFullName.Text = _localDrivingLicenseApplication.ApplicantPerson.FullName;
            lblFees.Text = _testType.Fees.ToString("F2");
            lblTrial.Text = _localDrivingLicenseApplication.CountTestTrials(_testType.Id).ToString();

            dtpTestDate.Value = DateTime.Now;

            _isRetakeTest = _localDrivingLicenseApplication.DoesAttendTestBefore(_testTypeId);

            totalFees += _testType.Fees;

            // if we are updating a schedualed test appointment this its retake test app is not null and test trials bigger than zero
            // if we are scheduling new test appointment then the mode is add and test trails bigger than 0
            if (_isRetakeTest && (_retakeTestApplication != null || _Mode == enMode.AddAppointment) ) 
            {                
                decimal retakeTestFees = clsApplicationType.GetById( (int)clsApplicationType.enApplicationType.RetakeTest).Fees;
                totalFees += retakeTestFees;
                lblRetakeAppFees.Text = retakeTestFees.ToString("F2");
                lblRetakeTestAppID.Text = _retakeTestApplication != null ? _retakeTestApplication.Id.ToString() : "N/A";
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

            _testType = clsTestType.GetById(_testAppointment.TestTypeId);
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_testAppointment.LocalDrivingLicenseApplicationId);
            _retakeTestApplication = clsApplication.GetById(_testAppointment.RetakeTestApplicationId);
            _SetDefaultValues();

         

            if ( _testAppointment.IsLocked)
            {
                dtpTestDate.Value = _testAppointment.AppointmentDate;
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
            }
            else
            {
                if (DateTime.Compare(DateTime.Now, _testAppointment.AppointmentDate) < 0)
                    dtpTestDate.MinDate = DateTime.Now;
                
                else
                    dtpTestDate.Value = _testAppointment.AppointmentDate;
            }
            

        }
       
        private void _FillToTestAppointment()
        {
            if (_Mode == enMode.AddAppointment)
            {
                _testAppointment.AppointmentDate = dtpTestDate.Value;
                _testAppointment.TestTypeId = _testTypeId;
                _testAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
                _testAppointment.IsLocked = false;
                _testAppointment.CreatedByUserId = clsGlobal.SystemUser.Id;
                _testAppointment.LocalDrivingLicenseApplicationId = _localDrivingLicenseApplicationId;


                // Handle This , if this is not the first time apply an application for retaking exam
                if  ( _isRetakeTest )
                {
                    _retakeTestApplication = new clsApplication();
                    _retakeTestApplication.ApplicantPersonId = _localDrivingLicenseApplication.ApplicantPersonId;
                    _retakeTestApplication.Status = clsApplication.enApplicationStatus.New;
                    _retakeTestApplication.CreatedByUserId = clsGlobal.SystemUser.Id;
                    _retakeTestApplication.ApplicationTypeId = (int)clsApplicationType.enApplicationType.RetakeTest;
                    _retakeTestApplication.Date = DateTime.Now;
                    _retakeTestApplication.LastStatusDate = DateTime.Now;
                    _retakeTestApplication.PaidFees = 5;
                }
                else 
                    _testAppointment.RetakeTestApplicationId = -1;
            }

            _testAppointment.AppointmentDate = dtpTestDate.Value;

            

        }

        private void ScheduleTestAppointment_Load(object sender, EventArgs e)
        {


            if (_Mode == enMode.AddAppointment)
            {
                _testType = clsTestType.GetById(_testTypeId);
                _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_localDrivingLicenseApplicationId);
                _testAppointment = new clsTestAppointment();
                _SetDefaultValues();
            }

            else // Update 
            {
                _testAppointment = clsTestAppointment.GetById(_testAppointmentId);
              
                if (_testAppointment == null) {
                    MessageBox.Show($"Test Appointment with id {_testAppointmentId} not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                _FillFromTestAppointment();
                lblTitle.Text = $"Update {_testType.Title} Appointment";

            }

           
            _LoadTestTypeImageAndTitle();

            if (!_HandleActiveTestAppointmentRestriction())
                return;

            if ( !_HandlePreviousTestRestriction())
                return;



        }

        bool _HandleActiveTestAppointmentRestriction()
        {
            if (_Mode == enMode.AddAppointment && _localDrivingLicenseApplication.IsLastScheduledTestActive(_testTypeId))
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        bool _HandlePreviousTestRestriction()
        {
            switch ((clsTestType.enTestTypes)_testTypeId)
            {
                case clsTestType.enTestTypes.VisionTest:
                    return true;
                
                case clsTestType.enTestTypes.WrittenTest:
                    
                    if ( !_localDrivingLicenseApplication.HasPassedTest((int)clsTestType.enTestTypes.VisionTest) )
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Person must pass Vision Test before scheduling Written Test";
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    return true;

                case clsTestType.enTestTypes.PracticalTest:
                    if (!_localDrivingLicenseApplication.HasPassedTest((int)clsTestType.enTestTypes.WrittenTest))
                    {
                        lblUserMessage.Visible = true;
                        lblUserMessage.Text = "Person must pass Written Test before scheduling Practical Test";
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    return true;

            }

            return false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {


            _FillToTestAppointment();

            if (_retakeTestApplication != null)
            {
                if (!_retakeTestApplication.Save())
                {
                    MessageBox.Show("Retake Test Application is not saved" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                    return;
                }

                _testAppointment.RetakeTestApplicationId = _retakeTestApplication.Id;
            }

            if ( _testAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully");
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Appointment Is not Saved");
                // Rollback Retake Test Application if created
                if ( _isRetakeTest && _Mode == enMode.AddAppointment)
                    clsApplication.Delete( _retakeTestApplication.Id) ;

            }
        }
    }
}
