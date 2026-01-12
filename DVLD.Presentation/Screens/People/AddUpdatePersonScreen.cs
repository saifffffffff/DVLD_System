using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Properties;
using DVLD_WindowsForms.Screens.Core;
using DVLD_WindowsForms.UserControls;

namespace DVLD_WindowsForms.Screens.PeopleManagement
{
    public partial class AddUpdatePersonScreen : DialogToInherit
    {

        public enum enMode { Add ,Update};
        enMode _Mode;

        int _PersonId = -1;
        clsPerson _Person;

        // Events
        public delegate void DataBackEventHandler(int PersonId);
        public DataBackEventHandler DataBack;



        //CONSTRUCTORS

        public AddUpdatePersonScreen()
        {
            _Mode = enMode.Add;
            InitializeComponent();
        }

        public AddUpdatePersonScreen(int Id)
        {

            _Mode = enMode.Update ;
            this._PersonId = Id;
            InitializeComponent();

        }


        // Initialization Methods
        private void FillCountriesComboBox()
        {
            foreach (DataRow Row in clsCountry.GetAll().Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }
        }
        private void SetDefaultValues()
        {
            FillCountriesComboBox();

            if(_Mode == enMode.Update)
                lblTitle.Text = "Update Person";
            
            else
            {
                _Person = new clsPerson();
                lblTitle.Text = "Add Person";
            }

            tbAddress.Text = "";
            tbEmail.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            tbPhone.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbAddress.Text= "";
            
            rbMale.Checked = true;
            pbImage.Image = Resources.Male_512; 

            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");
            
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate  = DateTime.Now.AddYears(-100);




        }
        private void AddUpdatePersonScreen_Load(object sender, EventArgs e)
        
        {
            SetDefaultValues();

            if(_Mode == enMode.Update)
            {
                _Person = clsPerson.GetById(_PersonId);

                if(_Person == null)
                {
                    MessageBox.Show("No Person with ID = " + _PersonId, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                _FillFromPerson();
            }
            
           

        }
        private void _FillFromPerson()
        {
            if (_Person == null)
                return;
            
            lblPersonId.Text = _Person.Id.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text= _Person.SecondName;
            tbThirdName.Text= _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbEmail.Text= _Person.Email;
            tbAddress.Text= _Person.Address;
            cbCountries.SelectedIndex= cbCountries.FindString(_Person.Country.Name);
            tbNationalNo.Text= _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            
            if (_Person.Gendor == clsPerson.enGendor.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            tbPhone.Text = _Person.Phone;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                pbImage.ImageLocation = _Person.ImagePath;
                lnkRemoveImage.Visible = true;
            }

            pbImage.Visible = _Person.ImagePath != "";


        }
        private void _FillToPerson ()
        {

           
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();
            _Person.Address = tbAddress.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryId = clsCountry.GetCountryId(cbCountries.Text);
            _Person.Gendor = rbMale.Checked ? clsPerson.enGendor.Male : clsPerson.enGendor.Female;
            
            
            // if image changed 
            if (pbImage.ImageLocation != null)
            {
                if(_Person.ImagePath != pbImage.ImageLocation)
                {
                    //File.Delete(Person.ImagePath);
                    _Person.ImagePath = pbImage.ImageLocation;//$@"C:\Users\tareq\OneDrive\Pictures\Screenshots\Desktop\DVLD_WindowsForms\UserImages\User-{Guid.NewGuid().ToString()}";
                }
            }
            // if image removed
            else
                _Person.ImagePath = "";
            


        }

        // validations
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "This Field is Required");
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }

        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidate.IsValidEmail(((TextBox)sender)))
            {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "Invalid Email Syntax");
            }
            else
                errorProvider1.SetError((TextBox)sender, "");
        }
        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                errorProvider1.SetError(tbNationalNo, "This Field is Required");
                e.Cancel = true;

                return;
            }

            else if (tbNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsNationalNumberExist(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "National Number already exist");
                e.Cancel = true;
                return;
            }

            errorProvider1.SetError(tbNationalNo, "");
        }

        // image handling
        private bool HandlePersonImage()
        {

            // Image not changed / image removed
            if (_Person.ImagePath == pbImage.ImageLocation || pbImage.ImageLocation == null )
                return true;


            // Image changed

            // delete the old Person Image if exists
            if (!string.IsNullOrEmpty(_Person.ImagePath))
            {
                try
                {
                    File.Delete(_Person.ImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete old image file. " + ex.Message, "File Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // save the image in the project's images directory 
            string ImagePath = pbImage.ImageLocation;
            
            if (clsUtil.CopyImagePathToProjectImageFolder(ref ImagePath))
            {
                pbImage.ImageLocation = ImagePath;
                return true;
            }

            return false;


        }
        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog1.Title = "Select Image";

            if ( openFileDialog1.ShowDialog()  == DialogResult.OK)
            {
                pbImage.Load(openFileDialog1.FileName);
                lnkRemoveImage.Visible = true;

            } 
        }
        private void lnkRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            pbImage.Image = rbFemale.Checked ? Resources.Female_512 : Resources.Male_512;
            lnkRemoveImage.Visible = false;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null )
                pbImage.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;
            
        }

        // buttons events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!HandlePersonImage())
                return;

            _FillToPerson();

            if (_Person.Save())
            {
                MessageBox.Show("Saved Successfully");

                if (_Mode == enMode.Add)
                {
                    lblPersonId.Text = _Person.Id.ToString();
                    _PersonId = _Person.Id;
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Person";
                }
                else
                    Close();

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUpdatePersonScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(_PersonId);
        }
    }

}
