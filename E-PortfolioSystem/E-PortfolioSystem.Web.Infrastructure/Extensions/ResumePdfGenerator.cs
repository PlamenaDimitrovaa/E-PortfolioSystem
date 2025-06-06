using E_PortfolioSystem.Web.ViewModels.Certificate;
using E_PortfolioSystem.Web.ViewModels.Profile;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.Net.Http;

namespace E_PortfolioSystem.Web.Infrastructure.Extensions
{
    public class ResumePdfGenerator
    {
        private readonly ResumeViewModel model;
        private readonly ProfileViewModel profile;

        public ResumePdfGenerator(ResumeViewModel model, ProfileViewModel profile)
        {
            this.model = model;
            this.profile = profile;
        }

        private byte[] GetImageOrPlaceholder(string? imageUrl)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(imageUrl))
                {
                    using var httpClient = new HttpClient();
                    return httpClient.GetByteArrayAsync(imageUrl).Result;
                }
            }
            catch
            {
            }

            return Placeholders.Image(200, 200);
        }

        public byte[] Generate()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var imageData = GetImageOrPlaceholder(profile.ImageUrl);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);

                    page.Header().Column(header =>
                    {
                        header.Item().AlignCenter().Text($"CV на {profile.FullName}")
                            .FontSize(22)
                            .Bold()
                            .FontColor(Colors.Blue.Medium);

                        header.Item().PaddingBottom(20);
                    });

                    page.Content().Column(col =>
                    {
                        col.Spacing(20);

                        col.Item().Row(row =>
                        {
                            row.ConstantItem(200).Height(200).Image(imageData, ImageScaling.FitArea);

                            row.RelativeItem().PaddingLeft(20).Column(info => 
                            {
                                info.Spacing(20);
                                info.Item().Text($"Име: {profile.FullName}").FontSize(12).Bold();
                                info.Item().Text($"Телефон: {profile.Phone}").FontSize(11);
                                info.Item().Text($"Локация: {profile.Location}").FontSize(11);
                                info.Item().Text($"Биография: {profile.Bio}")
                                    .FontSize(10)
                                    .Italic()
                                    .FontColor(Colors.Grey.Darken2);
                                col.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten2);
                            });
                        });

                        // ОПИТ
                        col.Item().Text("Опит").Bold().FontSize(14).Underline();
                        if (model.Experiences.Any())
                        {
                            foreach (var exp in model.Experiences)
                            {
                                col.Item().Text($"{exp.StartDate:yyyy} - {(exp.EndDate?.ToString("yyyy") ?? "Сега")} | {exp.Profession} @ {exp.Company}")
                                    .FontSize(11);
                                col.Item().Text(exp.Description).FontSize(10);
                                col.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten2);
                            }
                        }
                        else
                        {
                            col.Item().Text("Няма въведен професионален опит.");
                        }

                        // ОБРАЗОВАНИЕ
                        col.Item().Text("Образование").Bold().FontSize(14).Underline();
                        if (model.Educations.Any())
                        {
                            foreach (var edu in model.Educations)
                            {
                                col.Item().Text($"{edu.StartDate:yyyy} - {edu.EndDate:yyyy} | {edu.Institution} - {edu.Specialty}")
                                    .FontSize(11);
                                col.Item().Text($"Степен: {edu.Degree} | Факултет: {edu.Faculty}")
                                    .FontSize(10)
                                    .Italic();
                                col.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten2);
                            }
                        }
                        else
                        {
                            col.Item().Text("Няма въведени образователни данни.");
                        }

                        // УМЕНИЯ
                        col.Item().Text("Умения").Bold().FontSize(14).Underline();
                        if (model.Skills.Any())
                        {
                            foreach (var skill in model.Skills)
                            {
                                col.Item().Text($"• {skill.Name} - Ниво: {skill.Level}")
                                    .FontSize(10);
                                col.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten2);
                            }
                        }
                        else
                        {
                            col.Item().Text("Няма добавени умения.");
                        }

                        //СЕРТИФИКАТИ
                        col.Item().Text("Сертификати").Bold().FontSize(14).Underline();
                        if (model.Certificates.Any())
                        {
                            foreach (var cert in model.Certificates)
                            {
                                col.Item().Text($"• {cert.Title}")
                                    .FontSize(10);
                                col.Item().Text($"Издаден от: {cert.Issuer}")
                                    .FontSize(10);
                                col.Item().Text($"Издаден на: {cert.IssuedDate?.ToString("dd.MM.yyyy") ?? "Неизвестна"}")
                                    .FontSize(10);
                                col.Item().Text($"Линк към сертификата: {cert.FilePath}")
                                    .FontSize(10);
                                col.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Lighten2);
                            }
                        }
                        else
                        {
                            col.Item().Text("Няма добавени сертификати.");
                        }
                    });

                    // Footer
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Генерирано с E-PortfolioSystem ").FontSize(9).FontColor(Colors.Grey.Medium);
                        x.Span(DateTime.UtcNow.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture))
                         .SemiBold().FontSize(9).FontColor(Colors.Grey.Medium);
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
