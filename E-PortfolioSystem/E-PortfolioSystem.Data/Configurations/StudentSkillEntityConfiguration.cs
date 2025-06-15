namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class StudentSkillEntityConfiguration : IEntityTypeConfiguration<StudentSkill>
    {
        public void Configure(EntityTypeBuilder<StudentSkill> builder)
        {
            builder.HasKey(ss => new { ss.StudentId, ss.SkillId });

            builder
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSkills)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ss => ss.Skill)
                .WithMany(s => s.StudentSkills)
                .HasForeignKey(ss => ss.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            var studentSkills = new[]
           {
                new StudentSkill
                {
                    StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                    SkillId = Guid.Parse("3a991cc1-f84e-466e-9962-70c50c634b76")
                },
                new StudentSkill
                {
                    StudentId = Guid.Parse("EDB4D7D9-014B-4B2D-8124-6A5CD45F0B67"),
                    SkillId = Guid.Parse("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4")
                },

                new StudentSkill
                {
                    StudentId = Guid.Parse("CB3C4C29-7A2B-4C98-91DE-57B28F35B920"),
                    SkillId = Guid.Parse("54cc88d3-f8a4-4716-bd3b-b92c915e3df6")
                },
                new StudentSkill
                {
                    StudentId = Guid.Parse("B61B3A88-78D9-4044-A166-2B8754EC255E"),
                    SkillId = Guid.Parse("4ff51c1f-90a4-41de-b165-001de306d93e")
                },

                new StudentSkill
                {
                    StudentId = Guid.Parse("7F3CD066-6F98-43E2-BFF1-17972E62F202"),
                    SkillId = Guid.Parse("3a991cc1-f84e-466e-9962-70c50c634b76")
                },
                new StudentSkill
                {
                    StudentId = Guid.Parse("7F3CD066-6F98-43E2-BFF1-17972E62F202"),
                    SkillId = Guid.Parse("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a")
                },

                new StudentSkill
                {
                    StudentId = Guid.Parse("B61B3A88-78D9-4044-A166-2B8754EC255E"),
                    SkillId = Guid.Parse("c5b02d8e-b0fc-4a54-9b5f-8d0e9e8b84c4")
                },
                new StudentSkill
                {
                    StudentId = Guid.Parse("B61B3A88-78D9-4044-A166-2B8754EC255E"),
                    SkillId = Guid.Parse("54cc88d3-f8a4-4716-bd3b-b92c915e3df6")
                },

                new StudentSkill
                {
                    StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                    SkillId = Guid.Parse("4ff51c1f-90a4-41de-b165-001de306d93e")
                },
                new StudentSkill
                {
                    StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                    SkillId = Guid.Parse("fc5f0c0f-8e12-4c8d-b6d4-f0ad5a0fa61a")
                }
            };

            builder.HasData(studentSkills);
        }
    }
}
