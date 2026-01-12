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
        clsPerson _Person;
        
        public ShowPersonLicenseHistoryScreen(int PersonId)
        {
            InitializeComponent();
            _PersonId = PersonId;
        }

        private void ShowPersonLicenseHistoryScreen_Load(object sender, EventArgs e)
        {
            
            _Person = clsPerson.GetById(_PersonId);

            if ( _Person == null)
            {
                MessageBox.Show($"Person With ID {_PersonId} Not Found");
                Close();
                return;
            }

            ctrlPersonInfo1.LoadPersonInfo(_PersonId);

            var Driver = clsDriver.GetByPersonId(_PersonId);
            
            if ( Driver != null )
                ctrlDriverLicenses1.LoadLicensesInfo(Driver.Id);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Updated succesf");
        }
    }
}
