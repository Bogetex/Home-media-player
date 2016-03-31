using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataLib
{
    public enum FileTypeEnum 
    {
        [Description(".Mp4")]
        mp4,
        [Description(".Wav")]
        wav,
        [Description(".Png")]
        png,
        [Description(".Jpg")]
        jpg
    }
}
