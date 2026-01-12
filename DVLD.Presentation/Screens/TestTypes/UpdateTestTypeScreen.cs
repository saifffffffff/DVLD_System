using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.TestTypeManagement
{
    public partial class UpdateTestTypeScreen : DialogToInherit
    {

        int _TestTypeId = 0;
        clsTestType _TestType = null;

        public UpdateTestTypeScreen(int id)
        {
            InitializeComponent();
            _TestTypeId = id;
            this.BackColor = clsGlobal.Colors.DialogBackColor;
        }
        
        void _FillFromTestType()
        {
            lblID.Text = _TestTypeId.ToString();
            tbTitle.Text = _TestType.Title;
            tbDescription.Text = _TestType.Description;
            tbFees.Text = _TestType.Fees.ToString();
        }

        void _FillToTestType()
        {
            _TestType.Title = tbTitle.Text.Trim();
            _TestType.Description = tbDescription.Text.Trim();
            _TestType.Fees = Convert.ToDecimal(tbFees.Text.Trim());
        }
        
        private void UpdateTestTypeScreen_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.GetById(_TestTypeId);

            if (_TestType == null) {
                MessageBox.Show($"Test Type With ID = {_TestTypeId} Is Not Found");
                this.Close();
                return;
            }

            _FillFromTestType();

        }
        
        private void ValidateEmptyTextboxes(object sender, CancelEventArgs e)
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

            _FillToTestType();

            if (_TestType.Save())
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
