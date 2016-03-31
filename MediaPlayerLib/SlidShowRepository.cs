using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib;

namespace MediaPlayerLib
{
    public class SlidShowRepository:Repository<SlidShow>
    {
        public SlidShowRepository()
        {
        }

        public void AddNewSlidShow(SlidShow objIn)
        {
            try
            {
                base.Insert(objIn);
            }
            catch (Exception)
            {
            }
        }
    }
}
