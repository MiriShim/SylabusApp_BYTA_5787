using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SylabusApp
{

    internal class SylabusContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<SubUnit> SubUnits { get; set; }
        public DbSet<Student> Students { get; set; }


        //Connection string


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL-KITOTBB\\TICHNUT;Initial Catalog=SylabusDB_Teacher;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // סדר ההוספה לא משנה, EF Core מסדר לפי תלויות
            modelBuilder.Entity<Student>().HasData(
                new Student { UserId = 1, FirstName = "דוד", LastName = "כהן", Email = "david.cohen@example.com", Phone = "050-1234567" },
                new Student { UserId = 3, FirstName = "יוסף", LastName = "לוי", Email = "yosef.levi@example.com", Phone = "052-2345678" },
                new Student { UserId = 5, FirstName = "משה", LastName = "פרידמן", Email = "moshe.friedman@example.com", Phone = "054-3456789" },
                new Student { UserId = 6, FirstName = "אברהם", LastName = "שפירא", Email = "avraham.shapira@example.com", Phone = "053-4567890" }
);
            modelBuilder.Entity<Subject>()
               .Property(s => s.SubjectName)
               .HasMaxLength(20);

            modelBuilder.Entity<SubUnit>()
                .Property(s => s.ParentId)
                .HasDefaultValueSql("1");

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>(entity =>
        //    {
        //        entity.ToTable("tblStudents" );

        //        entity.HasKey(c => c.UserId);

        //        entity.Property(c => c.FirstName)
        //              .IsRequired()
        //              .HasMaxLength(100);

        //    });

        //}
    }
}
