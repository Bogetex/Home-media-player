/// Playlist Class
/// This class represents a collection of photos in Directory.
/// This file can by Image file, Medid file, Audio File
/// By Ali Abdulhussein 27 feb. 2015


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.ComponentModel.DataAnnotations;
using DataLib;


namespace MediaPlayerLib
{
    public class PlayListCollection:ObservableCollection<FileType>
    {
        #region Fields
        #endregion

        #region Constractors
        public PlayListCollection()
        { }
        #endregion

        #region Properties
        [Key]
        public int PlayListId
        { get; set; }
        
        #endregion

        #region Methods
        #endregion
    }
}
