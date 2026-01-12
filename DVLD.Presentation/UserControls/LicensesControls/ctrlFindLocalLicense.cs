using System;
using System.Windows.Forms;
using DVLD_Application.Entities;


namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlFindLocalLicense : UserControlToInherite
    {

        
        public event Action OnSelected;
        
        public event Action OnNotFound;

        public clsLicense License { get => ctrlLicenseInfo1.License; }


        public ctrlFindLocalLicense()
        {
            InitializeComponent();
            ctrlLicenseInfo1.CloseIfNotFound = false;
        }

        public void Clear() => ctrlLicenseInfo1.Clear();
        public void DisableFilter()
        {
            gpFilter.Enabled = false;
        }
        public void EnableFilter()
        {
            gpFilter.Enabled = true;
        }
        public void RefreshInfo() => ctrlLicenseInfo1.RefreshInfo();
        public void LoadLicenseInfo(int LicenseId)
        {
            ctrlLicenseInfo1.LoadILicenseInfo(LicenseId);
            if ( License != null)
            {
                tbSearch.Text = LicenseId.ToString();   
                DisableFilter();
                OnSelected?.Invoke();
            }
            else
            {
                OnNotFound?.Invoke();
            }
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (Int32.TryParse(tbSearch.Text, out int ID))
            {

                ctrlLicenseInfo1.LoadILicenseInfo(ID);
            
                if (ctrlLicenseInfo1.License != null)
                    OnSelected?.Invoke();
                else
                    OnNotFound?.Invoke();
            }
        }
        
        private void mtbSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) => e.Handled = !(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')? e.Handled = true : e.Handled = false;

        private void tbSearch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                errorProvider1.SetError(tbSearch, "Fill This Fields");
            }
            else 
                errorProvider1.SetError(tbSearch, "");
        }
        
    }
}
