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

namespace DVLD_WindowsForms.UserControls.InternationalLicenses
{
    public partial class ctrlInternationalLicenseInfo : UserControlToInherite
    {
        public clsInternationalLicense InternationalLicense { get; private set; }

        

        public bool CloseIfNotFound { get; set; } = false;

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public void Clear()
        {


            lblApplicationID.Text = "[???]";

            lblIsActive.Text = "[???]";
            lblFullName.Text = "[????]";
            lblInternationalLicenseID.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblGendor.Text = "[???]";
            lblIssueDate.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblLocalLicenseID.Text = "[???]";
            
            

        }
        private void _Fill()
        {
            
            if (InternationalLicense == null) return;

            lblApplicationID.Text = InternationalLicense.ApplicationId.ToString();

            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblFullName.Text = InternationalLicense.Application.ApplicantPerson.FullName;
            lblInternationalLicenseID.Text = InternationalLicense.Id.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();
            lblDriverID.Text = InternationalLicense.DriverId.ToString();
            lblDateOfBirth.Text = InternationalLicense.Application.ApplicantPerson.DateOfBirth.ToShortDateString();
            lblGendor.Text = InternationalLicense.Application.ApplicantPerson.Gendor == clsPerson.enGendor.Male ? "Male": "Female";
            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblNationalNo.Text = InternationalLicense.Application.ApplicantPerson.NationalNo;
            lblLocalLicenseID.Text = InternationalLicense.IssuedUsingLocalLicenseId.ToString();

            if (InternationalLicense.Application.ApplicantPerson.ImagePath != null)
                pbPersonImage.ImageLocation = InternationalLicense.Application.ApplicantPerson.ImagePath;
            else
                pbPersonImage.Image = Resources.Male_512;


        }
        public void LoadInternationalLicenseInfo(int InternetationalLicenseId)
        {

            InternationalLicense = clsInternationalLicense.GetById(InternetationalLicenseId);

            if (InternationalLicense == null)
            {

                Clear();
                MessageBox.Show($"International License With ID {lblInternationalLicenseID} Not Found !", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (CloseIfNotFound)
                    this.ParentForm.Close();

                return;

            }

            _Fill();

        }
    }
}
