/// Album Class, represent Album object
/// By ALi Abdulhussein
/// 03 Mars. 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesLib;

namespace DataLib
{
    public class Album
    {
        #region Fields
        private int m_id=0;
        private string m_Name=string.Empty;
        private byte[] m_thumbnailImage;
        private string m_Path=string.Empty;
        private DateTime m_CreationDate;
        private DateTime m_ModificationDate;
        private List<FileType> m_AlbumFileList;
        #endregion

        #region Constractor
        /// <summary>
        /// Default constractor with all Instance variable Initializations
        /// </summary>
        public Album()
        {
            m_AlbumFileList = new List<FileType>();
            //Set the path to it's default Application Folder.
            m_Path = Environment.CurrentDirectory;
        }

        public Album(string name):this()
        {
            m_Name = name;
        }

        public Album(Album other)
        {
            this.m_id = other.Id;
            this.m_Name = other.Name;
            this.m_thumbnailImage = other.ThumbnailImage;
            this.m_Path = other.Path;
            this.m_CreationDate = other.CreationDate;
            this.m_ModificationDate = other.ModificationDate;
            this.m_AlbumFileList = other.AlbumFileList;
        }
        #endregion

        #region Properties
        public int Id
        {
            get { return m_id; }
            set
            {
                if (TypeValidation.ValidateIntegerInput(value))
                    m_id = value;
            }
        }
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (TypeValidation.ValisateStringInput(value))
                    m_Name = value;
            }
        }
        public byte[] ThumbnailImage
        {
            get { return m_thumbnailImage; }
            set
            {
                m_thumbnailImage = value;
            }
        }
        public string Path
        {
            get { return m_Path; }
            set
            {
                if (TypeValidation.ValisateStringInput(value))
                    m_Path = value;
            }
        }
        public List<FileType> AlbumFileList
        {
            get { return m_AlbumFileList; }
            set
            {
                m_AlbumFileList = value;
            }
        }
        /// <summary>
        /// Return Folder or Album Modification Meta info
        /// </summary>
        public DateTime ModificationDate
        {
            get { return m_ModificationDate; }
            set
            {
                m_ModificationDate = value;
            }
        }
        /// <summary>
        /// Return Folder or Album Creation Meta info
        /// </summary>
        public DateTime CreationDate
        {
            get { return m_CreationDate; }
            set
            {
                m_CreationDate = value;
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// Count the number of item in File list
        /// </summary>
        /// <returns></returns>
        public int NumberOfFileInFileList()
        {
            return AlbumFileList.Count;
        }
        /// <summary>
        /// Check if Album have thumbnail IMage.
        /// </summary>
        /// <returns></returns>
        public bool HaveThumbnailImage()
        {
            if (ThumbnailImage!=null)
                return true;
            else
                return false;
        }
        #endregion
    }
}
