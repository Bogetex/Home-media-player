using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLib
{
    public class SlidShow
    {
        private ICollection<FileType> m_ListFile;
        public SlidShow()
        {
            m_ListFile = new List<FileType>();
        }

        [Key]
        public int Id { get; set; }

        public string SlidShowName { get; set; }
        /// <summary>
        /// Each slidShow have many files
        /// </summary>
        public virtual ICollection<FileType> Files 
        {
            get { return m_ListFile; }
            set { m_ListFile = value; } 
        }

    }
}
