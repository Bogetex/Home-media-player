/// File Abstract Class
/// Represented blue print for media and image file.
/// By Ali Abdulhussein
/// 24 feb. 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesLib;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLib
{
    public class FileType : IFileType
    {
        #region Fields
        private int m_Id;
        private string m_Name;
        private double m_Size;
        private string m_Path;
        private string m_Description;
        private FileTypeEnum m_TypeOfFile;
        private byte[] m_ThumbNailImage;

        #endregion
        public FileType()
        {
            //m_Id = 0;
            m_Name = string.Empty;
            m_Size = 0;
            m_Path = string.Empty;
            m_Description = string.Empty;
            m_ThumbNailImage = new byte[0];
        }

        #region Properties
        [Key]
        public int FileId
        {
            get
            {
                return m_Id;
            }
            set
            {
                if (TypeValidation.ValidateIntegerInput(value))
                    m_Id = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (TypeValidation.ValisateStringInput(value))
                    m_Name = value;
            }
        }

        public double Size
        {
            get
            {
                return m_Size;
            }
            set
            {
                if (TypeValidation.ValidateDoubleInput(value))
                    m_Size = value;
            }
        }


        public string Path
        {
            get
            {
                return m_Path;
            }
            set
            {
                if (TypeValidation.ValisateStringInput(value))
                    m_Path = value;
            }
        }

        public string Description
        {
            get
            { return m_Description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    m_Description = value;
            }
        }

        public FileTypeEnum TypeOfFile
        {
            get
            {
                return m_TypeOfFile;
            }
            set
            {
                if (Enum.IsDefined(typeof(FileTypeEnum), value))
                    m_TypeOfFile = value;
            }
        }

        public byte[] ThumbNailImage
        {
            get
            {
                return m_ThumbNailImage;
            }
            set
            {
                if (value.Length!=-1)
                    m_ThumbNailImage = value;
            }
        }

        //Each file is amember in one slid show the relation between SlidShow and Files are 1-* one to many.
        #region Relation Navigation properties
        public int SlidId { get; set; }
        public SlidShow SlidShow { get; set; }
        #endregion

        #endregion

        #region Method
        /// <summary>
        /// Return full file Uri
        /// this method can override by the derived class
        /// </summary>
        /// <returns></returns>
        public virtual string fullFilePath()
        {
            return string.Format("{0}\\{1}", m_Path, m_Name);
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", m_Name, m_TypeOfFile.ToString());
        }
        #endregion

    }
}
