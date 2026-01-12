using System.Windows.Forms;
using DVLD_Application.Entities;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlBasicApplicationInfo : UserControlToInherite
    {

        clsApplication _App;
        
        public ctrlBasicApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillApplicationInfo()
        {
            lblApplicationID.Text = _App.Id.ToString();
            lblType.Text = _App.ApplicationType != null ? _App.ApplicationType.Title : "N/A";
            lblApplicantFullName.Text = _App.ApplicantPerson != null ? _App.ApplicantPerson.FullName : "N/A";
            lblStatus.Text = _App.Status.ToString();
            lblDate.Text = _App.Date.ToString("yyyy-MM-dd");
            lblStatusDate.Text = _App.LastStatusDate.ToString("yyyy-MM-dd");
            lblFees.Text = _App.PaidFees.ToString("F2");
            lblCreatedByUser.Text = _App.CreatedByUser.Username;
        }

        public void LoadInfo(int ApplicationId)
        {
            _App = clsApplication.GetById(ApplicationId);
            
            if ( _App == null)
            {
                MessageBox.Show("Application not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _FillApplicationInfo();
        }

    }
}
