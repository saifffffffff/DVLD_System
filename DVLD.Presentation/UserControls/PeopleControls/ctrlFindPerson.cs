using System;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.PeopleManagement;
using DVLD_WindowsForms.Screens.UsersManagement;

namespace DVLD_WindowsForms.UserControls
{
    public partial class ctrlFindPerson : UserControlToInherite
    {
        // Prevent Adding or searching for a person
        public bool EnableFindingPerson
        {
            set
            {
                if (value)
                {
                    tbSearch.Enabled = true;
                    cbFilter.Enabled = true;
                    btnAddPerson.Enabled = true;
                    btnSearchPerson.Enabled = true;
                }
                else
                {
                    tbSearch.Enabled = false;
                    cbFilter.Enabled = false;
                    btnAddPerson.Enabled = false;
                    btnSearchPerson.Enabled = false;
                }
            }
        }

        public ctrlPersonInfo PersonCard
        {
            get { return ctrlPersonInfo1; }
        }
        


        private int _PersonId = -1;

        public ctrlFindPerson()
        {
            InitializeComponent();
            cbFilter.SelectedIndex = 0;
        }


        // Events

        public event Action<int> OnPersonFound;

        // Adding Person
        public void LoadPersonInfo(int PersonId)
        {
            ctrlPersonInfo1.LoadPersonInfo(PersonId);
            cbFilter.SelectedIndex = 1;
            tbSearch.Text = PersonId.ToString();
        }
  
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var frm = new AddUpdatePersonScreen();

            frm.DataBack += (PersonId) =>
            {
                if ( PersonId != -1)
                {
                    this._PersonId = PersonId;
                    PersonCard.LoadPersonInfo(_PersonId);
                    errorProvider1.SetError(tbSearch, "");
                    cbFilter.SelectedIndex = 1;
                    tbSearch.Text = PersonId.ToString();
                    EnableFindingPerson = false;
                }
            };

            frm.ShowDialog();
    

        }
       
        // Searching For a person
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
                return;
            

            switch (cbFilter.SelectedIndex)
            {
                // person id
                case 1:
                    ctrlPersonInfo1.LoadPersonInfo(int.Parse(tbSearch.Text));
                    break;
                
                // national no
                case 2:
                    ctrlPersonInfo1.LoadPersonInfo(tbSearch.Text);
                    break;
                
            
            }

            OnPersonFound?.Invoke(ctrlPersonInfo1.PersonID);
            

        }


        
        
        

        public void SearchTextboxFocus() { tbSearch.Focus(); }
        

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            tbSearch.Focus();
        }
       
        private void tbSearch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                errorProvider1.SetError(tbSearch, "Search text is required");
                e.Cancel = true;
            }

            else
            {
                errorProvider1.SetError(tbSearch, "");
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == (char)13)
                btnSearchPerson.PerformClick();
                
            

            else if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
