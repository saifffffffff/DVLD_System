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
        clsDriver _Driver;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        void _LoadLocalLicenseInfo()
        {
            var LocalDrivingLicenses = _Driver.GetAllLocalLicenses().Select(license => new { LicenseID = license.Id, ApplicationID = license.ApplicationId, ClassName = ((clsLicenseClass.enLicenseClass)license.LicenseClassId).ToString(), IssueDate = license.IssueDate.ToShortDateString(), ExpirationDate = license.ExpirationDate.ToShortDateString(), IsActive = license.IsActive }).ToList();
            dgvLocalLicensesHistory.DataSource = LocalDrivingLicenses;
        }
        void _LoadInternationalLicenseInfo()
        {
            var InternationalDrivingLicenses = _Driver.GetAllInternationalLicenses().Select(internationalLicense => new { InternationalLicenseID = internationalLicense.Id, ApplicationID = internationalLicense.ApplicationId, LocalLicenseID = internationalLicense.IssuedUsingLocalLicenseId, ExpirationDate = internationalLicense.ExpirationDate.ToShortDateString(), IsActive = internationalLicense.IsActive }).ToList();
            dgvInternationalLicensesHistory.DataSource = InternationalDrivingLicenses;
        }
        
        public void LoadLicenseInfoByPersonId (int PersonId)
        {
            _Driver = clsDriver.GetByPersonId(PersonId);

            if ( _Driver == null)
            {
                MessageBox.Show($"Driver With Person ID {PersonId} Not Found");
                this.ParentForm.Close();
                return;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }
        public void LoadLicensesInfoByDriverId (int DriverId)
        {

            _Driver = clsDriver.GetById(DriverId);

            if (_Driver == null)
            {
                MessageBox.Show($"Driver With ID {DriverId} Not Found");
                this.ParentForm.Close();
                return;
            }
            
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }
        public void Clear()
        {
            _Driver = null;
            dgvInternationalLicensesHistory.DataSource = null;
            dgvLocalLicensesHistory.DataSource = null;
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