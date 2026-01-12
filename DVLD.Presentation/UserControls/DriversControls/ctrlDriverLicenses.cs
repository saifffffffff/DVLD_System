   using System.Data;
using System.Linq;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.InternationalLicenses;
using DVLD_WindowsForms.Screens.Licenses;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlDriverLicenses : UserControlToInherite
    {
        int _DriverId;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadLicensesInfo(int DriverId)
        {

            var driver = clsDriver.GetById(DriverId);

            if (driver == null)
            {
                MessageBox.Show($"Driver With ID {_DriverId} Not Found");
                this.ParentForm.Close();
                return;
            }

            var LocalDrivingLicenses = driver.GetAllLocalLicenses().Select( license => new { LicenseID = license.Id  , ApplicationID = license.ApplicationId , ClassName  = ((clsLicenseClass.enLicenseClass)license.LicenseClassId) .ToString() , IssueDate = license.IssueDate.ToShortDateString() , ExpirationDate = license.ExpirationDate.ToShortDateString() , IsActive = license.IsActive} ).ToList();
            var InternationalDrivingLicenses = driver.GetAllInternationalLicenses().Select(internationalLicense => new { InternationalLicenseID = internationalLicense.Id , ApplicationID = internationalLicense.ApplicationId , LocalLicenseID = internationalLicense.IssuedUsingLocalLicenseId , ExpirationDate= internationalLicense.ExpirationDate.ToShortDateString() , IsActive = internationalLicense.IsActive}).ToList();

            dgvLocalLicensesHistory.DataSource = LocalDrivingLicenses;
            dgvInternationalLicensesHistory.DataSource = InternationalDrivingLicenses;

        }

        private void contextShowLicenseInformation_Click(object sender, System.EventArgs e)
        {
            int SelectedLicenseID = (int)dgvLocalLicensesHistory.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowLicenseInfoScreen(SelectedLicenseID) , true);        
        }

        private void contextShowInternationalLicenseInfo_Click(object sender, System.EventArgs e)
        {
            int SelectedLicenseID = (int)dgvInternationalLicensesHistory.SelectedRows[0].Cells[0].Value;
            clsGlobal.ShowDialog(new ShowInternationalLicenseInfo(SelectedLicenseID), true);
        }
    }
}