namespace E_PortfolioSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using E_PortfolioSystem.Data.Models;
    public class HRContactEntityConfiguration : IEntityTypeConfiguration<HRContact>
    {
        public void Configure(EntityTypeBuilder<HRContact> builder)
        {
            builder
                .HasKey(h => h.Id);

            builder
                .HasOne(h => h.HRUser)
                .WithMany()
                .HasForeignKey(h => h.HRUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.StudentUser)
                .WithMany()
                .HasForeignKey(h => h.StudentUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
