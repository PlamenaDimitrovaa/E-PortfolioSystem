namespace E_PortfolioSystem.Data.Configurations
{
    using E_PortfolioSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Profile>(p => p.UserId);

            builder.HasData(this.GenerateProfiles());
        }

        private Profile[] GenerateProfiles()
        {
            return new[]
            {
                new Profile
                {
                    Id = Guid.Parse("e1a1a935-4e1e-421f-bfc3-d97843f34ea1"),
                    UserId = Guid.Parse("a1d7b600-4459-4f80-92d0-1b3e9f3b7234"),
                    FullName = "Иван Петров",
                    Phone = "+359881234561",
                    Bio = "Интересува се от изкуствен интелект",
                    Location = "София, България",
                    ImageUrl = "https://img.freepik.com/free-photo/close-up-smiling-boy-with-sportswear-dawn_23-2147562116.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("f4e8b0d2-d3b9-4a35-89f9-f661ea768112"),
                    UserId = Guid.Parse("b4e0dcf9-b1cb-45a1-93d6-d0dbb130f128"),
                    FullName = "Мария Георгиева",
                    Phone = "+359881234562",
                    Bio = "Уеб програмист, интересува се от разработка на онлайн магазини.",
                    Location = "Пловдив, България",
                    ImageUrl = "https://img.freepik.com/free-photo/pretty-girl-with-nice-smile_23-2147611501.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("8dbdcf2c-d43e-43df-9682-5de5975eeb83"),
                    UserId = Guid.Parse("5c9225c4-f837-4e1e-8f33-b2c13b184951"),
                    FullName = "Николай Стоянов",
                    Phone = "+359881234563",
                    Bio = "UX ентусиаст с любов към дизайна.",
                    Location = "Варна, България",
                    ImageUrl = "https://img.freepik.com/free-photo/portrait-smiling-young-man_1268-21877.jpg",
                    IsPublic = false
                },
                new Profile
                {
                    Id = Guid.Parse("fe419a14-e74e-4c6b-930e-dbd2b514f49a"),
                    UserId = Guid.Parse("ed49c00b-2026-41e0-a97c-9f4f7e74cb79"),
                    FullName = "Елена Димитрова",
                    Phone = "+359881234564",
                    Bio = "Креативна, с интерест към технологии и изкуство.",
                    Location = "Бургас, България",
                    ImageUrl = "https://img.freepik.com/free-psd/close-up-kid-expression-portrait_23-2150193262.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("d4dfb944-f91c-4e94-83ad-41df2a9bb9c7"),
                    UserId = Guid.Parse("7f25fd3e-1719-43a5-8fbe-bad7f62be7a6"),
                    FullName = "Георги Колев",
                    Phone = "+359881234565",
                    Bio = "Интересува се от оптимизация и алгоритми.",
                    Location = "Русе, България",
                    ImageUrl = "https://img.freepik.com/free-photo/front-view-man-posing_23-2148364843.jpg",
                    IsPublic = false
                },
                new Profile
                {
                    Id = Guid.Parse("8f1c86f5-169b-4dc1-9bd3-dbe7b4b3d7e5"),
                    UserId = Guid.Parse("61ba8c0d-1c34-4b68-8881-218f70632a09"),
                    FullName = "Доц. д-р Анна Иванова",
                    Phone = "+359888112201",
                    Bio = "Преподавател по бази данни и SQL оптимизация.",
                    Location = "София, България",
                    ImageUrl = "https://img.freepik.com/free-photo/business-woman-smiling_23-2148152017.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("20ed78c4-2599-4b1a-b70d-ea5ae9c2e4f0"),
                    UserId = Guid.Parse("13c96c70-f547-41f3-91e6-84b38e92e994"),
                    FullName = "Проф. д-р Николай Костов",
                    Phone = "+359888112202",
                    Bio = "Специалист по изкуствен интелект и машинно обучение.",
                    Location = "Пловдив, България",
                    ImageUrl = "https://img.freepik.com/free-photo/portrait-smiling-handsome-man_23-2149022623.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("54b6c9cc-3f49-45fd-b372-e473202f1245"),
                    UserId = Guid.Parse("dcbcf227-4302-4743-8c99-e216bc1a6aef"),
                    FullName = "Гл. ас. Мария Николова",
                    Phone = "+359888112203",
                    Bio = "Интересува се от уеб технологии и преподаване на HTML/CSS.",
                    Location = "Варна, България",
                    ImageUrl = "https://img.freepik.com/free-photo/beautiful-woman-smiling-outdoors_23-2148733309.jpg",
                    IsPublic = false
                },
                new Profile
                {
                    Id = Guid.Parse("933fd617-3243-4c91-b8c3-4a04041be3f9"),
                    UserId = Guid.Parse("94b8a56e-4a0f-4f39-8e83-1ad38c207d30"),
                    FullName = "Доц. д-р Стефан Георгиев",
                    Phone = "+359888112204",
                    Bio = "Преподава компютърни мрежи и сигурност в интернет.",
                    Location = "Русе, България",
                    ImageUrl = "https://img.freepik.com/free-photo/happy-man-holding-tablet_23-2149370873.jpg",
                    IsPublic = true
                },
                new Profile
                {
                    Id = Guid.Parse("d0fa45c9-70ed-4eb2-9725-c8d962cd91a2"),
                    UserId = Guid.Parse("9cb5e4e7-8a6d-4f35-b3a2-973e1ec764f5"),
                    FullName = "Ас. Георги Христов",
                    Phone = "+359888112205",
                    Bio = "Млад преподавател с интереси в областта на Java и C#.",
                    Location = "Благоевград, България",
                    ImageUrl = "https://img.freepik.com/free-photo/portrait-young-man_23-2148401316.jpg",
                    IsPublic = false
                }
            };
        }
    }
}
