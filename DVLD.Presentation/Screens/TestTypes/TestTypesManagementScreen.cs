using DVLD_Application.Entities;
using DVLD_WindowsForms.Helpers;

namespace DVLD_WindowsForms.Screens.TestTypeManagement
{
    public partial class TestTypesManagementScreen : ScreenToInherit
    {

        private void RefreshDataGridView()
        {
            dgvTestTypes.DataSource = clsTestType.GetAll().DefaultView;
        }

        public TestTypesManagementScreen()
        {
            InitializeComponent();
        }

        private void TestTypeManagementScreen_Load(object sender, System.EventArgs e)
        {
            dgvTestTypes.DataSource = clsTestType.GetAll().DefaultView;

            if ( dgvTestTypes.Columns.Count > 0 )
            {

                dgvTestTypes.Columns[0].HeaderText = "ID";
                dgvTestTypes.Columns[0].Width= 100;
                
                dgvTestTypes.Columns[1].HeaderText = "Title";
                dgvTestTypes.Columns[2].HeaderText = "Description";
                dgvTestTypes.Columns[3].HeaderText = "Fees";

            }



        }

        private void contextEdit_Click(object sender, System.EventArgs e)
        {
            int SelectedRowId = (int)dgvTestTypes.SelectedRows[0].Cells[0].Value;
            var dialog = new UpdateTestTypeScreen( SelectedRowId );
            clsGlobal.ShowDialog(dialog);

            RefreshDataGridView();
        }
    
    }
}
