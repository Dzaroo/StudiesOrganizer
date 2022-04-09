using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudiesOrganizer.Models;

namespace StudiesOrganizer.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(st => st.Id);

            builder.Property(st => st.Name).HasMaxLength(50);
            builder.Property(st => st.Surname).HasMaxLength(70);
            builder.Property(st => st.Pesel).HasMaxLength(11);

            builder.Ignore(st => st.FullName);
        }
    }
}
