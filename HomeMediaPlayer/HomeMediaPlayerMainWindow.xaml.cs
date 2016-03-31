/// By Ali Abdulhussein
/// 22 feb. 2015
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using MediaPlayerLib;
using DataLib;


namespace HomeMediaPlayer
{
    /// <summary>
    /// Interaction logic for FileBrowserWindow.xaml
    /// </summary>
    public partial class HomeMediaPlayerMainWindow : Window
    {
        #region Variable
        private string path = Environment.CurrentDirectory;

        //Default path to my library folder
        private string libraryPath = "\\My library\\";

        //Album Name
        private string albumName = string.Empty;

        //Album list
        private List<string> m_albumList;

        //PlayList list
        private PlayListCollection m_playList;

        //Player window inititalization
        private PlayerWindow dlgPlayerWindow;

        //File object
        private FileType obj;

        //The selected tree view item wher than act as treeview
        private TreeView SelectedTreeItem = new TreeView();

        //Repository file.
        private SlidShowRepository slidShowRepo;

        //Slid show obj
        private SlidShow slidShowObj;

        //The status of treeview selected item, if item selected or not.
        private bool treeItemSelectedStatus = false;
        #endregion

        #region Constractor
        /// <summary>
        /// Default Constractor
        /// </summary>
        public HomeMediaPlayerMainWindow()
        {
            InitializeComponent();
            InitializedGUI();

        }
        #endregion


        #region Method
        /// <summary>
        /// Initialized GUI
        /// </summary>
        private void InitializedGUI()
        {
            this.Title = "Home media player";
            m_albumList = new List<string>();
            m_playList = new PlayListCollection();
            slidShowObj = new SlidShow();

            //Subscribe to Tree view Selected Event.
            treeViewAlbums.Selected += OnTreeItemSelected;
            btnSaveSlidShow.IsEnabled = false;

        }

        private void OnTreeItemSelected(object sender, RoutedEventArgs e)
        {

            if (sender != null)
            {
                treeItemSelectedStatus = true;
            }
        }

        /// <summary>
        /// Add all Folder Album inside My library to TreeView album as tree Node
        /// </summary>
        /// <param name="control"></param>
        /// <param name="itemPath"></param>
        private void UpdateTreeViewWithItem(TreeViewItem control, string itemPath)
        {
            control.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(itemPath);
            //If directory not found in Release mode
            try
            {
                foreach (var item in dir.GetDirectories())
                {
                    m_albumList.Add(item.ToString());
                    control.Items.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        /// <summary>
        /// Search file in agiven path and add thiem to ListView,
        /// In Next version will try to show file as icon.
        /// </summary>
        /// <param name="path"></param>
        private void UpdateAlbumFileListView(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                lstAlbumFile.Items.Clear();
                foreach (var item in dir.GetFiles())
                {
                    lstAlbumFile.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Add selected file to DataGrid
        /// by updated data source and bind GridColumn to Class Member
        /// </summary>
        private void AddObjectToDataGrid(object item)
        {
            string fileType = Path.GetExtension(path + libraryPath + item);
            obj = new FileType();

            try
            {
                obj.TypeOfFile = FileTypeUtilities.FileExtentionToEnummeration(fileType);
                obj.Name = Path.GetFileNameWithoutExtension(path + libraryPath + item);
                obj.Description = string.Empty;
                m_playList.Add(obj);

                //Add file to DataBase, Slidshow Table
                slidShowObj.Files.Add(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateGUI();

        }
        /// <summary>
        /// Update DataGrid.
        /// </summary>
        private void UpdateGUI()
        {
            dgrPlayList.ItemsSource = null;
            dgrPlayList.ItemsSource = m_playList;

            if (dgrPlayList.Items.Count > 0)
                btnSaveSlidShow.IsEnabled = true;

        }
        #endregion


        #region Event
        /// <summary>
        /// Open album, not implemnted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Emplmented");
        }

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Invoke New album windows
        /// If dialogResult True, Iterate throught all folder in My library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuNewAlbum_Click(object sender, RoutedEventArgs e)
        {
            btnNewAlbum_Click(sender, e);
        }

        /// <summary>
        /// Add new album
        /// Show add new album window, by call mnuNewAlbum event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewAlbum_Click(object sender, RoutedEventArgs e)
        {
            AlbumWindow dlgAlbumWindow = new AlbumWindow();
            if (dlgAlbumWindow.ShowDialog() == true)
            {
                UpdateTreeViewWithItem(treeViewAlbums, path + libraryPath);
            }
        }

        /// <summary>
        /// Delete Selected Album from My library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Delete this album..!", "Worning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            //Delete Folder
            if (result == MessageBoxResult.OK)
            {
                string xPath = path + libraryPath + SelectedTreeItem.SelectedItem.ToString();

                if (Directory.Exists(xPath))
                    Directory.Delete(xPath, true);

                UpdateTreeViewWithItem(treeViewAlbums, path + libraryPath);
                lstAlbumFile.Items.Clear();
            }
        }

        /// <summary>
        /// Update listview with files from selected folder (Album)
        /// I do all work in local list collection, using db just for add items to tmpList
        /// Than make the need operation on tmpList
        /// Just to menimized the need for db connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewAlbums_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Cleare PlayList collection, Every Album has its on play list.
            m_playList.Clear();
            SelectedTreeItem = sender as TreeView;
            albumName = SelectedTreeItem.SelectedItem.ToString();
            if (m_albumList.Contains(albumName))
            {
                UpdateAlbumFileListView(path + libraryPath + albumName);
            }

            /* Add file from Db to data grid view */
            FileTypeRepository fileRepo = new FileTypeRepository();
            List<FileType> slidShoewFilesList = new List<FileType>();

            /// Query i an Annonymous type, take the return value from Select
            /// And using Lambda expretion in this Query
            /// Inside Repostory Select i used Func<>
            var query = fileRepo.Select(a => a.SlidShow.SlidShowName == albumName);
            try
            {
                slidShoewFilesList.AddRange(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Add result file from db to tmpList
            foreach (var item in slidShoewFilesList)
            {
                m_playList.Add(item);
            }

            //Update DataGride with object from TmpListFile
            dgrPlayList.ItemsSource = m_playList;

        }

        /// <summary>
        /// In this Event Initialized TreeView item by:
        /// Generate AlbumList By looping throght all directory in my library
        /// And binding TreeView itemSource to albumlist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewAlbums_Loaded(object sender, RoutedEventArgs e)
        {
            // Add All folders in My library to TreeView
            UpdateTreeViewWithItem(treeViewAlbums, path + libraryPath);
        }

        /// <summary>
        /// Select file from list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAlbumFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddObjectToDataGrid(lstAlbumFile.SelectedItem.ToString());
        }

        /// <summary>
        /// Double click on selected file to play the selected file just selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAlbumFile_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string xpath = path + libraryPath + albumName + "\\";
            List<string> tmpList = new List<string>();
            tmpList.Add(xpath + lstAlbumFile.SelectedItem);
            dlgPlayerWindow = new PlayerWindow(tmpList);
            dlgPlayerWindow.Show();
        }

        /// <summary>
        /// Play media file list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

            string xpath = path + libraryPath + albumName + "\\";
            List<string> tmpList = new List<string>();
            foreach (var item in dgrPlayList.Items)
            {
                tmpList.Add(xpath + item.ToString());
            }

            dlgPlayerWindow = new PlayerWindow(tmpList);

            ///Update Assignment3, If no file to play event rising.
            dlgPlayerWindow.showForm();

            ///Update Assignment3
            /// Subscripte to event by using Annanimous function or method,ambda expretion.
            dlgPlayerWindow.PlayFileEvent += () =>
            {
                MessageBox.Show("No more file to play...!");
            };
        }


        /// <summary>
        /// Using Contex menu to add file to SlidShow (DataGrid)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuContexAdd_Click(object sender, RoutedEventArgs e)
        {
            AddObjectToDataGrid(lstAlbumFile.SelectedItem);
        }

        /// <summary>
        /// Add  selected file to playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (UtilitiesLib.TypeValidation.ValisateStringInput(lstAlbumFile.SelectedItem.ToString()))
                AddObjectToDataGrid(lstAlbumFile.SelectedItem);
        }

        /// <summary>
        /// Remove selected file from playlist 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            int index;
            if (UtilitiesLib.TypeValidation.validateIndex(dgrPlayList.SelectedIndex))
            {
                index = dgrPlayList.SelectedIndex;
                m_playList.RemoveAt(index);
            }
            UpdateGUI();
        }

        /// <summary>
        /// Move item upp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpp_Click(object sender, RoutedEventArgs e)
        {
            int index = dgrPlayList.SelectedIndex;
            if ((index != 0) && (index < m_playList.Count))
            {
                FileType tmpObj = m_playList[index];
                m_playList.RemoveAt(index);
                m_playList.Insert(index - 1, tmpObj);
            }
            else
            {
                MessageBox.Show("Can not move first elment Upp");
            }
        }

        /// <summary>
        /// Move item in Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            int index = dgrPlayList.SelectedIndex;
            if ((index != m_playList.Count - 1) && (index < m_playList.Count))
            {
                FileType tmpObj = m_playList[index];
                m_playList.RemoveAt(index);
                m_playList.Insert(index + 1, tmpObj);
            }
            else
            {
                MessageBox.Show("Can not move Last elment Down");
            }


        }

        /// <summary>
        /// Show help menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow dlgHelp = new HelpWindow();
            dlgHelp.Show();
        }

        /// <summary>
        /// Save slidShow to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveSlidShow_Click(object sender, RoutedEventArgs e)
        {
            slidShowRepo = new SlidShowRepository();
            slidShowObj = new SlidShow();

            if (treeItemSelectedStatus)
            {
                slidShowObj.SlidShowName = SelectedTreeItem.SelectedItem.ToString();
                slidShowObj.Files = m_playList;
                try
                {
                    slidShowRepo.AddNewSlidShow(slidShowObj);
                    MessageBox.Show("New SlidShow Add to Database.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { MessageBox.Show("Selecte Play list Album!", "Wrong"); }
        }

        #endregion




    }

}
