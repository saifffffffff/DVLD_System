using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Application;
using DVLD_WindowsForms.Screens;
using DVLD_WindowsForms.Screens.PeopleManagement;

namespace DVLD_WindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginScreen = new LoginScreen();

            Application.Run(loginScreen);


        }
    }
}
