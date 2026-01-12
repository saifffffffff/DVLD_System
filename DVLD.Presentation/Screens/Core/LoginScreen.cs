using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using System.IO;
using static DVLD_WindowsForms.Helpers.clsGlobal;
using DVLD_WindowsForms.Screens.Core;
namespace DVLD_WindowsForms.Screens
{
    public partial class LoginScreen : DialogToInherit
    {



        public LoginScreen()
        {
            InitializeComponent();

        }

        

        // place holder handling
        private string _usernamePlaceHolder = "👤 username";
        private string _passwordPlaceHolder = "🔒 password";
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {                   
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }
        
        // 
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if(GetStoredCredentail(ref Username , ref Password))
            {
                tbUsername.Text = Username; 
                tbPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                SetPlaceholder(tbUsername, _usernamePlaceHolder);
                SetPlaceholder(tbPassword, _passwordPlaceHolder);
                chkRememberMe.Checked = false;
            }

        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            clsUser user = clsUser.GetByUsernameAndPassword(tbUsername.Text, tbPassword.Text);

            if (user != null) {

                if (chkRememberMe.Checked)
                    clsGlobal.RememberUsernameAndPassword(tbUsername.Text.Trim(), tbPassword.Text.Trim());
                    
                else
                    clsGlobal.RememberUsernameAndPassword("", "");


                if (!user.IsActive)
                {
                    tbUsername.Focus();
                    MessageBox.Show("Your Account Is Not Active , Contact Admin", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SystemUser = user;
                this.Hide();
                new MainScreen(this).ShowDialog();
                

            }
                
            // user / password not found
            else
            {
                tbUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }



            
            

        }

        private void LoginScreen_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
                LoginScreen_Load(this, null);
        }

    }
}
