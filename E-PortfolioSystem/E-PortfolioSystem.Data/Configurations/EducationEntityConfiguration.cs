namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EducationEntityConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Student)
                .WithMany(s => s.Educations)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(this.GenerateEducations());
        }

        private Education[] GenerateEducations()
        {
            return new[]
           {
                new Education
                {
                    Id = Guid.Parse("d74b56a7-f444-42ed-b5d5-f5c416d5a80f"),
                    StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                    Institution = "Технически университет - София",
                    Degree = "Бакалавър",
                    Specialty = "Компютърни системи и технологии",
                    Faculty = "Факултет по компютърни науки",
                    StartDate = new DateTime(2021, 10, 1),
                    EndDate = new DateTime(2025, 6, 30)
                },
                new Education
                {
                    Id = Guid.Parse("9eabfcee-2f79-4b8e-9537-92e7c655b9c7"),
                    StudentId = Guid.Parse("7f3cd066-6f98-43e2-bff1-17972e62f202"),
                    Institution = "Софийски университет",
                    Degree = "Бакалавър",
                    Specialty = "Софтуерно инженерство",
                    Faculty = "Факултет по математика и информатика",
                    StartDate = new DateTime(2020, 10, 1),
                    EndDate = new DateTime(2024, 6, 30)
                },
                new Education
                {
                    Id = Guid.Parse("1e527d02-9797-4e9f-8bfc-b62412754427"),
                    StudentId = Guid.Parse("cb3c4c29-7a2b-4c98-91de-57b28f35b920"),
                    Institution = "Нов български университет",
                    Degree = "Бакалавър",
                    Specialty = "Информационни технологии",
                    Faculty = "Департамент по информатика",
                    StartDate = new DateTime(2022, 9, 15),
                    EndDate = new DateTime(2026, 7, 1)
                },
                new Education
                {
                    Id = Guid.Parse("712de13f-8c38-4dd5-aac0-82c10b3f3a21"),
                    StudentId = Guid.Parse("b61b3a88-78d9-4044-a166-2b8754ec255e"),
                    Institution = "Технически университет - Варна",
                    Degree = "Бакалавър",
                    Specialty = "Автоматизация, информационна и управляваща техника",
                    Faculty = "Факултет по автоматизация и изчислителна техника",
                    StartDate = new DateTime(2021, 10, 1),
                    EndDate = new DateTime(2025, 6, 30)
                },
                new Education
                {
                    Id = Guid.Parse("347aeb9f-b7d3-4b84-ae50-ea154d94b1cb"),
                    StudentId = Guid.Parse("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"),
                    Institution = "Пловдивски университет",
                    Degree = "Бакалавър",
                    Specialty = "Приложна компютърна лингвистика",
                    Faculty = "Факултет по математика и информатика",
                    StartDate = new DateTime(2020, 10, 1),
                    EndDate = new DateTime(2024, 6, 30)
                }
            };
        }
    }
}
