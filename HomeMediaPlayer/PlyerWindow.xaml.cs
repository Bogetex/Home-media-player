using System;
using System.Collections.Generic;
using System.Windows;

namespace HomeMediaPlayer
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private List<string> m_PlayerList = new List<string>();
        int index = 0;

        /// <summary>
        /// Update Assignment3, Action even delegation.
        /// </summary>
        public event Action PlayFileEvent;

        /// <summary>
        /// Default constractor
        /// </summary>
        public PlayerWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constractor with file name parameter
        /// When instance playerwindow class with one file
        /// </summary>
        /// <param name="fileName"></param>
        public PlayerWindow(string fileName)
            : this()
        {
            ///file://C:\CSharpe Kors file\Csharp III\Assignment1\HomeMediaPlayer\Resources\arrow-090.png
            mePlayer.Source = new Uri("file://" + fileName);
            mePlayer.Play();
        }
        /// <summary>
        /// List of file Constractor, instance of player class with list of file play list
        /// </summary>
        /// <param name="filesList"></param>
        public PlayerWindow(List<string> filesList)
            : this()
        {
            m_PlayerList = filesList;
            PlayAttIndex(0);
        }

        /// <summary>
        /// Update Assignment3
        /// Show form method, using Event == null
        /// If Event == null, no event fired than show form player
        /// But if event != null this mean the "No file to play" event was fird, Now form to show. 
        /// </summary>
        public void showForm()
        {
            if (PlayFileEvent == null)
            {
                this.Show();
            }
        }

        /// <summary>
        /// Play selected file from list
        /// </summary>
        /// <param name="index"></param>
        private void PlayAttIndex(int index)
        {
            if (CheckIndex(index))
            {
                mePlayer.Source = new Uri("file://" + m_PlayerList[index]);
                mePlayer.Play();
            }

        }
        /// <summary>
        /// Check index validtion
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool CheckIndex(int index)
        {
            bool Ok = true;
            if ((index >= m_PlayerList.Count) || (index <= -1))
            {
                Ok = false;
                if (m_PlayerList.Count <= 0)
                {
                    PlayFileEvent += () =>
                    {
                        MessageBox.Show("No file to play!");
                        this.Close();
                    };
                    PlayFileEvent();
                }

            }
            return Ok;
        }
        /// <summary>
        /// Stop playing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }
        /// <summary>
        /// Play file event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayAttIndex(index);
        }
        /// <summary>
        /// Pause file play event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }
        /// <summary>
        /// Play next file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            index = index + 1;
            if (index < m_PlayerList.Count - 1)
            {
                PlayAttIndex(index);
            }
            else
            {
                PlayFileEvent();
            }

        }
        /// <summary>
        /// Play previos event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevios_Click(object sender, RoutedEventArgs e)
        {
            index = index - 1;
            PlayAttIndex(index);
        }
        /// <summary>
        /// Exit app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Source = null;
            this.Close();
        }
    }
}
