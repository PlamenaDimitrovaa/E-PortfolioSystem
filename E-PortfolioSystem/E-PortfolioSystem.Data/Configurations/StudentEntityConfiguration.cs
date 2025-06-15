namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasMany(s => s.Educations)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(s => s.Certificates)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(s => s.Experiences)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(this.GenerateStudents());
        }

        private Student[] GenerateStudents()
        {
            ICollection<Student> students = new HashSet<Student>();

            Student student;

            student = new Student()
            {
                Id = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                UserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"),
                IsActive = true,
                FacultyNumber = "FN2023001"
            };

            students.Add(student);

            student = new Student()
            {
                Id = Guid.Parse("7f3cd066-6f98-43e2-bff1-17972e62f202"),
                UserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"),
                IsActive = true,
                FacultyNumber = "FN2023002"
            };

            students.Add(student);

            student = new Student()
            {
                Id = Guid.Parse("cb3c4c29-7a2b-4c98-91de-57b28f35b920"),
                UserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"),
                IsActive = true,
                FacultyNumber = "FN2023003"
            };

            students.Add(student);

            student = new Student()
            {
                Id = Guid.Parse("b61b3a88-78d9-4044-a166-2b8754ec255e"),
                UserId = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"),
                IsActive = true,
                FacultyNumber = "FN2023004"
            };

            students.Add(student);

            student = new Student()
            {
                Id = Guid.Parse("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"),
                UserId = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"),
                IsActive = true,
                FacultyNumber = "FN2023005"
            };

            students.Add(student);

            return students.ToArray();
        }
    }
}
