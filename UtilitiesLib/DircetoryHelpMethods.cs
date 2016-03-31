using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace UtilitiesLib
{
    public static class DircetoryHelpMethods
    {
        /// <summary>
        /// Copy file from Source folder to distination folder
        /// Ex: Source folder is Temp folder, Destination foder is Album folder
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        public static void copyFileFromSourceToDestination(string sourcePath, string destinationPath)
        {
            FileInfo sFileItem, dFileItem;
            DirectoryInfo sDir = new DirectoryInfo(sourcePath);
            DirectoryInfo dDir = new DirectoryInfo(destinationPath);
            foreach (var item in sDir.GetFiles())
            {
                try
                {
                    sFileItem = new FileInfo(sDir + "\\" + item);
                    dFileItem = new FileInfo(dDir + "\\" + item);
                    sFileItem.CopyTo(dFileItem.ToString(), true);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Create Temp folder to hold all album file,
        /// </summary>
        /// <returns></returns>
        public static string CreateTempFolder()
        {
            string tempPath = string.Empty;
            tempPath = Environment.CurrentDirectory + "\\Temp";

            /// Create Temp Path for album file
            //MessageBox.Show(tempPath);
            try
            {
                Directory.CreateDirectory(tempPath);
                return tempPath;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
