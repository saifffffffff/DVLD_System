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
using DVLD_WindowsForms.Screens.Core;

namespace DVLD_WindowsForms.Screens.Applications
{
    public partial class AddUpdateLocalDrivingLicenseApplicationScreen : DialogToInherit
    {
        enum enMode { Add, Update }
        enMode _Mode;
        
        private clsLicenseClass _selectedLicenseClass;
        
        private int _LocalDrivingLicenseApplicationId = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public AddUpdateLocalDrivingLicenseApplicationScreen()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public AddUpdateLocalDrivingLicenseApplicationScreen(int LocalDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationId = LocalDrivingLicenseApplicationId;
            _Mode = enMode.Update;
        }

        private void _SetDefaultValues()
        {
            _FillLicenseClassesInComoboBox();
            
            if (_Mode == enMode.Add)
            {
                lblTitle.Text = "Add Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.SystemUser.Username;
                
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
                
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;

            }

        }

        private void _FillFromLocalDrivingLicenseApplication()
        {
            lblApplicationID.Text = _LocalDrivingLicenseApplication.Id.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.Date.ToShortDateString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUser.Username;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicenseApplication.LicenseClass.Name);
            lblClassFees.Text = _LocalDrivingLicenseApplication.LicenseClass.Fees.ToString("F2");
            ctrlFindPerson1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonId);
        }

        private void _FillToLocalDrivingLicenseApplication()
        {
            if (_Mode == enMode.Add)
            {
                _LocalDrivingLicenseApplication.ApplicantPersonId = ctrlFindPerson1.PersonCard.PersonID;
                _LocalDrivingLicenseApplication.Date = DateTime.Now;
                _LocalDrivingLicenseApplication.LastStatusDate =DateTime.Now;
                _LocalDrivingLicenseApplication.CreatedByUserId = clsGlobal.SystemUser.Id;
                _LocalDrivingLicenseApplication.PaidFees = 15m;
                _LocalDrivingLicenseApplication.ApplicationTypeId = 1; // Local Driving License Application Type
                _LocalDrivingLicenseApplication.Status = clsApplication.enApplicationStatus.New;
            }

            _LocalDrivingLicenseApplication.LicenseClassID = _selectedLicenseClass.Id;
            
        }

        private void _FillLicenseClassesInComoboBox()
        {
            var Classes = clsLicenseClass.GetAll();
            
            foreach (DataRow Class in Classes.Rows){
                cbLicenseClass.Items.Add(Class["ClassName"]);
            }
        
            cbLicenseClass.SelectedIndex = 2;
        
        }
        private void AddUpdateLocalDrivingLicenseApplicationScreen_Load(object sender, EventArgs e)
        {

            _SetDefaultValues();

            if ( _Mode == enMode.Update )
            {
                ctrlFindPerson1.EnableFindingPerson = false;

                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetById(_LocalDrivingLicenseApplicationId);

                if ( _LocalDrivingLicenseApplication == null)
                {
                    MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationId, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    return;
                }

                _FillFromLocalDrivingLicenseApplication();
                
                
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ( _Mode == enMode.Add && ctrlFindPerson1.PersonCard.PersonID == -1 )
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPerson1.SearchTextboxFocus();
                return;
            }
            
            tpApplicationInfo.Enabled = true;
            btnSave.Enabled = true;
            tcLicenseInfo.SelectedIndex = 1;

        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {   
            _selectedLicenseClass = clsLicenseClass.GetClassByName( cbLicenseClass.SelectedItem.ToString() );
            lblClassFees.Text = _selectedLicenseClass.Fees.ToString("F2"); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            
            if ( clsApplication.DoesPersonHaveActiveApplication(ctrlFindPerson1.PersonCard.PersonID, _selectedLicenseClass.Id) )
            {
                MessageBox.Show("Choose another license class , the selected person already have an ative application for the selected class");
                return;
            }

            if ( clsLicense.DoesLicenseExistByPersonId( ctrlFindPerson1.PersonCard.PersonID, _selectedLicenseClass.Id))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillToLocalDrivingLicenseApplication();

            if (_LocalDrivingLicenseApplication.Save())
            {
                if (_Mode == enMode.Add)
                {
                    _Mode = enMode.Update;
                    lblTitle.Text = "Update Local Driving License Application";
                    lblApplicationID.Text = _LocalDrivingLicenseApplication.Id.ToString();
                }
                MessageBox.Show("Data Saved Successfully");
                
            }
            else
                MessageBox.Show("Not Saved");
            

        }
    
    }


}
