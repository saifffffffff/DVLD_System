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
using DVLD_WindowsForms.Helpers;

namespace DVLD_WindowsForms.Screens.ApplicationTypesManagement
{
    public partial class ApplicationTypesManagementScreen : ScreenToInherit
    {

        

        public ApplicationTypesManagementScreen()
        {
            InitializeComponent();
        }

        private void _refreshDataGridView()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAll().DefaultView;
        }

        private void ApplicationTypesManagementScreen_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAll().DefaultView;

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "ID";
                dgvApplicationTypes.Columns[0].Width= 100;

                dgvApplicationTypes.Columns[1].HeaderText = "Title";
                dgvApplicationTypes.Columns[1].Width = 400;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";

            }
        }

        private void EditContext_Click(object sender, EventArgs e)
        {
            
            int SelectedRowID = (int)dgvApplicationTypes.SelectedRows[0].Cells[0].Value;

            var dialog = new UpdateApplicatoinTypeScreen(SelectedRowID);
            clsGlobal.ShowDialog(dialog);

            _refreshDataGridView();
        }
    }
}
