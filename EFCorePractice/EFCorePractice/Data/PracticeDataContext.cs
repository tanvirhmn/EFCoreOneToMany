using EFCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.Data
{
    public class PracticeDataContext:DbContext
    {
        public PracticeDataContext(DbContextOptions<PracticeDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.CurrentGradeId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Student>? Students { get; set; }
    }
}
