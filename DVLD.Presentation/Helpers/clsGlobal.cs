using System;
using System.Drawing;
using DVLD_Application.Entities;
using System.IO;
using System.Windows.Forms;
namespace DVLD_WindowsForms.Helpers
{
    internal static class clsGlobal
    {
        public static clsUser SystemUser;

        public static class Colors
        {
            public static Color MainScreenBackColor = Color.FromArgb(20, 20, 20);
            public static Color DialogBackColor = Color.FromArgb(30, 30, 30);
            public static Color SubDialogBackColor = Color.FromArgb(40, 40, 40);
        }
        
        public static void ShowDialog(Form Dialog, bool isSubDialog = false)
        {
            Dialog.BackColor = !isSubDialog ? Colors.DialogBackColor : Colors.SubDialogBackColor;
            Dialog.StartPosition = FormStartPosition.CenterScreen;
            Dialog.ShowDialog();

        }

        // if username passed ,create new filepath , else delete the file
        public static void RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {

                string CurrentDirectoryPath= Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectoryPath + "\\data.txt";

                if ( string.IsNullOrEmpty(Username) )
                {
                    if( File.Exists(FilePath))
                        File.Delete(FilePath);
                    return;
                }    

                using (var Writer = new StreamWriter(FilePath))
                    Writer.Write(Username + "#//#" + Password);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occured : {ex.Message}");
            }

        }
    
        // if the file is deleted return false else if exists return true
        public static bool GetStoredCredentail(ref string Username , ref string Password)
        {
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string FilePath = CurrentDirectory + "\\data.txt";

            if (!File.Exists(FilePath))
                return false;

            try
            {
                using (var Reader = new StreamReader(FilePath))
                {
                    string Line = Reader.ReadLine();
                    string [] Credentail = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    Username = Credentail[0];
                    Password = Credentail[1];
                
                }
                return true;
            }

            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    
    }

}