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
        int _LocalDrivingLicenseID = -1;
        clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        clsLicense _License;
        public IssueDrivingLicenseScreen(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
        }

        private void IssueDrivingLicenseScreen_Load(object sender, EventArgs e)
        {
            
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_LocalDrivingLicenseID);

            if ( _LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"Local Driving License Application With ID {_LocalDrivingLicenseID} Not Found");
                Close();
                return;
            }

            ctrlLocalDrivingLicenseApplicationInfo1.LoadInfo(_LocalDrivingLicenseID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _License = new clsLicense(); 

            clsDriver Driver = clsDriver.GetByPersonId(_LocalDrivingLicenseApplication.ApplicantPersonId);

            if (Driver == null) {
                
                Driver = new clsDriver();
                Driver.PersonId = _LocalDrivingLicenseApplication.ApplicantPersonId;
                Driver.CreatedDate = DateTime.Now;
                Driver.CreatedByUserId = clsGlobal.SystemUser.Id;
                
                if ( !Driver.Save() )
                {
                    MessageBox.Show("Somthing Went Wrong" , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    Close();
                    return;
                }

            }
            
            _License.ApplicationId = _LocalDrivingLicenseApplication.ApplicationId;
            _License.LicenseClassId = _LocalDrivingLicenseApplication.LicenseClassID;
            _License.CreatedByUserId = clsGlobal.SystemUser.Id;
            _License.PaidFees = _LocalDrivingLicenseApplication.PaidFees;
            _License.IssueReason = clsLicense.enIssueReason.FirstTime;
            _License.IssueDate = DateTime.Now;
            _License.ExpirationDate = DateTime.Now.AddYears(_LocalDrivingLicenseApplication.LicenseClass.DefaultValidityLength);
            _License.Notes = tbNotes.Text;
            _License.IsActive = true;
            _License.DriverId = Driver.Id;
            

           if ( _License.Save() )
           {
                MessageBox.Show("Saved Successfully" , "Saved" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                Close(); return;
           }
           
           else
           {
                MessageBox.Show("Somthing Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
           }
            
        }
    }
}
