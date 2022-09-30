using Microsoft.EntityFrameworkCore;
using studentProgramV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Data.Concrete.EntityFramework.Mappings;

namespace studentProgramV2.Data.Concrete.EntityFramework.Contexts
{
    public class studentProgramV2Context:DbContext
    {
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=studentProgramV2;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LessonMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
        }
    }
}
