using System;
using System.Linq;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;
using DVLD_WindowsForms.Screens.PeopleManagement;
using DVLD_WindowsForms.UserControls;

namespace DVLD_WindowsForms.Screens.UsersManagement
{
    public partial class AddUpdateUserScreen : DialogToInherit
    {
        // Initialize Controls
        enum enMode { Add , Update}
        enMode _Mode;
        
        int _UserId;
        clsUser _User;

        
        // Initializations
        private void _FillFromUser()
        {
            ctrlFindPerson1.LoadPersonInfo(_User.Person.Id);

            tbUsername.Text = _User.Username;

            tbPassword.Text = tbConfirmPassword.Text = _User.Password;

            lblUserId.Text = _User.Id.ToString();

            chkIsActive.Checked = _User.IsActive;
        }
        private void _FillToUser()
        {
            _User.Username = tbUsername.Text.Trim();
            _User.Password = tbPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if (_Mode == enMode.Add)
                _User.PersonId = ctrlFindPerson1.PersonCard.PersonID;


        }
       
        
        public AddUpdateUserScreen(int Id)
        {
            _UserId = Id;
            _Mode = enMode.Update;

            InitializeComponent();
        
        }
        public AddUpdateUserScreen()
        {
            _Mode = enMode.Add;
            InitializeComponent();
        }
        

        private void _SetDefaultValues()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    _User = new clsUser();
                    lblTitle.Text = "Add New User";
                    btnSave.Enabled = false;
                    tpLoginInfo.Enabled = false;
                    break;
                
                case enMode.Update:
                    lblTitle.Text = "Update User";
                    tpLoginInfo.Enabled = true;
                    ctrlFindPerson1.EnableFindingPerson = false;
                    break;
            }
        }

        private void AddUpdateUserScreen_Load(object sender, EventArgs e)
        {

            _SetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _User = clsUser.GetById(_UserId);

                if (_User == null)
                {

                    MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                _FillFromUser();
            }

            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (ctrlFindPerson1.PersonCard.PersonID == -1)
            {
                MessageBox.Show("Select a Person", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.Add && clsUser.IsUserExistForPersonId(ctrlFindPerson1.PersonCard.PersonID))
            {
                MessageBox.Show("This person already connected to another user", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPerson1.SearchTextboxFocus();
                return;
            }

            tpLoginInfo.Enabled = true;
            btnSave.Enabled = true;
            tcUserInfo.SelectedIndex = 1;


        }

        // saving info
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            _FillToUser();

            if (_User.Save())
            {
                if (_Mode == enMode.Add)
                {

                    _Mode = enMode.Update;
                    
                    lblUserId.Text = _User.Id.ToString();
                
                    lblTitle.Text = "Update User";
                
                    ctrlFindPerson1.EnableFindingPerson = false;

                }

                
                MessageBox.Show("Saved Successfully");
                
                return;
            }

            MessageBox.Show("Not Saved");


        }

        // validations

        private void tbUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if ( string.IsNullOrEmpty(tbUsername.Text.Trim()) ) {
                
                errorProvider1.SetError(tbUsername, "Required Field");
                e.Cancel = true;
                return;
            }

            
            if(_User.Username != tbUsername.Text.Trim() && clsUser.IsExist(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "Username already exist");
            }

            else
            {
                errorProvider1.SetError(tbUsername, "");
            }
        }
        
        private void tbPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Required Field");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(tbPassword, "");
            }

        }

        private void tbConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "Not the same as password");
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, "");
            }
        }

    }
}
