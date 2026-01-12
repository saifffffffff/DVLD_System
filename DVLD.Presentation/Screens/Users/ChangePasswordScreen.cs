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
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.UsersManagement
{
    public partial class ChangePasswordScreen : DialogToInherit
    {

        int _UserId;
        clsUser _user;

        void InitializeControls()
        {
            _user = clsUser.GetById(_UserId);

            if (_user == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserId,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ctrlShowLoginInfo1.LoadUserInfo(_user.Id);
            ctrlShowPersonInfo1.LoadPersonInfo(_user.PersonId);
            
        }

        public ChangePasswordScreen(int UserId)
        {
            this._UserId = UserId;
            InitializeComponent();
            InitializeControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.Password = tbNewPassword.Text.Trim();

            if (_user.Save())
            {
                MessageBox.Show("Password Saved Successfully");
                this.Close();
            }

            else
                MessageBox.Show("Password Not Changed");

        }

        // validating

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbPassword, "Required Field");
                e.Cancel = true;
            }

            else if (_user.Password != tbPassword.Text.Trim())
            {
                errorProvider1.SetError(tbPassword, "Password Is Incorrect");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(tbPassword, "");
                e.Cancel = false;
            }

        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbNewPassword, "Required Field");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbNewPassword, "");
                e.Cancel = false;
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbConfirmPassword, "");
                e.Cancel = false;
            }

            else if ( tbNewPassword.Text.Trim() != tbConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(tbConfirmPassword, "Does Not Match");
                e.Cancel = true;
            }
            
            else
            {
                errorProvider1.SetError(tbConfirmPassword, "");
                e.Cancel = false;
            }

        }
    
    
    
    
    }
}
