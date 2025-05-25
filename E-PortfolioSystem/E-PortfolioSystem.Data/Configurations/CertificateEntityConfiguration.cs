namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;

    public class CertificateEntityConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Student)
                .WithMany(c => c.Certificates)
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.AttachedDocument)
                .WithMany()
                .HasForeignKey(c => c.AttachedDocumentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
