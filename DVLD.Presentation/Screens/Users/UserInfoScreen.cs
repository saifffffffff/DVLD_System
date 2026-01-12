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
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.UsersManagement
{
    public partial class UserInfoScreen : DialogToInherit
    {

        int _userId;
        clsUser User;

        void InitializeControls()
        {
            User = clsUser.GetById(_userId);
            ctrlLoginInfo1.LoadUserInfo(User.Id);
            ctrlPersonInfo1.LoadPersonInfo(User.Person.Id);
            //ctrlPersonInfo1.ShowEditPersonInfoLink = false;
        }

        public UserInfoScreen(int UserId)
        {
            _userId = UserId;
            InitializeComponent();
            InitializeControls();
        }
    }
}
