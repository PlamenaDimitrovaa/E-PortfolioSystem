using E_PortfolioSystem.Data;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using E_PortfolioSystem.Web.ViewModels.AttachedDocument;
using E_PortfolioSystem.Web.ViewModels.Certificate;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly EPortfolioDbContext dbContext;

        public CertificateService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<CertificateViewModel>> GetAllByUserIdAsync(string? id)
        {
            return await dbContext.Certificates
              .Include(x => x.Student)
              .Where(x => x.Student.UserId.ToString() == id)
              .Select(e => new CertificateViewModel
              {
                  Id = e.Id.ToString(),
                  Title = e.Title,
                  Issuer = e.Issuer,
                  IssuedDate = e.IssuedDate,
                  FilePath = e.FilePath,
                  AttachedDocumentId = e.AttachedDocumentId.ToString()
              })
              .ToListAsync();
        }

        public async Task<CertificateDetailsViewModel?> GetByIdAsync(string id)
        {
            var bgCulture = new CultureInfo("bg-BG");

            return await dbContext.Certificates
                 .Where(s => s.Id.ToString() == id)
                 .Select(s => new CertificateDetailsViewModel
                 {
                     Id = s.Id.ToString(),
                     Title = s.Title,
                     Issuer = s.Issuer,
                     IssuedDate = s.IssuedDate,
                     FilePath = s.FilePath,
                     AttachedDocumentId = s.AttachedDocumentId.ToString()
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<CertificateEditViewModel> GetCertificateForEditAsync(Guid id)
        {
            var cert = await dbContext.Certificates
                .Include(c => c.AttachedDocument)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cert == null)
            {
                throw new InvalidOperationException("Сертификатът не е намерен.");
            }

            return new CertificateEditViewModel
            {
                Id = cert.Id.ToString(),
                Title = cert.Title,
                Issuer = cert.Issuer,
                IssuedDate = cert.IssuedDate,
                DocumentDescription = cert.AttachedDocument?.Description,
                DocumentType = cert.AttachedDocument?.DocumentType,
                AttachedDocument = cert.AttachedDocument == null ? null : new AttachedDocumentFormModel
                {
                    Id = cert.AttachedDocumentId.ToString() ?? "",
                    FileName = cert.AttachedDocument.FileName,
                    FileLocation = cert.AttachedDocument.FileLocation,
                    DocumentType = cert.AttachedDocument.DocumentType,
                    Description = cert.AttachedDocument.Description,
                    UploadDate = cert.AttachedDocument.UploadDate
                }
            };
        }

        public async Task SaveCertificateAsync(CertificateEditViewModel model, string? studentId)
        {
            var certificate = new Certificate
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Issuer = model.Issuer,
                IssuedDate = model.IssuedDate,
                StudentId = Guid.Parse(studentId!),
                FilePath = model.FilePath
            };

            if (model.File != null && model.File.Length > 0)
            {
                var uploadPath = Path.Combine("wwwroot", "Uploaded", "Files");
                Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, model.File.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                var fileBytes = await File.ReadAllBytesAsync(filePath);
                var base64Content = Convert.ToBase64String(fileBytes);

                var document = new AttachedDocument
                {
                    Id = Guid.NewGuid(),
                    FileName = model.File.FileName,
                    FileContent = "File Content",
                    UploadDate = DateTime.UtcNow,
                    FileLocation = $"Uploads/Files/{model.File.FileName}",
                    DocumentType = model.DocumentType ?? "Сертификат",
                    Description = model.DocumentDescription
                };

                certificate.AttachedDocumentId = document.Id;
                certificate.AttachedDocument = document;

                dbContext.AttachedDocuments.Add(document);
            }

            dbContext.Certificates.Add(certificate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateCertificateAsync(CertificateEditViewModel model)
        {
            var certId = Guid.Parse(model.Id!);

            var cert = await dbContext.Certificates
                .Include(c => c.AttachedDocument)
                .FirstOrDefaultAsync(c => c.Id == certId);

            if (cert == null)
            {
                throw new InvalidOperationException("Сертификатът не е намерен.");
            }

            cert.Title = model.Title;
            cert.Issuer = model.Issuer;
            cert.IssuedDate = model.IssuedDate;

            if (model.File != null && model.File.Length > 0)
            {
                var uploadPath = Path.Combine("wwwroot", "Uploaded", "Files");
                Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, model.File.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }

                var document = new AttachedDocument
                {
                    Id = Guid.NewGuid(),
                    FileName = model.File.FileName,
                    FileContent = "File Content",
                    UploadDate = DateTime.UtcNow,
                    FileLocation = $"Uploaded/Files/{model.File.FileName}",
                    DocumentType = model.DocumentType ?? "Сертификат",
                    Description = model.DocumentDescription
                };

                // Проверка дали старият AttachedDocument се използва другаде
                if (cert.AttachedDocumentId != null)
                {
                    var currentDocId = cert.AttachedDocumentId;

                    var isUsedInProjects = await dbContext.Projects
                        .AnyAsync(p => p.AttachedDocumentId == currentDocId && p.Id != cert.Id);

                    var isUsedInCertificates = await dbContext.Certificates
                        .AnyAsync(c => c.AttachedDocumentId == currentDocId && c.Id != cert.Id);

                    if (!isUsedInProjects && !isUsedInCertificates)
                    {
                        var oldDoc = await dbContext.AttachedDocuments.FindAsync(currentDocId);
                        if (oldDoc != null)
                        {
                            dbContext.AttachedDocuments.Remove(oldDoc);
                        }
                    }
                }

                cert.AttachedDocumentId = document.Id;
                cert.AttachedDocument = document;

                dbContext.AttachedDocuments.Add(document);
            }
            else if (cert.AttachedDocument != null)
            {
                cert.AttachedDocument.Description = model.DocumentDescription;
                cert.AttachedDocument.DocumentType = model.DocumentType ?? "Сертификат";
            }

            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteCertificateAsync(Guid id)
        {
            var cert = await dbContext.Certificates
                .Include(c => c.AttachedDocument)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cert == null)
            {
                throw new InvalidOperationException("Сертификатът не е намерен.");
            }

            if (cert.AttachedDocument != null)
            {
                var filePath = Path.Combine("wwwroot", cert.AttachedDocument.FileLocation.Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                dbContext.AttachedDocuments.Remove(cert.AttachedDocument);
            }

            dbContext.Certificates.Remove(cert);
            await dbContext.SaveChangesAsync();
        }


    }
}
