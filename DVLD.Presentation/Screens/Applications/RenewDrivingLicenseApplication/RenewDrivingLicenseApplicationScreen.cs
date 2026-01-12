using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;
using DVLD_WindowsForms.UserControls;

namespace DVLD_WindowsForms.Screens.Applications.RenewDrivingLicenseApplication
{
    public partial class RenewDrivingLicenseApplicationScreen : DialogToInherit
    {
        public RenewDrivingLicenseApplicationScreen()
        {
            InitializeComponent();

        }

        private void RenewDrivingLicenseApplicationScreen_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.GetById((int)clsApplicationType.enApplicationType.RenewDrivingLicenseService).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.SystemUser.Username;

        }
       

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            
            clsLicense NewLicense = ctrlFindLocalLicense1.License.Renew(tbNotes.Text , clsGlobal.SystemUser.Id);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationId.ToString();
            lblRenewedLicenseID.Text = NewLicense.Id.ToString();
            ctrlFindLocalLicense1.RefreshInfo();

            MessageBox.Show("Licensed Renewed Successfully with ID=" + NewLicense.Id.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenewLicense.Enabled = false;
            ctrlFindLocalLicense1.DisableFilter();
            
            
             
            

        }

        private void ctrlFindLocalLicense1_OnSelected()
        {
            if (!ctrlFindLocalLicense1.License.IsActive)
            {
                ctrlFindLocalLicense1.Clear();
                btnRenewLicense.Enabled = false;
                MessageBox.Show($"License Is Not Active !", "Not Active License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (!ctrlFindLocalLicense1.License.IsExpired)
            {
                ctrlFindLocalLicense1.Clear();
                btnRenewLicense.Enabled = false;
                MessageBox.Show($"License Is Not Expired Yet !", "Not Expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ctrlFindLocalLicense1.License.IsDetained)
            {
                ctrlFindLocalLicense1.Clear();
                btnRenewLicense.Enabled = false;
                MessageBox.Show($"License Is Detained ! You Cannot Renew A Detained License.", "Detained License", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblOldLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();

                decimal LicenseFees = ctrlFindLocalLicense1.License.LicenseClass.Fees;
                decimal TotalFees = LicenseFees + decimal.Parse(lblApplicationFees.Text);

                lblLicenseFees.Text = LicenseFees.ToString();
                lblTotalFees.Text = TotalFees.ToString();
                lblExpirationDate.Text = DateTime.Now.AddYears(ctrlFindLocalLicense1.License.LicenseClass.DefaultValidityLength).ToShortDateString();
                btnRenewLicense.Enabled = false;
                ctrlFindLocalLicense1.DisableFilter();
            }
        }
    }
}
