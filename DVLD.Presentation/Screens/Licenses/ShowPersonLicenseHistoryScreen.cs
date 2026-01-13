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

namespace DVLD_WindowsForms.Screens.Licenses
{
    public partial class ShowPersonLicenseHistoryScreen : DialogToInherit
    {
        int _PersonId = -1;
        
        public ShowPersonLicenseHistoryScreen(int PersonId)
        {
            InitializeComponent();
            _PersonId = PersonId;
        }
        public ShowPersonLicenseHistoryScreen()
        {
            InitializeComponent();
        }

        private void ShowPersonLicenseHistoryScreen_Load(object sender, EventArgs e)
        {
            
            if (_PersonId != -1)
            {
                ctrlFindPerson1.LoadPersonInfo(_PersonId);
                ctrlFindPerson1.EnableFindingPerson = false;
                ctrlDriverLicenses1.LoadLicenseInfoByPersonId(_PersonId);
            }
            else
            {
                ctrlFindPerson1.EnableFindingPerson = true;
            }

           
        }

        private void ctrlFindPerson1_OnPersonFound(int FoundPersonId)
        {
            _PersonId = FoundPersonId;
            
            if (_PersonId == -1)
                ctrlDriverLicenses1.Clear();
            
            else
                ctrlDriverLicenses1.LoadLicenseInfoByPersonId(_PersonId);
        }

  
    }
}
