using System;
using System.Drawing;
using DVLD_WindowsForms.Screens.Applications.RenewDrivingLicenseApplication;
using System.Windows.Forms;
using DVLD_WindowsForms.Screens.Applications.RenewDrivingLicenseApplication;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.PeopleManagement;
using DVLD_WindowsForms.Properties;
using DVLD_WindowsForms.Screens;
using DVLD_WindowsForms.Screens.Applications;
using DVLD_WindowsForms.Screens.ApplicationTypesManagement;
using DVLD_WindowsForms.Screens.Drivers;
using DVLD_WindowsForms.Screens.TestTypeManagement;
using DVLD_WindowsForms.Screens.UsersManagement;
using DVLD_WindowsForms.Screens.Applications.InternationalDrivingLicenseApplication;
using static DVLD_WindowsForms.Helpers.clsGlobal;
using DVLD_WindowsForms.Screens.Applications.ReplaceDrivingLicenseApplication;
using DVLD_WindowsForms.Screens.DetainedLicenses;
namespace DVLD_WindowsForms
{
    public partial class MainScreen : Form
    {

        LoginScreen _loginFrm;
        bool _isSignedOut = false;
        private void InitializeControls()
        {

            foreach (var Control in this.Controls)
            {
                if (Control is MdiClient Mdi)
                {
                    Mdi.BackColor = Color.FromArgb(40, 40, 40);
                    break;
                }
            }

            pbUserAccount.BackColor = Color.FromArgb(40 , 40 ,40 );
            flowLayoutPanel1.BackColor = Color.FromArgb(40, 40, 40);

        }
        public MainScreen(LoginScreen loginFrm)
        {

            InitializeComponent();
            InitializeControls();
            _loginFrm = loginFrm;
        }
        
        private void ShowScreen (Form Screen)
        {
            Screen.MdiParent = this;
            Screen.Parent = flowLayoutPanel1;
            Screen.BackColor = clsGlobal.Colors.MainScreenBackColor;
            
            // Optional: set child size relative to parent size
            Screen.Width = (int)(this.ClientSize.Width * 0.7);
            Screen.Height = (int)(this.ClientSize.Height * 0.75);

            Screen.Location = new Point(
                (this.ClientSize.Width - Screen.Width) / 3 - 4,
                (this.ClientSize.Height - Screen.Height) / 3
            );

            Screen.Show();

        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(new PeopleManagementScreen());
        }
        private void UserstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(new UsersManagementScreen());
        }

        
        // User Acount Settings
        public static Image MakeCircularImage(string imagePath)
        {
            Image originalImage;

            if (string.IsNullOrEmpty(imagePath))
                originalImage = SystemUser.Person.Gendor == clsPerson.enGendor.Male ? Resources.Male_512 : Resources.Female_512;
            else
                originalImage = Image.FromFile(imagePath);

            int size = Math.Min(originalImage.Width, originalImage.Height);
            Bitmap circularBitmap = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(circularBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new TextureBrush(originalImage))
                {
                    // Create circular clipping path
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddEllipse(0, 0, size, size);
                    g.FillPath(brush, path);
                }
            }

            return circularBitmap;
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pbUserAccount.Image = MakeCircularImage(SystemUser.Person.ImagePath);
        }

        private void pbUserAccount_Click(object sender, EventArgs e)
        {
            var dialog = new ShowLogInInfoScreen(_loginFrm);
            
            dialog.DataBack += (_IsSignedOut) =>
            {
                _isSignedOut = _IsSignedOut;
                
            };

            clsGlobal.ShowDialog(dialog);

            if(_isSignedOut)
            {
                _loginFrm.Show();
                this.Close();
            }

            else
            {
                // refresh user info
                clsGlobal.SystemUser = clsUser.GetById(clsGlobal.SystemUser.Id);
                
                pbUserAccount.Image = MakeCircularImage(clsGlobal.SystemUser.Person.ImagePath);
            }
            
        }

        private void pbUserAccount_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        
        private void pbUserAccount_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isSignedOut)
            {
                _loginFrm.Close();
                this.Close();
            }
        }

        private void manageApplicationTypes_ApplictionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(new ApplicationTypesManagementScreen());
        }

        private void localDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(new LocalDrivingLicenseApplicationsManagementScreen());
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowScreen(new DriversManagementScreen());
        }

        private void contextInternationalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            ShowScreen(new InternationalDrivingLicenseApplicationsManagement());
        }

        private void contextRenewDrivingLicense_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new RenewDrivingLicenseApplicationScreen());
        }

        private void contextReplace_Click(object sender, EventArgs e)
        {
            clsGlobal.ShowDialog(new ReplaceDrivingLicenseApplicationScreen());
        }

        private void contextManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            ShowScreen(new DetainedLicensesManagementScreen());
        }

        private void contextManageTestTypes_Click(object sender, EventArgs e)
        {
            ShowScreen(new TestTypesManagementScreen());
        }
    }
}
