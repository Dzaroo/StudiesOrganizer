using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudiesOrganizer.Models;

namespace StudiesOrganizer.Database.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.ToTable("StudentSubjects");

            builder.HasKey(ss => new {ss.StudentId, ss.SubjectId});

            builder.HasOne<Student>(ss => ss.Student)
                .WithMany(st => st.StudentSubjects);
                //.HasForeignKey(ss => ss.StudentId);

            builder.HasOne<Subject>(ss => ss.Subject)
                .WithMany(su => su.StudentSubjects);
                //.HasForeignKey(ss => ss.SubjectId);
        }
    }
}
