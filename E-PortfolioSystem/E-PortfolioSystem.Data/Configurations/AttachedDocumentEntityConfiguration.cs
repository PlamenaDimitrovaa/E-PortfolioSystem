namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
    public class AttachedDocumentEntityConfiguration : IEntityTypeConfiguration<AttachedDocument>
    {
        public void Configure(EntityTypeBuilder<AttachedDocument> builder)
        {
            builder
                .HasKey(ad => ad.Id);

            builder
                .HasOne(ad => ad.Project)
                .WithOne(p => p.AttachedDocument)
                .HasForeignKey<Project>(p => p.AttachedDocumentId);
        }
    }
}
