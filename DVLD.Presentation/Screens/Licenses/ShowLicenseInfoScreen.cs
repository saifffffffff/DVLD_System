using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Licenses
{
    public partial class ShowLicenseInfoScreen : DialogToInherit
    {
        int _LicenseId;
        public ShowLicenseInfoScreen(int LicenseId)
        {
            InitializeComponent();
            _LicenseId = LicenseId;
        }

        private void ShowLicenseInfoScreen_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfo1.LoadILicenseInfo(_LicenseId);
        }
    }
}
