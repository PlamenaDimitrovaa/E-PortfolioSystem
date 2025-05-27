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

            builder.HasData(this.GenerateCertificates());
        }

        private Certificate[] GenerateCertificates()
        {
            ICollection<Certificate> certificates = new HashSet<Certificate>();

            Certificate certificate;

            certificate = new Certificate()
            {
                Id = Guid.Parse("a0d6d83d-54b7-4fd9-bbe2-d46014a148af"),
                StudentId = Guid.Parse("5cfa1d36-7ae6-4c95-b3a4-e5a96b14b591"),
                Title = "Основи на C#",
                Issuer = "Microsoft",
                FilePath = "https://img.freepik.com/free-psd/elegant-certificate-template-with-golden-details_69286-460.jpg",
                AttachedDocumentId = Guid.Parse("60E7E4D1-7D77-4D3D-9792-BD02DCAD8EF1"),
                IssuedDate = new DateTime(2023, 6, 10, 0, 0, 0, DateTimeKind.Utc)
            };

            certificates.Add(certificate);

            certificate = new Certificate()
            {
                Id = Guid.Parse("19a5d055-1714-456a-aee7-e1fd195aeb2d"),
                StudentId = Guid.Parse("7f3cd066-6f98-43e2-bff1-17972e62f202"),
                Title = "ASP.NET Core Уеб програмиране",
                Issuer = "Udemy",
                FilePath = "https://img.freepik.com/free-psd/sign-that-says-certificate-approval-approval-it_69286-538.jpg",
                AttachedDocumentId = Guid.Parse("9DF4D32B-76D2-4C7F-8E42-EC4F7BAF34CB"),
                IssuedDate = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
            };

            certificates.Add(certificate);

            certificate = new Certificate()
            {
                Id = Guid.Parse("d2077f92-22dc-4065-a318-7cb9a3ec59e0"),
                StudentId = Guid.Parse("cb3c4c29-7a2b-4c98-91de-57b28f35b920"),
                Title = "JavaScript напреднал",
                Issuer = "freeCodeCamp",
                FilePath = "https://img.freepik.com/free-vector/geometric-minimalist-business-certificates_23-2148896559.jpg",
                AttachedDocumentId = Guid.Parse("F3F2163A-24CB-43D0-A3E5-C0C34C18CC2C"),
                IssuedDate = new DateTime(2022, 11, 20, 0, 0, 0, DateTimeKind.Utc)
            };

            certificates.Add(certificate);

            certificate = new Certificate()
            {
                Id = Guid.Parse("2cf9b2e4-b22f-4639-9d6b-631d97a37d3f"),
                StudentId = Guid.Parse("b61b3a88-78d9-4044-a166-2b8754ec255e"),
                Title = "Системи базиданни",
                Issuer = "Oracle",
                FilePath = "https://img.freepik.com/free-vector/abstract-colorful-design-certificates_23-2148886971.jpg",
                AttachedDocumentId = Guid.Parse("D42E5CF4-E694-42E8-B388-34E529F383AB"),
                IssuedDate = new DateTime(2023, 9, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            certificates.Add(certificate);

            certificate = new Certificate()
            {
                Id = Guid.Parse("e9578f87-d5b2-4c0a-b676-1ff7e7cdba3d"),
                StudentId = Guid.Parse("edb4d7d9-014b-4b2d-8124-6a5cd45f0b67"),
                Title = "Основи на Machine Learning",
                Issuer = "Coursera",
                FilePath = "https://img.freepik.com/premium-vector/certificate_733271-100.jpg",
                AttachedDocumentId = Guid.Parse("BEBF91E9-90AA-4B65-B0FF-1FA91F4C83E4"),
                IssuedDate = new DateTime(2024, 3, 18, 0, 0, 0, DateTimeKind.Utc)
            };

            certificates.Add(certificate);

            return certificates.ToArray();
        }
    }
}
