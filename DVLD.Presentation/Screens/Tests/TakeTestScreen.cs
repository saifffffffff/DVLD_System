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

namespace DVLD_WindowsForms.Screens.Tests
{
    public partial class TakeTestScreen : DialogToInherit
    {

        private int _TestAppointmentId;
        private clsTestAppointment _TestAppointment;

        private clsTest _Test;

        public TakeTestScreen(int TestAppointmentId)
        {
            InitializeComponent();
            _TestAppointmentId = TestAppointmentId;
        }
        
        void _FillTestResultInfo()
        {
            if ( ctrlSheduledTest1.TestId != -1) 
            {
                _Test = clsTest.GetById(ctrlSheduledTest1.TestId);

                tbNotes.Text = _Test.Notes;

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

            }

        }
        
        private void TakeTestScreen_Load(object sender, EventArgs e)
        {
            _TestAppointment = clsTestAppointment.GetById(_TestAppointmentId);
            
            if (_TestAppointment == null )
            {
                MessageBox.Show($"Test Appointment With Id {_TestAppointmentId} Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            ctrlSheduledTest1.LoadTestInfo(_TestAppointmentId);

            if (_TestAppointment.IsLocked) {
            
                rbFail.Enabled = rbPass.Enabled = false;
                lblUserMessage.Visible = true;
                _FillTestResultInfo();
            }
            
            else
                _Test = new clsTest();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes
            ) 
            {
                if ( _Test.Id == -1) 
                {
                    _Test.CreatedByUserId = clsGlobal.SystemUser.Id;
                    _Test.TestResult = rbPass.Checked ? true : false;
                    _Test.TestAppointmentId = _TestAppointmentId;
                }

                _Test.Notes = tbNotes.Text.Trim();

                if (_Test.Save())
                {
                    MessageBox.Show("Test Result Saved Successfully."  , null, MessageBoxButtons.OK , MessageBoxIcon.Information);
                    Close();
                    return;
                }

                else
                    MessageBox.Show("Test Result Did Not Saved Successfully." , null, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



    }
}
