namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Profession)
                .IsRequired();

            builder
                .Property(e => e.Company)
                .IsRequired();

            builder
                .Property(e => e.StartDate)
                .IsRequired();

            builder
                .HasOne(e => e.Student)
                .WithMany(p => p.Experiences)
                .HasForeignKey(e => e.StudentId);
        }
    }
}
