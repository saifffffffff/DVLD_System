using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.ApplicationTypesManagement
{
    public partial class UpdateApplicatoinTypeScreen : DialogToInherit
    {

        clsApplicationType _applicationType;
        int _id = 0;

        public UpdateApplicatoinTypeScreen(int ApplicationTypeId)
        {
            InitializeComponent();
            _id = ApplicationTypeId;
        }

        private void _FillFromApplicationType()
        {

            lblID.Text = _id.ToString();
            tbTitle.Text = _applicationType.Title;
            tbFees.Text = _applicationType.Fees.ToString();


        }

        private void _FillToApplicatoinType()
        {
            _applicationType.Title = tbTitle.Text.Trim();
            _applicationType.Fees = Convert.ToDecimal(tbFees.Text.Trim());
        }

        private void UpdateApplicatoinTypeScreen_Load(object sender, EventArgs e)
        {
            _applicationType = clsApplicationType.GetById(_id);

            if (_applicationType == null) {
                MessageBox.Show($"Applicatoin Type With ID = {_id} Is Not Found");
                this.Close();
                return;
            }

            _FillFromApplicationType();

        }

        private void ValidateEmptyTextBoxes(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tb, "This Field is Required");
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (tbFees.Text.Length == 12 && e.KeyChar != '\b')
            {
                e.Handled = true;
                return; 
            }

            if (e.KeyChar == '.' && tbFees.Text.Length >= 1 && tbFees.Text.Count(c => c == '.') == 0)
                return;

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            _FillToApplicatoinType();

            if ( _applicationType.Save())
            {
                MessageBox.Show("Updated Successfully");
                this.Close();
                return;
            }
            else
                MessageBox.Show("Not Updated");


        }
    }
}
