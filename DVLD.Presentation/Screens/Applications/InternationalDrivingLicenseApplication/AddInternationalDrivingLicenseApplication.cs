using System;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Applications.InternationalDrivingLicenseApplication
{
    public partial class AddInternationalDrivingLicenseApplication : DialogToInherit
    {

        int _InternationalLicenseId = -1;
        public AddInternationalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        
        private void AddInternationalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.SystemUser.Username;
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

        }

        private void lnkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsGlobal.ShowDialog( new Licenses.ShowPersonLicenseHistoryScreen(ctrlFindLocalLicense1.License.Application.ApplicantPersonId), true );
        }
        
        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ( _InternationalLicenseId == -1 ) return;

            clsGlobal.ShowDialog(new InternationalLicenses.ShowInternationalLicenseInfo(_InternationalLicenseId) , true);
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {



            if (ctrlFindLocalLicense1.License == null) return;

            if (MessageBox.Show("Are you sure you want to Issue an international license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            var _InternationalLicense = new clsInternationalLicense();

            // filling on the application info
            _InternationalLicense.Application = new clsApplication();
            _InternationalLicense.Application.ApplicantPersonId = ctrlFindLocalLicense1.License.Application.ApplicantPersonId;
            _InternationalLicense.Application.ApplicationTypeId = (int)clsApplicationType.enApplicationType.NewInternationalLicense;
            _InternationalLicense.Application.CreatedByUserId = clsGlobal.SystemUser.Id;
            _InternationalLicense.Application.Date = DateTime.Now;
            _InternationalLicense.Application.Status = clsApplication.enApplicationStatus.New;
            _InternationalLicense.Application.PaidFees = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.NewInternationalLicense).Fees;
            _InternationalLicense.Application.LastStatusDate = DateTime.Now;

            // filling on the international license info
            _InternationalLicense.DriverId = ctrlFindLocalLicense1.License.DriverId;
            _InternationalLicense.IssuedUsingLocalLicenseId = ctrlFindLocalLicense1.License.Id;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.IsActive = true;
            _InternationalLicense.CreatedByUserId = clsGlobal.SystemUser.Id;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);



            if (_InternationalLicense.Save())
            {
                lblApplicationID.Text = _InternationalLicense.Application.Id.ToString();
                lblInternationalLicenseID.Text = _InternationalLicense.Id.ToString();
                lnkShowLicenseInfo.Enabled = true;
                ctrlFindLocalLicense1.DisableFilter();
                btnIssueLicense.Enabled = false;
                _InternationalLicenseId = _InternationalLicense.Id;
                MessageBox.Show("Issued Successfully");
            }
            else
            {
                MessageBox.Show("Not Issued", "Somthing Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }



        }

        private void _ShowMessageBoxError(string message)
        {
            ctrlFindLocalLicense1.Clear();
            lblLocalLicenseID.Text = "[???]";
            btnIssueLicense.Enabled = false;
            lnkShowLicensesHistory.Enabled = false;
            lnkShowLicenseInfo.Enabled = false;
            MessageBox.Show(message);
        }
        private void ctrlFindLocalLicense1_OnSelected()
        {
            if (ctrlFindLocalLicense1.License.LicenseClassId != (int)clsLicenseClass.enLicenseClass.OrdinaryDiving)
                _ShowMessageBoxError("License Class Must Be Ordinary");

            else if (ctrlFindLocalLicense1.License.IsExpired)
                _ShowMessageBoxError("License Is Expired");
            
            else if (ctrlFindLocalLicense1.License.IsDetained)
                _ShowMessageBoxError("License Is Detained");    
            
            else if (clsInternationalLicense.HasActiveInternationalDrivingLicense(ctrlFindLocalLicense1.License.DriverId))
                _ShowMessageBoxError("Driver Has Active International Driving License");
            
            else
            {
                lblLocalLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();
                lnkShowLicensesHistory.Enabled = lnkShowLicensesHistory.Enabled = true;
                btnIssueLicense.Enabled = false;
                ctrlFindLocalLicense1.DisableFilter();
            }

        }
    }
}
