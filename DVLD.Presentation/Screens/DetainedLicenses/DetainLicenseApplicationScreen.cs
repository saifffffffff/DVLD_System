using System;
using System.Windows.Forms;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;
namespace DVLD_WindowsForms.Screens.Applications.DetainLicenseApplication
{
    public partial class DetainLicenseApplicationScreen : DialogToInherit
    {
        public DetainLicenseApplicationScreen()
        {
            InitializeComponent();
        }


        private void DetainLicenseApplicationScreen_Load(object sender, System.EventArgs e)
        {
            lblCreatedByUser.Text = clsGlobal.SystemUser.Username;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnDetainLicense_Click(object sender, System.EventArgs e)
        {
            if (ctrlFindLocalLicense1.License == null) return;

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Fill Required Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;



            int DetainedLicenseId = ctrlFindLocalLicense1.License.Detain(decimal.Parse(tbFineFees.Text.Trim()), clsGlobal.SystemUser.Id);

            if (DetainedLicenseId == -1)
            {
                MessageBox.Show("License Detain Failed", "License Detain Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            lblDetainID.Text = DetainedLicenseId.ToString();
            ctrlFindLocalLicense1.RefreshInfo();
            ctrlFindLocalLicense1.DisableFilter();
            btnDetainLicense.Enabled = false;
            lnkShowLicenseInfo.Visible = true;
            MessageBox.Show("License Detained Successfully", "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


        }

        private void _ShowMessageBoxError(string message)
        {
            ctrlFindLocalLicense1.Clear();
            btnDetainLicense.Enabled = false;
            lnkShowLicenseHistory.Visible = false;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ctrlFindLocalLicense1_OnSelected()
        {

            if (ctrlFindLocalLicense1.License.IsExpired)
            {
                _ShowMessageBoxError($"License Is Expired !");
            }
            else if (!ctrlFindLocalLicense1.License.IsActive)
            {
                _ShowMessageBoxError("License Is Not Active !");
            }
            else if (ctrlFindLocalLicense1.License.IsDetained)
            {
                _ShowMessageBoxError("License Is Already Detained !");
            }
            else
            {
                lblLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();
                lnkShowLicenseHistory.Visible = true;
                btnDetainLicense.Enabled = true;
            }
        }

        private void tbFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '.' && !tbFineFees.Text.Contains(".")) || e.KeyChar == '\b')
                e.Handled = false;
            else
                e.Handled = true;


        }

        private void tbFineFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFineFees, "Fine Fees is required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFineFees, "");
            }

        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ( ctrlFindLocalLicense1.License == null) return;
            clsGlobal.ShowDialog(new Licenses.ShowPersonLicenseHistoryScreen(ctrlFindLocalLicense1.License.Application.ApplicantPersonId), true);
        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrlFindLocalLicense1.License == null) return;
            clsGlobal.ShowDialog(new Licenses.ShowLicenseInfoScreen(ctrlFindLocalLicense1.License.Id),  true);
        }
    }
}
