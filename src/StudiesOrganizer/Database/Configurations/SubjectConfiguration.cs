using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudiesOrganizer.Models;

namespace StudiesOrganizer.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(su => su.Id);

            builder.Property(su => su.Name).HasMaxLength(100);
            builder.Property(su => su.LecturerFullName).HasMaxLength(120);
        }
    }
}
