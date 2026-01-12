using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;
using static DVLD_WindowsForms.Helpers.clsGlobal;
namespace DVLD_WindowsForms.Screens.UsersManagement
{
    public partial class ShowLogInInfoScreen : DialogToInherit
    {
        private bool _isSignedOut = false;
        private LoginScreen _loginFrm;
        

        public void FillFromUser()
        {
            ctrlShowLoginInfo1.LoadUserInfo(SystemUser.Id);
        }
        
        void InitializeControls()
        {
            ctrlShowPersonInfo1.LoadPersonInfo(clsGlobal.SystemUser.Person.Id);
            FillFromUser();
            //ctrlShowPersonInfo1.ShowEditPersonInfoLink = false;
        }

        public ShowLogInInfoScreen(LoginScreen loginFrm)
        {
            InitializeComponent();
            InitializeControls();
            _loginFrm = loginFrm;
        }

        public event Action<bool> DataBack;

        private void btnSignout_Click(object sender, EventArgs e)
        {
            _isSignedOut = true;
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            new ChangePasswordScreen(SystemUser.Id).ShowDialog();
        }

        private void ShowLogInInfoScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack(_isSignedOut);
        }
    }
}
