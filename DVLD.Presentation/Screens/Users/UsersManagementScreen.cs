
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;

namespace DVLD_WindowsForms.Screens.UsersManagement
{
    public partial class UsersManagementScreen : ScreenToInherit
    {

        DataView _view;

        void InitializeControls()
        {

            _view = clsUser.GetAll().DefaultView.ToTable(false, "UserId", "PersonId", "Username", "Fullname", "IsActive").DefaultView;

            dgv.DataSource = _view;

            if (dgv.Rows.Count > 0) {

                dgv.Columns[0].HeaderText = "User Id";
                dgv.Columns[1].HeaderText = "Person Id";
                dgv.Columns[2].HeaderText = "Username";
                dgv.Columns[3].HeaderText = "Full Name";
                dgv.Columns[4].HeaderText = "Is Active";
            }

            cbFilter.Text = "None";
            cbIsActive.Text = "All";

        }

        public UsersManagementScreen()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var dialog = new AddUpdateUserScreen();
            clsGlobal.ShowDialog(dialog);

            RefreshDataGridView();
        }

        void RefreshDataGridView()
        {
            _view = clsUser.GetAll().DefaultView.ToTable(false, "UserId", "PersonId", "Username", "Fullname", "IsActive").DefaultView;
            dgv.DataSource = _view;
        }

        // menus
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgv.SelectedCells[0].Value);
            var dialog = new UserInfoScreen(Id);
            clsGlobal.ShowDialog(dialog);

        }
        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dgv.SelectedCells[0].Value);
            var dialog = new AddUpdateUserScreen(Id);
            clsGlobal.ShowDialog(dialog);   
            RefreshDataGridView();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int Id = Convert.ToInt32(dgv.SelectedCells[0].Value);
            var dilaog = new ChangePasswordScreen(Id);
            clsGlobal.ShowDialog(dilaog);
        }

        // filter handling
        private bool _isNumber(string input)
        {
            return input.Length == input.Count(c => char.IsDigit(c));
        }
        private void _handleFilter()
        {
            string FilterColumn = cbFilter.Text.Trim(), Search = mtbSearch.Text.Trim();

            if (string.Equals(FilterColumn, "None"))
            {
                _view.RowFilter = "";
                mtbSearch.Visible = false;
                cbIsActive.Visible = false;
            }

            else if (FilterColumn.Contains("Active"))
            {

                mtbSearch.Visible = false;
                cbIsActive.Visible = true;

                if (cbIsActive.Text == "All")
                {
                    _view.RowFilter = "";
                    return;
                }

                string IsActiveBoolStr = "";

                if (cbIsActive.Text == "Yes")
                    IsActiveBoolStr = "true";

                else if (cbIsActive.Text == "No")
                    IsActiveBoolStr = "false";

                _view.RowFilter = $"IsActive = {IsActiveBoolStr}";

            }

            else if (FilterColumn.Equals("Person ID") || FilterColumn.Equals("User ID"))
            {
                
                mtbSearch.Visible = true;
                cbIsActive.Visible = false;

                if (!_isNumber(Search))
                    Search = mtbSearch.Text = string.Empty;

                if (string.IsNullOrEmpty(Search))
                    _view.RowFilter = "";

                else
                    _view.RowFilter = $"{FilterColumn.Replace(" ", "")} = {Search}";

            }

            else
            {
                mtbSearch.Visible = true;
                cbIsActive.Visible = false;

                if (string.IsNullOrEmpty(Search))
                    _view.RowFilter = "";
                else
                    _view.RowFilter = $" {FilterColumn.Replace(" ", "")} Like '{Search}%'";
            }
        }
        
        private void mtbSearch_TextChanged(object sender, EventArgs e)
        {
            _handleFilter();
        }
        
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _handleFilter();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _handleFilter();
        }
        private void mtbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilter.Text == "Person ID" || cbFilter.Text == "User ID")
                e.Handled =  !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


        }

    }
}
