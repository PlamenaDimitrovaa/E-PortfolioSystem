namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;

    public class EmailEntityConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasOne(e => e.FromUser)
                .WithMany()
                .HasForeignKey(e => e.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.ToUser)
                .WithMany()
                .HasForeignKey(e => e.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.HasData(this.GenerateEmails()); гърми
        }

        private Email[] GenerateEmails()
        {
            return new[]
             {
                new Email
                {
                    Id = Guid.Parse("aaa111aa-1111-1111-1111-111111111111"),
                    FromUserId = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09"), // Teacher 1
                    ToUserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"), // Student 1
                    Subject = "Обратна връзка по проекта",
                    Body = "Здравей Иван, разгледах проекта ти и имам някои предложения за подобрение.",
                    SentAt = new DateTime(2025, 5, 20, 9, 30, 0, DateTimeKind.Utc)
                },
                new Email
                {
                    Id = Guid.Parse("bbb222bb-2222-2222-2222-222222222222"),
                    FromUserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"), // Student 1
                    ToUserId = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09"), // Teacher 1
                    Subject = "Благодаря за обратната връзка",
                    Body = "Благодаря Ви, ще направя нужните корекции!",
                    SentAt = new DateTime(2025, 5, 22, 8, 15, 0, DateTimeKind.Utc)
                },
                new Email
                {
                    Id = Guid.Parse("ccc333cc-3333-3333-3333-333333333333"),
                    FromUserId = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994"), // Teacher 2
                    ToUserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"), // Student 2
                    Subject = "Предстоящо представяне",
                    Body = "Здравей Мария, напомням ти за представянето в петък. Подготви кратко резюме.",
                    SentAt = new DateTime(2025, 5, 23, 14, 0, 0, DateTimeKind.Utc)
                },
                new Email
                {
                    Id = Guid.Parse("ddd444dd-4444-4444-4444-444444444444"),
                    FromUserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"), // Student 2
                    ToUserId = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994"), // Teacher 2
                    Subject = "Резюме за представянето",
                    Body = "Здравейте, изпращам ви резюмето за утрешното представяне.",
                    SentAt = new DateTime(2025, 5, 24, 16, 30, 0, DateTimeKind.Utc)
                },
                new Email
                {
                    Id = Guid.Parse("eee555ee-5555-5555-5555-555555555555"),
                    FromUserId = Guid.Parse("c7f6b928-bbd3-4ae9-bad5-91e417b59a98"), // Teacher 3
                    ToUserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"), // Student 3
                    Subject = "График за консултация",
                    Body = "Николай, свободен съм в сряда следобед. Удобно ли е за теб?",
                    SentAt = DateTime.UtcNow.AddDays(-1)
                }
            };
        }
    }
}
