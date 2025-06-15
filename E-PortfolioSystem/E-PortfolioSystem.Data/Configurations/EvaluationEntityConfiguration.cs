namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class EvaluationEntityConfiguration : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            builder
                 .HasKey(e => e.Id);

            builder
                .HasOne(e => e.Project)
                .WithOne(p => p.Evaluation)
                .HasForeignKey<Project>(p => p.EvaluationId);

            builder
                .HasOne(e => e.Subject)
                .WithOne(s => s.Evaluation)
                .HasForeignKey<Subject>(s => s.EvaluationId);

            builder
                .HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId);

            builder.HasData(this.GenerateEvaluations());
        }

        private Evaluation[] GenerateEvaluations()
        {
            return new[]
         {
                new Evaluation
                {
                    Id = Guid.Parse("777c1952-01ed-4cce-88c0-6b2a0610d351"),
                    ProjectId = Guid.Parse("122bf74b-69b4-4b2b-81b3-f203cd889a11"),
                    TeacherId = Guid.Parse("99f1710c-97b3-4bd3-8171-e0dc986d313d"),
                    SubjectId = Guid.Parse("ec6942eb-7f50-4f4b-8011-891c5051eb32"),
                    SubjectGrade = 6,
                    ProjectGrade = 5,
                    Feedback = "Отлична имплементация на концепции от Изкуствения интелект с изчистен потребителски интерфейс.",
                    EvaluationType = "Финална",
                    CreatedAt = new DateTime(2024, 6, 20, 0, 0, 0, DateTimeKind.Utc)
                },
                new Evaluation
                {
                    Id = Guid.Parse("6ad69f6e-7c4c-4a5b-aeb6-bb43d193bce5"),
                    ProjectId = Guid.Parse("2f5b887d-3c46-45e1-b826-3dbbe8570dd8"),
                    TeacherId = Guid.Parse("be0087cd-b86f-47b0-bde4-1632f8fd632e"),
                    SubjectId = Guid.Parse("31bc0e6b-4f14-4212-b67e-9b61f3e58f73"),
                    SubjectGrade = 5,
                    ProjectGrade = 5,
                    Feedback = "Добре структурирано и с изчистен код",
                    EvaluationType = "Финална",
                    CreatedAt = new DateTime(2024, 7, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Evaluation
                {
                    Id = Guid.Parse("f9d41ad3-6f3e-4861-82de-d0a0df68b798"),
                    ProjectId = Guid.Parse("1c83cafd-c4f7-4eb1-809c-2703df8c29c5"),
                    TeacherId = Guid.Parse("c7f6b928-bbd3-4ae9-bad5-91e417b59a98"),
                    SubjectId = Guid.Parse("8e3c0f29-c432-45c9-9e32-7a7a1df28523"),
                    SubjectGrade = 6,
                    ProjectGrade = 4,
                    Feedback = "Красив потребителски интерфейс, логически грешки, трябва да се поработи върху идеята.",
                    EvaluationType = "Защита",
                    CreatedAt = new DateTime(2024, 7, 30, 0, 0, 0, DateTimeKind.Utc)
                },
                new Evaluation
                {
                    Id = Guid.Parse("8f74e0e4-3b4a-496a-a6d7-219d0108fc34"),
                    ProjectId = Guid.Parse("c2e6dffd-19d4-4b80-bf3b-d5a69fae59b0"),
                    TeacherId = Guid.Parse("b34045a7-94f6-4e32-a7e7-f36eb9a387e3"),
                    SubjectId = Guid.Parse("7f489f70-911e-40a4-8b79-1d6c3315c8cb"),
                    SubjectGrade = 4,
                    ProjectGrade = 5,
                    Feedback = "Креативна идея, трябват подобрения в UX.",
                    EvaluationType = "Защита",
                    CreatedAt = new DateTime(2024, 8, 20, 0, 0, 0, DateTimeKind.Utc)
                },
                new Evaluation
                {
                    Id = Guid.Parse("c025b27d-74a4-419f-b61f-64f7ab94a0b5"),
                    ProjectId = Guid.Parse("b79cb4a7-0ab0-4a7c-b86a-8b35c46a74fd"),
                    TeacherId = Guid.Parse("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65"),
                    SubjectId = Guid.Parse("c4c2079d-1ed1-4f5f-8e36-4b03cc6e71da"),
                    SubjectGrade = 6,
                    ProjectGrade = 6,
                    Feedback = "Прекрасна работа!",
                    EvaluationType = "Финална",
                    CreatedAt = new DateTime(2024, 9, 5, 0, 0, 0, DateTimeKind.Utc)
                }
            };
        }
    }
}
