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
using DVLD_WindowsForms.Screens.Licenses;
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
            lnkShowLicenseHistory.Visible = true;





        }

        private void _ShowMessageBoxError(string message)
        {
            ctrlFindLocalLicense1.Clear();
            btnRenewLicense.Enabled = false;
            lnkShowLicenseHistory.Visible = false;
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void ctrlFindLocalLicense1_OnSelected()
        {
            if (!ctrlFindLocalLicense1.License.IsActive)
                _ShowMessageBoxError("License Is Not Active !");
            

            else if (!ctrlFindLocalLicense1.License.IsExpired)
                _ShowMessageBoxError("License Is Not Expired Yet !");
            
            else if (ctrlFindLocalLicense1.License.IsDetained)
                _ShowMessageBoxError("License Is Detained !");
                
            
            else
            {
                lblOldLicenseID.Text = ctrlFindLocalLicense1.License.Id.ToString();

                decimal LicenseFees = ctrlFindLocalLicense1.License.LicenseClass.Fees;
                decimal TotalFees = LicenseFees + decimal.Parse(lblApplicationFees.Text);

                lblLicenseFees.Text = LicenseFees.ToString();
                lblTotalFees.Text = TotalFees.ToString();
                lblExpirationDate.Text = DateTime.Now.AddYears(ctrlFindLocalLicense1.License.LicenseClass.DefaultValidityLength).ToShortDateString();
                btnRenewLicense.Enabled = false;
                lnkShowLicenseHistory.Visible = true;
                ctrlFindLocalLicense1.DisableFilter();
            }
        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsGlobal.ShowDialog(new ShowPersonLicenseHistoryScreen(ctrlFindLocalLicense1.License.Application.ApplicantPersonId));
        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsGlobal.ShowDialog(new ShowLicenseInfoScreen(ctrlFindLocalLicense1.License.Id));
        }
    }
}
