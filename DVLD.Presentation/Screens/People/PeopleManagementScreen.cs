using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DVLD_Application;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;
using DVLD_WindowsForms.Screens.PeopleManagement;

namespace DVLD_WindowsForms.PeopleManagement
{
    public partial class PeopleManagementScreen : ScreenToInherit
    {


        private DataTable _dtPeople;

        private void _RefreshDataGridView() { 
            InitializeControls();
            tbSearch.Text = "";
        }
        private void InitializeControls()
        {
            _dtPeople = clsPerson.GetAll().DefaultView.ToTable(false, "PersonID", "NationalNo",
                                    "FirstName", "SecondName", "ThirdName", "LastName",
                                    "GendorCaption", "DateOfBirth", "CountryName",
                                    "Phone", "Email");

            cbFilter.SelectedIndex = 0;
            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {
                
                dgvPeople.Columns[0].HeaderText = "PersonID";
                
                dgvPeople.Columns[1].HeaderText = "National No";

                dgvPeople.Columns[2].HeaderText = "FirstName";

                dgvPeople.Columns[3].HeaderText = "SecondName";

                dgvPeople.Columns[4].HeaderText = "ThirdName";

                dgvPeople.Columns[5].HeaderText = "LastName";

                dgvPeople.Columns[6].HeaderText = "Gendor";

                dgvPeople.Columns[7].HeaderText = "DateOfBirth";

                dgvPeople.Columns[8].HeaderText = "Country";

                dgvPeople.Columns[9].HeaderText = "Phone";

                dgvPeople.Columns[10].HeaderText = "Email";
            }


        }
        public PeopleManagementScreen()
        {
            InitializeComponent();
            InitializeControls(); 
        }
        
        private bool _isNumber(string input ) => input.Length == input.Count(c => char.IsDigit(c));
        private void _handleFilter()
        {
            string FilterColumn = cbFilter.Text.Replace(" ", "") , Search = tbSearch.Text.Trim();

            if (string.IsNullOrEmpty(tbSearch.Text.Trim()) || FilterColumn == "None")
            {
                tbSearch.Visible = FilterColumn == "None" ? false : true;
                _dtPeople.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "PersonID")
            {
                if (!_isNumber(Search))
                    Search = tbSearch.Text = string.Empty;

                if (string.IsNullOrEmpty(Search))
                    _dtPeople.DefaultView.RowFilter = "";
                else
                    _dtPeople.DefaultView.RowFilter = $"PersonID = {Search}";
                
                return;
            }

            _dtPeople.DefaultView.RowFilter = $"{FilterColumn} Like '{Search}%' ";

        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _handleFilter();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _handleFilter();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            var dialog = new AddUpdatePersonScreen();
            
            clsGlobal.ShowDialog(dialog);

            
            _RefreshDataGridView();
        }
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        // Context Menus
        private void contextDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete this record ? " , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question))
            {
                
                int Id = Convert.ToInt32(dgvPeople.SelectedCells[0].Value);
                
                if (clsPerson.Delete(Id))
                {
                    MessageBox.Show("Deleted Successfully");
                    _RefreshDataGridView();
                }

                else
                    MessageBox.Show("There is data linked to this person !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void contextEdit_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((dgvPeople.SelectedCells[0].Value));
            
            var dialog = new AddUpdatePersonScreen(Id);
            
            clsGlobal.ShowDialog(dialog);

            
            _RefreshDataGridView();
        }
        private void contextShowDetails_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgvPeople.SelectedCells[0].Value);
            var dialog = new ShowPersonInfoScreen(Id);
            clsGlobal.ShowDialog(dialog);
        }

    }
}
