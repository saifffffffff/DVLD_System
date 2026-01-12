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

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlLoginInfo : UserControlToInherite
    {

        clsUser _User;
        
        public ctrlLoginInfo()
        {
            InitializeComponent();
        }
        
        public void LoadUserInfo(int UserId)
        {
            _User = clsUser.GetById(UserId);

            if (_User == null) {
                MessageBox.Show("No User with UserID = " + UserId.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            lblUsername.Text = _User.Username;
            lblUserId.Text = _User.Id.ToString();
            lblIsActive.Text = _User.IsActive ? "Active" : "Not Active";
            
        }
       

    }
}
