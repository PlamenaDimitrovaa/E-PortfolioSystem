namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class StudentSubjectEntityConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(ss => new { ss.StudentId, ss.SubjectId });

            builder
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(GenerateStudentSubjects());
        }

        private StudentSubject[] GenerateStudentSubjects()
        {
            return new[]
            {
                new StudentSubject
                {
                    StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                    SubjectId = Guid.Parse("ec6942eb-7f50-4f4b-8011-891c5051eb32"),
                    EnrolledOn = new DateTime(2024, 9, 15, 8, 0, 0, DateTimeKind.Utc)
                },
                new StudentSubject
                {
                    StudentId = Guid.Parse("7f3cd066-6f98-43e2-bff1-17972e62f202"),
                    SubjectId = Guid.Parse("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"),
                    EnrolledOn = new DateTime(2024, 9, 16, 9, 0, 0, DateTimeKind.Utc)
                },
                new StudentSubject
                {
                    StudentId = Guid.Parse("cb3c4c29-7a2b-4c98-91de-57b28f35b920"),
                    SubjectId = Guid.Parse("8e3c0f29-c432-45c9-9e32-7a7a1df28523"),
                    EnrolledOn = new DateTime(2024, 9, 17, 10, 0, 0, DateTimeKind.Utc)
                },
                new StudentSubject
                {
                    StudentId = Guid.Parse("b61b3a88-78d9-4044-a166-2b8754ec255e"),
                    SubjectId = Guid.Parse("7f489f70-911e-40a4-8b79-1d6c3315c8cb"),
                    EnrolledOn = new DateTime(2024, 9, 18, 11, 0, 0, DateTimeKind.Utc)
                },
                new StudentSubject
                {
                    StudentId = Guid.Parse("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"),
                    SubjectId = Guid.Parse("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"),
                    EnrolledOn = new DateTime(2024, 9, 19, 12, 0, 0, DateTimeKind.Utc)
                }
            };
        }
    }
}
