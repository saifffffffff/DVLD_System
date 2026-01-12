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
using DVLD_WindowsForms.Properties;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlLicenseInfo : UserControlToInherite
    {

        public clsLicense License { get; private set; }

        public bool CloseIfNotFound { get; set; } = true;
       
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }

        void _Fill()
        {
            if (License == null) return;

            clsDriver Driver = clsDriver.GetById(License.DriverId);
            var ApplicantPerson = clsPerson.GetById(Driver.PersonId);

            lblFullName.Text = ApplicantPerson.FullName;
            lblNationalNo.Text = ApplicantPerson.NationalNo;
            lblGendor.Text = ApplicantPerson.Gendor.ToString();
            lblDateOfBirth.Text = ApplicantPerson.DateOfBirth.ToShortDateString();
            
            if (!string.IsNullOrEmpty(ApplicantPerson.ImagePath))
                pbPersonImage.ImageLocation = ApplicantPerson.ImagePath;
            else
                pbPersonImage.Image = ApplicantPerson.Gendor == clsPerson.enGendor.Male ? Resources.Male_512 : Resources.Female_512;
            
            lblClass.Text = clsLicenseClass.GetById(License.LicenseClassId)?.Name;
            lblLicenseID.Text = License.Id.ToString();
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
            lblIssueReason.Text = FormatIssueReason( License.IssueReason);
            lblNotes.Text = License.Notes.ToString();
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            lblDriverID.Text = License.DriverId.ToString();
            lblIsDetained.Text = License.IsDetained ? "Yes" : "No";


        }
        private string FormatIssueReason(clsLicense.enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case clsLicense.enIssueReason.FirstTime:
                    return "First Time";
                case clsLicense.enIssueReason.Renew:
                    return "Renew";
                case clsLicense.enIssueReason.ReplacementForDamaged:
                    return "Replacement For Damaged";
                case clsLicense.enIssueReason.ReplacementForLost:
                    return "Replacement For Lost";
            }
            return "[Unknown]";
        }
        public void LoadILicenseInfo(int  licenseID)
        {
            License = clsLicense.GetById(licenseID);

            if (  License == null )
            {
                
                Clear();
                License = null;
                
                MessageBox.Show($"License With ID {licenseID} Not Found !" , "Not Found" , MessageBoxButtons.OK , MessageBoxIcon.Information);

                
                if (CloseIfNotFound)
                    this.ParentForm.Close();
                
                return;
            }

            _Fill();

        }
        public void Clear()
        {
            lblClass.Text = "[???]";
            lblFullName.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGendor.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblNotes.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblIsDetained.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblIssueReason.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
            License = null;    
        }

        public void RefreshInfo()
        {
            if (License == null) return;
            License = clsLicense.GetById(License.Id);
            _Fill();

        }
    }
}
