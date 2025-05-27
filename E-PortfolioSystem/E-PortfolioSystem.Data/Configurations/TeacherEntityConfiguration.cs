namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
    public class TeacherEntityConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder.HasData(this.GenerateTeachers());
        }

        private Teacher[] GenerateTeachers()
        {
            return new[]
        {
                new Teacher
                {
                    Id = Guid.Parse("99f1710c-97b3-4bd3-8171-e0dc986d313d"),
                    UserId = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09") // Teacher User 1
                },
                new Teacher
                {
                    Id = Guid.Parse("be0087cd-b86f-47b0-bde4-1632f8fd632e"),
                    UserId = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994") // Teacher User 2
                },
                new Teacher
                {
                    Id = Guid.Parse("c7f6b928-bbd3-4ae9-bad5-91e417b59a98"),
                    UserId = Guid.Parse("dcbcf227-4302-4743-8c99-e216bc1a6aef") // Teacher User 3
                },
                new Teacher
                {
                    Id = Guid.Parse("b34045a7-94f6-4e32-a7e7-f36eb9a387e3"),
                    UserId = Guid.Parse("94b8a56e-4a0f-4f39-8e83-1ad38c207d30") // Teacher User 4
                },
                new Teacher
                {
                    Id = Guid.Parse("abdcf0bb-76b4-4a4d-a369-e2de9a6d4d65"),
                    UserId = Guid.Parse("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5") // Teacher User 5
                }
            };
        }
    }
}
