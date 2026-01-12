using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD_WindowsForms.Helpers
{
    internal static class clsValidate
    {

        public static bool IsValidRequiredField(TextBox tb) => !string.IsNullOrWhiteSpace(tb.Text);

        private static bool _ValidateEmailSyntax(string Email) => Regex.IsMatch(Email, "[a-zA-Z0-9_.+-]{1,}@gmail\\.[a-zA-Z0-9_.+-]{1,}");

        public static bool IsValidEmail (TextBox tbEmail )
        {
            bool IsValid;
            
            if (string.IsNullOrWhiteSpace(tbEmail.Text.Trim()))
                IsValid = true;
            

            else
            {

                if ( _ValidateEmailSyntax(tbEmail.Text.Trim()) )
                    IsValid = true;
                
                else
                    IsValid = false;
                
            }

            return IsValid;
        }
    
        
    }
}
