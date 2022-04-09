using Microsoft.EntityFrameworkCore;
using StudiesOrganizer.Database.Configurations;
using StudiesOrganizer.Models;

namespace StudiesOrganizer.Database
{
    public class StudiesOrganizerDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        #region CMMENT_WHEN_ADD_MIGRATION
        public StudiesOrganizerDbContext(DbContextOptions<StudiesOrganizerDbContext> options)
        : base(options)
        {
            Database.Migrate();
        }
        #endregion

        #region USE_TO_MIGRATION
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source = StudiesOrganizer.db");
        //}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentSubjectConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
