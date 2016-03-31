using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLib
{
    public class HomeMediaDBContext:DbContext
    {
        public HomeMediaDBContext()
            //: base("name=HomeMediaDBContext") 
            : base("name=HomeMediaDBContextServer") 
        {
            //Database.SetInitializer<HomeMediaDBContext>(new MySeedingClass());
        }


        public DbSet<FileType> FilesTypeDbSet { get; set; }
        public DbSet<SlidShow> SlidShowDbSet { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SlidShow>()
                .HasMany<FileType>(s => s.Files)
                .WithRequired(s => s.SlidShow)
                .HasForeignKey(s=>s.SlidId);
             
        }
        
    }
}
