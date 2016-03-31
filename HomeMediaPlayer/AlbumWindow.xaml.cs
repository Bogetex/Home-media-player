/// By Ali Abdulhussein
/// 02 Mars 2015
/// 
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using UtilitiesLib;
using MediaPlayerLib;
using DataLib;

namespace HomeMediaPlayer
{
    /// <summary>
    /// Interaction logic for AlbumWindow.xaml
    /// </summary>
    public partial class AlbumWindow : Window
    {
        #region Instance variale
        System.Windows.Forms.FolderBrowserDialog fbdSearchForFile;
        string path = string.Empty;

        #endregion

        #region Constractor
        public AlbumWindow()
        {
            InitializeComponent();
            InitializedGUI();

        }
        #endregion

        #region Properies
        #endregion

        #region Methods
        /// <summary>
        /// Initialized GUI
        /// </summary>
        private void InitializedGUI()
        {
            this.Title = "Create New Album";
            fbdSearchForFile = new System.Windows.Forms.FolderBrowserDialog();
        }


        /// <summary>
        /// Add media file to listview
        /// Add only file type that include in Enum file type.
        /// </summary>
        private void UpdateListViewFileBrowser()
        {
            //MessageBox.Show(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo item in dir.GetFiles("*.*"))
            {
                //MessageBox.Show(item.Extension.TrimStart('.'));
                if (Enum.IsDefined(typeof(FileTypeEnum), item.Extension.TrimStart('.')))
                    lstBrowsFile.Items.Add(item);
            }
        }

        /// <summary>
        /// Copy all file from Listview to Temp Folder
        /// </summary>
        /// <param name="objListview"></param>
        /// <param name="tmpPath"></param>
        private void CopyFilesFromListViewToPathe(ListView objListview, string tmpPath)
        {
            string tempFile = string.Empty;
            /// Copy file from original path to Temp path
            FileInfo fileItem;
            try
            {
                foreach (var item in objListview.Items)
                {
                    fileItem = new FileInfo(path + "\\" + item.ToString());
                    tempFile = tmpPath + "\\" + item;
                    fileItem.CopyTo(tempFile, true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Create Album
        /// Each Album is a collection of file in specific folder and this folder has a name (Album name)
        /// If no name specified create Album with New Album
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string CreateAlbumFolder(string name)
        {
            /// Create Directory in My Library 
            string albumPath;
            if (!string.IsNullOrWhiteSpace(name))
                albumPath = Environment.CurrentDirectory + "\\My Library\\" + name;
            else
                albumPath = Environment.CurrentDirectory + "\\My Library\\" + "New Album";

            try
            {
                // Determinde wather if directory Exists
                if (Directory.Exists(albumPath))
                {
                    MessageBox.Show("Album already Exist...!");
                }

                //Try to create the directory
                DirectoryInfo newAlbum = Directory.CreateDirectory(albumPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The process failed:{0}", ex.Message);
            }
            return albumPath;
        }

        private bool CreateAlbum()
        {
            bool Ok = false;
            if (TypeValidation.validateIndex(lstAlbumFile.Items.Count))
            {
                // Create Temp folder to hold Album File
                string tempPath = string.Empty;
                try
                {
                    tempPath = DircetoryHelpMethods.CreateTempFolder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Temp Folder Fail");
                }

                /// Copy all files in AlbumListview to Temp Folder
                CopyFilesFromListViewToPathe(lstAlbumFile, tempPath);

                // Create Album Foder
                string newAlbumPath = string.Empty;
                newAlbumPath = CreateAlbumFolder(txtAlbumName.Text);

                /// Copy all file from Temp folder to Special Media file folder (My Library)
                try
                {
                    DircetoryHelpMethods.copyFileFromSourceToDestination(tempPath, newAlbumPath);
                    Ok = true;
                    Directory.Delete(tempPath,true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail to copy file");
                }
            }
            return Ok;
        }
        #endregion

        #region Events

        private void btnSearchForFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = fbdSearchForFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = fbdSearchForFile.SelectedPath;
                txtPath.Text = path;
                UpdateListViewFileBrowser();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Form Closing Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Close this window..! ","Worning",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Copy file to Temp folder/directory
        /// When click Ok/Save copy file from Temp folder to album folder
        /// Remove file from Temp folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (!lstAlbumFile.Items.Contains(lstBrowsFile.SelectedItem))
                lstAlbumFile.Items.Add(lstBrowsFile.SelectedItem);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (CreateAlbum())
            {
                //Return DialogResult to invoker
                this.DialogResult = true;
            }
        }
        /// <summary>
        /// Remove selected item from album listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFromAlbum_Click(object sender, RoutedEventArgs e)
        {
            lstAlbumFile.Items.RemoveAt(lstAlbumFile.SelectedIndex);
        }


        #endregion


    }
}
