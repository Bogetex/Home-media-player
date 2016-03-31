/// By Ali abdulhussein
/// Seeding db with defalut data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLib
{
    public class MySeedingClass : DropCreateDatabaseIfModelChanges<HomeMediaDBContext>
    {
        protected override void Seed(HomeMediaDBContext context)
        {
            IList<FileType> fileDefaultValue = new List<FileType>();
            fileDefaultValue.Add(new FileType() { Name = "file01", Description = "Some text" });
            fileDefaultValue.Add(new FileType() { Name = "file02", Description = "Some text" });
            fileDefaultValue.Add(new FileType() { Name = "file03", Description = "Some text" });
            fileDefaultValue.Add(new FileType() { Name = "file04", Description = "Some text" });

            IList<SlidShow> defaultValue = new List<SlidShow>();
            defaultValue.Add(new SlidShow() { SlidShowName = "slid00", Files = fileDefaultValue });

            foreach (var item in defaultValue)
            {
                context.SlidShowDbSet.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
