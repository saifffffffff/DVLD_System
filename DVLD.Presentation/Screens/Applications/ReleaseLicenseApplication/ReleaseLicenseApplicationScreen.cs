using System;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Applications.ReleaseLicenseApplication
{
    public partial class ReleaseLicenseApplicationScreen : DialogToInherit
    {

        int _LicenseId = -1;
        clsDetainedLicense _DetainedLicense;
        public ReleaseLicenseApplicationScreen()
        {
            InitializeComponent();
        }

        public ReleaseLicenseApplicationScreen(int LicenseId)
        {
            InitializeComponent();
            _LicenseId = LicenseId;
            ctrlFindLocalLicense1.LoadLicenseInfo(_LicenseId);
            ctrlFindLocalLicense1.DisableFilter();
        }

        private void ctrlFindLocalLicense1_OnSelected()
        {
            if ( !ctrlFindLocalLicense1.License.IsDetained)
            {
                ctrlFindLocalLicense1.Clear();
                MessageBox.Show($"License Is Not Detained", "Not Detained License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _DetainedLicense = clsDetainedLicense.GetDetainedLicenseByLicenseId(ctrlFindLocalLicense1.License.Id);

                lblCreatedByUser.Text = clsGlobal.SystemUser.Username;

                lblLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();
                
                lblDetainID.Text = _DetainedLicense.Id.ToString();
                lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
                lblFineFees.Text = _DetainedLicense.FineFees.ToString("F2");
                
                lblApplicationFees.Text = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.ReleaseDetainedDrivingLicense).Fees.ToString();
                lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

                btnReleaseLicense.Enabled = true;
            }
        }

        private void ctrlFindLocalLicense1_OnNotFound()
        {
             // paramertarized constructor is used
             if (_LicenseId != -1 )
            {
                this.Close();
            }
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to Release this license ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            int AppId = -1;
            if  ( _DetainedLicense.Release(clsGlobal.SystemUser.Id , ref AppId))
            {
                lblApplicationID.Text = AppId.ToString();
                MessageBox.Show("License Released Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlFindLocalLicense1.RefreshInfo();
                btnReleaseLicense.Enabled = false;
                ctrlFindLocalLicense1.DisableFilter();
            }
            else
            {
                MessageBox.Show("Failed to Release the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
