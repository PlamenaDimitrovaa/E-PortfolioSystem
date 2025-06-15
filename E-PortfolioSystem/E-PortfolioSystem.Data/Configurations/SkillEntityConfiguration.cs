namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class SkillEntityConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder
                .HasKey(s => s.Id);
            var skills = new[]
      {
                new Skill
                {
                    Id = Guid.Parse("3a991cc1-f84e-466e-9962-70c50c634b76"),
                    SkillName = "C# Програмиране",
                    Level = "Напреднал"
                },
                new Skill
                {
                    Id = Guid.Parse("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4"),
                    SkillName = "SQL",
                    Level = "Междинен"
                },
                new Skill
                {
                    Id = Guid.Parse("54cc88d3-f8a4-4716-bd3b-b92c915e3df6"),
                    SkillName = "HTML & CSS",
                    Level = "Напреднал"
                },
                new Skill
                {
                    Id = Guid.Parse("4ff51c1f-90a4-41de-b165-001de306d93e"),
                    SkillName = "JavaScript",
                    Level = "Междинен"
                },
                new Skill
                {
                    Id = Guid.Parse("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a"),
                    SkillName = "ASP.NET Core",
                    Level = "Начинаещ"
                }
            };

            builder.HasData(skills);
        }
    }
}
