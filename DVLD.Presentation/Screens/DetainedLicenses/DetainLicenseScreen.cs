using System;
using System.Windows.Forms;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;
namespace DVLD_WindowsForms.Screens.Applications.DetainLicenseApplication
{
    public partial class DetainLicenseScreen : DialogToInherit
    {
        public DetainLicenseScreen()
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
            btnDetainLicense.Enabled = false;
            ctrlFindLocalLicense1.DisableFilter();
            MessageBox.Show("License Detained Successfully", "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


        }

        private void ctrlFindLocalLicense1_OnSelected()
        {

            if (ctrlFindLocalLicense1.License.IsExpired)
            {
                ctrlFindLocalLicense1.Clear();
                btnDetainLicense.Enabled = false;
                MessageBox.Show($"License Is Expired !", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!ctrlFindLocalLicense1.License.IsActive)
            {
                ctrlFindLocalLicense1.Clear();
                btnDetainLicense.Enabled = false;
                MessageBox.Show($"License Is Not Active !", "Not Active License", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (ctrlFindLocalLicense1.License.IsDetained)
            {
                ctrlFindLocalLicense1.Clear();
                btnDetainLicense.Enabled = false;
                MessageBox.Show($"License Is Already Detained !", "Already Detained License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();
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
            if (string.IsNullOrWhiteSpace(tbFineFees.Text))
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
    }
}
