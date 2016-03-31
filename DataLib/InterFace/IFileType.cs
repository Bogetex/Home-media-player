using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib
{
    public interface IFileType
    {
        int FileId { get; set; }
        string Name { get; set; }
        double Size { get; set; }
        string Path { get; set; }
        
        FileTypeEnum TypeOfFile { get; set; }
        string Description { get; set; }

        byte[] ThumbNailImage { get; set; }
    }
}
