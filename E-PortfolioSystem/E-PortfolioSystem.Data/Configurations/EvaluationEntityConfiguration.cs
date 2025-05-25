namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
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
        }
    }
}
