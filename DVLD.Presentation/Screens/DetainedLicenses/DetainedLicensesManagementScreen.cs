using System;
using System.Data;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Applications.DetainLicenseApplication;
using DVLD_WindowsForms.Screens.Applications.ReleaseLicenseApplication;
using DVLD_WindowsForms.Screens.PeopleManagement;

namespace DVLD_WindowsForms.Screens.DetainedLicenses
{
    public partial class DetainedLicensesManagementScreen : ScreenToInherit
    {
        DataTable _dt ;

        public DetainedLicensesManagementScreen()
        {
            InitializeComponent();
        }

        private void DetainedLicensesManagement_Load(object sender, EventArgs e)
        {
            _dt = clsDetainedLicense.GetAll();
            dgvDetainedLicenses.DataSource = _dt.DefaultView;

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 150;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 200;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new DetainLicenseScreen());
            DetainedLicensesManagement_Load(null, null);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new ReleaseLicenseApplicationScreen());
            DetainedLicensesManagement_Load(null, null);

        }

        private void contextPesonDetails_Click(object sender, EventArgs e)
        {
            int LicenseId = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonId = clsLicense.GetById(LicenseId).Driver.PersonId;
            clsGlobal.ShowDialog(new ShowPersonInfoScreen(PersonId));
        }

        private void contextShowDetails_Click(object sender, EventArgs e)
        {
            int LicenseId = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            clsGlobal.ShowDialog(new Licenses.ShowLicenseInfoScreen(LicenseId));
        }

        private void contextShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int LicenseId = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonId = clsLicense.GetById(LicenseId).Driver.PersonId;
            clsGlobal.ShowDialog(new Licenses.ShowPersonLicenseHistoryScreen(PersonId));
        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextReleaseDetainedLicense.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void contextReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int LicenseId = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            clsGlobal.ShowDialog(new ReleaseLicenseApplicationScreen(LicenseId));
            DetainedLicensesManagement_Load(null, null);
        }
    }
}
