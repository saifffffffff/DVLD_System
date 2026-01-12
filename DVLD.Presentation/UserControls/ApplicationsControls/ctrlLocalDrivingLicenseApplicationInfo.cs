
using System.Windows.Forms;
using DVLD_Application.Entities;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlLocalDrivingLicenseApplicationInfo : UserControlToInherite
    {
        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;

        public ctrlLocalDrivingLicenseApplicationInfo()
        {
            this.BorderStyle = BorderStyle.None;
            InitializeComponent();
        }

        public void LoadInfo(int LocalDrivingLicenseApplicationId)
        {
            _localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(LocalDrivingLicenseApplicationId);

            if ( _localDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Local Driving License Application found with ID = " + LocalDrivingLicenseApplicationId, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _FillApplicationInfo();

        }

        void _FillApplicationInfo()
        {
            lblApplicationID.Text = _localDrivingLicenseApplication.Id.ToString();
            lblLicenseClass.Text = _localDrivingLicenseApplication.LicenseClass.Name;
            lblPassedTests.Text = _localDrivingLicenseApplication.PassedTestsCount + " / 3";

            basicApplicationInfo1.LoadInfo(_localDrivingLicenseApplication.ApplicationId);
        }

        public void RefreshApplicationInfo()
        {
            lblPassedTests.Text = _localDrivingLicenseApplication.PassedTestsCount + " / 3";
        }
    }
}
