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

namespace DVLD_WindowsForms.Screens.InternationalLicenses
{
    public partial class ShowInternationalLicenseInfo : DialogToInherit
    {
        private int _InternationaLicenseId;

        public ShowInternationalLicenseInfo(int internationaLicenseId)
        {
            InitializeComponent();
            _InternationaLicenseId = internationaLicenseId;
        }

        private void ShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.CloseIfNotFound = true;
            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_InternationaLicenseId);
        }
    }
}
