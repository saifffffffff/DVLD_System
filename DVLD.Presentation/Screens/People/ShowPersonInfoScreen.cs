using System.Drawing;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.PeopleManagement
{
    public partial class ShowPersonInfoScreen : DialogToInherit
    {
        int _PersonId;

        void InitializeControls()
        {
            ctrlShowPersonInfo1.LoadPersonInfo(_PersonId);

        }

        public ShowPersonInfoScreen(int Id)
        {
            _PersonId = Id;

            InitializeComponent();

            InitializeControls();

        }

    }
}
