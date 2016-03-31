using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataLib;

namespace MediaPlayerLib
{
    public static class FileTypeUtilities
    {
        public static FileType FileTypeGenerator(FileTypeEnum typeOfFile)
        {
            FileType obj = null;
            /*
            switch (typeOfFile)
            {
                case FileTypeEnum.mp4:
                    obj = new Mp4FileType();
                    break;
                case FileTypeEnum.wav:
                    obj = new WavFileType();
                    break;
                case FileTypeEnum.png:
                    obj = new PngFileType();
                    break;
                case FileTypeEnum.jpg:
                    obj = new JpgFileType();
                    break;
                default:
                    break;
            }
             * return obj;
             */
            return obj=new FileType();
        }

        public static FileTypeEnum FileExtentionToEnummeration(string fileName)
        {
            FileTypeEnum outValue;
            string extenstion = string.Empty;
            extenstion = Path.GetExtension(fileName);
            extenstion = extenstion.Substring(1, extenstion.Length-1);
            outValue = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum), extenstion);
            return outValue;
        }
    }
}
