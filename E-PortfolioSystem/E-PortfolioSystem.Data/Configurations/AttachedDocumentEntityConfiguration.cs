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

            builder.HasData(this.GenerateAttachedDocuments());
        }

        private AttachedDocument[] GenerateAttachedDocuments()
        {
            return new[]
       {
                new AttachedDocument
                {
                    Id = Guid.Parse("60e7e4d1-7d77-4d3d-9792-bd02dcad8ef1"),
                    DocumentType = "PDF",
                    FileName = "Certificate_Student1.pdf",
                    Description = "Сертификат за Основи на C#",
                    FileContent = "base64stringcontent1",
                    UploadDate = new DateTime(2023, 3, 1, 0, 0, 0, DateTimeKind.Utc),
                    FileLocation = "/files/student1/certificate1.pdf",
                    ProjectId = null
                },
                new AttachedDocument
                {
                    Id = Guid.Parse("f3f2163a-24cb-43d0-a3e5-c0c34c18cc2c"),
                    DocumentType = "DOCX",
                    FileName = "Certificate_Student2.docx",
                    Description = "Сертификат за Java Advanced",
                    FileContent = "base64stringcontent2",
                    UploadDate = new DateTime(2023, 6, 15, 0, 0, 0, DateTimeKind.Utc),
                    FileLocation = "/files/student2/certificate2.docx",
                    ProjectId = null
                },
                new AttachedDocument
                {
                    Id = Guid.Parse("9df4d32b-76d2-4c7f-8e42-ec4f7baf34cb"),
                    DocumentType = "PDF",
                    FileName = "Certificate_Student3.pdf",
                    Description = "Сертификат за уеб програмиране",
                    FileContent = "base64stringcontent3",
                    UploadDate = new DateTime(2023, 9, 10, 0, 0, 0, DateTimeKind.Utc),
                    FileLocation = "/files/student3/certificate3.pdf",
                    ProjectId = null
                },
                new AttachedDocument
                {
                    Id = Guid.Parse("bebf91e9-90aa-4b65-b0ff-1fa91f4c83e4"),
                    DocumentType = "PDF",
                    FileName = "Certificate_Student4.pdf",
                    Description = "Сертификат за Python",
                    FileContent = "base64stringcontent4",
                    UploadDate = new DateTime(2023, 12, 5, 0, 0, 0, DateTimeKind.Utc),
                    FileLocation = "/files/student4/certificate4.pdf",
                    ProjectId = null
                },
                new AttachedDocument
                {
                    Id = Guid.Parse("d42e5cf4-e694-42e8-b388-34e529f383ab"),
                    DocumentType = "PDF",
                    FileName = "Certificate_Student5.pdf",
                    Description = "Сертификат за SQL",
                    FileContent = "base64stringcontent5",
                    UploadDate = new DateTime(2024, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                    FileLocation = "/files/student5/certificate5.pdf",
                    ProjectId = null
                }
            };
        }
    }
}
