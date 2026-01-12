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

namespace DVLD_WindowsForms.Screens.Applications.LocalDrivingLicenseApplication
{
    public partial class ShowLocalDrivingLicenseApplicationInfo : DialogToInherit
    {
        int _LocalDrivingLicenseApplicationId;

        public ShowLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationId = LocalDrivingLicenseApplicationId;
        }

        private void ShowLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            bool IsExist = clsLocalDrivingLicenseApplication.IsExist(_LocalDrivingLicenseApplicationId);

            if ( !IsExist )
            {
                MessageBox.Show("No Local Driving License Application found with ID = " + _LocalDrivingLicenseApplicationId, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();

        }

        void _FillLocalDrivingLicenseApplicationInfo()
        {
            localDrivingLicenseApplicationInfo1.LoadInfo(_LocalDrivingLicenseApplicationId);
        }
    }
}
