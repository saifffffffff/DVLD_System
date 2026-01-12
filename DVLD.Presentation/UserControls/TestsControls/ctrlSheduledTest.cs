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

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlSheduledTest : UserControl
    {

        private clsTestAppointment _TestAppointment;
        private clsTest _Test;
        
        public ctrlSheduledTest()
        {
            InitializeComponent();
        }

        public int TestId { get; private set; } = -1;

        private void _Fill()
        {
            gbTestType.Text = _TestAppointment.TestType.Title;
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblDrivingClass.Text = _TestAppointment.LocalDrivingLicenseApplication.LicenseClass.Name;
            lblFees.Text = _TestAppointment.PaidFees.ToString("F2");
            lblFullName.Text = _TestAppointment.LocalDrivingLicenseApplication.ApplicantPerson.FullName;
            lblLocalDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationId.ToString();
            lblTitle.Text = _TestAppointment.TestType.Title;
            lblTrial.Text = clsTestAppointment.GetTestTrials(_TestAppointment.LocalDrivingLicenseApplicationId, _TestAppointment.TestTypeId).ToString();
            
            if (TestId != -1 )
            {
                lblTestID.Text = TestId.ToString();
            }

        }

        
        public void LoadTestInfo(int TestAppointmentId)
        {
            _TestAppointment = clsTestAppointment.GetById(TestAppointmentId);

            if ( _TestAppointment == null )
            {
                MessageBox.Show($"Test Appointment With Id {TestAppointmentId} Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ParentForm.Close();
                return;
            }

            _Test = clsTest.GetByTestAppointmentId(TestAppointmentId);

            if ( _Test != null )
                TestId = _Test.Id;
            
            _Fill();

        }
    }
}
