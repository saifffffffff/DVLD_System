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
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Licenses
{
    public partial class IssueDrivingLicenseScreen : DialogToInherit
    {
        int _LocalDrivingLicenseApplicationID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public IssueDrivingLicenseScreen(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseID;
        }

        private void IssueDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            tbNotes.Focus();

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_LocalDrivingLicenseApplicationID);

            if ( _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"Local Driving License Application With ID {_LocalDrivingLicenseApplicationID} Not Found");
                Close();
                return;
            }

            if ( !_LocalDrivingLicenseApplication.PassedAllTests)
            {
                MessageBox.Show("Cannot Issue Driving License Because The Applicant Has Not Passed All Required Tests" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                Close();
                return;
            }

            int LicenseId = clsLicense.GetActiveLicenseId(_LocalDrivingLicenseApplication.ApplicantPersonId, _LocalDrivingLicenseApplication.LicenseClassID);

            if ( LicenseId != -1 )
            {
                MessageBox.Show("Person already has License before with License ID = "+ LicenseId.ToString() , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            ctrlLocalDrivingLicenseApplicationInfo1.LoadInfo(_LocalDrivingLicenseApplicationID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int LicenseId = _LocalDrivingLicenseApplication.IssueDrivingLicenseFirstTime(clsGlobal.SystemUser.Id , tbNotes.Text);

            if ( LicenseId != -1 )
            {
                MessageBox.Show("Saved Successfully" , "Saved" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                Close();
            }
           
            else
            {
                MessageBox.Show("Somthing Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }
    }
}
