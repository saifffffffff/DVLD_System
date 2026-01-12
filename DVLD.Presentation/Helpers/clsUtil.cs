using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Helpers
{
    public static class clsUtil
    {

        public static bool CreateImageDirectoryIfNotExists(string FolderPath)
        {

            if (Directory.Exists(FolderPath))
                return true;

            // Create dirctory
            try
            {
                Directory.CreateDirectory(FolderPath);
                return true;
            }
            catch (IOException iox)
            {
                MessageBox.Show("Error creating folder: " + iox.Message);
                return false;
            }

        }

        public static string GenerateGuid() => Guid.NewGuid().ToString();

        public static string ReplaceFileNameWithGuid(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            
            return GenerateGuid() + fileInfo.Extension;
        }

        public static bool CopyImagePathToProjectImageFolder(ref string SourcePath) {

            string DestinationFolder = @"C:\DVLD-People-Images\";

            if (!CreateImageDirectoryIfNotExists(DestinationFolder))
                return false;

            string DestinationPath = Path.Combine(DestinationFolder , ReplaceFileNameWithGuid(SourcePath));
            
            try
            {

                File.Copy(SourcePath, DestinationPath);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourcePath = DestinationPath;
            return true ;
        }



    }
}
