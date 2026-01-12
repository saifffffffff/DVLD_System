using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Properties;
using DVLD_WindowsForms.Screens.PeopleManagement;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlPersonInfo : UserControlToInherite
    {
        
        private clsPerson _Person;
        
        public clsPerson Person { get => _Person; }

        public bool AllowEdit
        {
            set { lnkEditPersonInfo.Enabled = value; }
        }

        public int PersonID { get { return _Person == null ? -1 : _Person.Id; } }

        void InitializeControls()
        {
            lblPersonId.Text = "???";
            lblDateOfBirth.Text = "???";
            lblFullname.Text = "???";
            lblNationalNo.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblCountry.Text = "???";
            lblPhone.Text = "???";
            lblGendor.Text = "???";
            this.pbImage.Image = Resources.Male_512;
            lnkEditPersonInfo.Visible = false;
        }

        public ctrlPersonInfo()
        {
            InitializeComponent();
            InitializeControls();
        }


        private void lnkEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var dialog = new AddUpdatePersonScreen(_Person.Id);
            clsGlobal.ShowDialog(dialog);
            LoadPersonInfo(_Person.Id);
            dialog.Close();

        }

        private void _FillPersonInfo()
        {

            if (_Person == null)
                Reset();

            lblPersonId.Text = _Person.Id.ToString();
            lblFullname.Text = _Person.FullName;
            lblNationalNo.Text= _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblAddress.Text= _Person.Address;
            lblCountry.Text = _Person.Country.Name;
            lblPhone.Text= _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblGendor.Text = _Person.Gendor == clsPerson.enGendor.Male ? "Male" : "Female";
            
            

            pbImage.Image = _Person.Gendor == clsPerson.enGendor.Male ? Resources.Male_512 : Resources.Female_512;
            
            if (!string.IsNullOrEmpty(_Person.ImagePath ))
            {
                if (!File.Exists(_Person.ImagePath))
                    MessageBox.Show("Image file not found: " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    pbImage.ImageLocation = _Person.ImagePath;
            }

            lnkEditPersonInfo.Visible = true;
        }
        
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.GetByNationalNo(NationalNo);
            if (_Person== null)
            {
                Reset();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }
        
        public void LoadPersonInfo(int PersonId)
        {
            _Person = clsPerson.GetById(PersonId);

            if (_Person == null)
            {
                Reset() ;
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        
        public void Reset ()
        {
            InitializeControls();
        }
    
    }
}
