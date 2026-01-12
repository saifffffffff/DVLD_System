using System;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Applications.ReplaceDrivingLicenseApplication
{
    public partial class ReplaceDrivingLicenseApplicationScreen : DialogToInherit
    {
        public ReplaceDrivingLicenseApplicationScreen()
        {
            InitializeComponent();
        }

        private void ReplaceDrivingLicenseApplicationScreen_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.SystemUser.Username;
            rbDamagedLicense.Checked = true;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = rbDamagedLicense.Checked ? clsApplicationType.GetById((int)clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense).Fees.ToString() : clsApplicationType.GetById((int)clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense).Fees.ToString();
        }

        private void ctrlFindLocalLicense1_OnSelected()
        {

            if ( !ctrlFindLocalLicense1.License.IsActive)
            {
                MessageBox.Show($"License Is Not With ID {ctrlFindLocalLicense1.License.Id} Active");
                return;
            }
            else if ( ctrlFindLocalLicense1.License.IsDetained)
            {
                MessageBox.Show($"License Is With ID {ctrlFindLocalLicense1.License.Id} Detained");
                return;
            }
            else
            {
                lblOldLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();
                btnReplaceLicense.Enabled = true;
            }
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {

            if (ctrlFindLocalLicense1.License == null) return;

            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLicense NewLicense = rbDamagedLicense.Checked ? ctrlFindLocalLicense1.License.ReplaceForDamaged(clsGlobal.SystemUser.Id) : ctrlFindLocalLicense1.License.ReplaceForLost(clsGlobal.SystemUser.Id);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationId.ToString();
            lblRreplacedLicenseID.Text = NewLicense.Id.ToString();
            ctrlFindLocalLicense1.RefreshInfo();
            ctrlFindLocalLicense1.DisableFilter();
            btnReplaceLicense.Enabled = false;
            gbReplacementFor.Enabled = false;

            MessageBox.Show("Licensed Replaced Successfully with ID=" + NewLicense.Id.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);





        }
    }
}
