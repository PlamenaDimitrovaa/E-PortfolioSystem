namespace E_PortfolioSystem.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using E_PortfolioSystem.Data.Models;
    using System.Reflection;

    public class EPortfolioDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public EPortfolioDbContext(DbContextOptions<EPortfolioDbContext> options)
            : base(options)
        {
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<HRContact> HRContacts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<AttachedDocument> AttachedDocuments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSkill> StudentsSkills { get; set; }
        public DbSet<StudentSubject> StudentsSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly configAssembly = Assembly.GetAssembly(typeof(EPortfolioDbContext))
                                    ?? Assembly.GetExecutingAssembly();

            modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);

            //modelBuilder.Entity<Chat>()
            //    .HasOne(c => c.Sender)
            //    .WithMany()
            //    .HasForeignKey(c => c.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Chat>()
            //    .HasOne(c => c.Receiver)
            //    .WithMany()
            //    .HasForeignKey(c => c.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Email>()
            //    .HasOne(e => e.FromUser)
            //    .WithMany()
            //    .HasForeignKey(e => e.FromUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Email>()
            //    .HasOne(e => e.ToUser)
            //    .WithMany()
            //    .HasForeignKey(e => e.ToUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<HRContact>()
            //    .HasOne(h => h.HRUser)
            //    .WithMany()
            //    .HasForeignKey(h => h.HRUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<HRContact>()
            //    .HasOne(h => h.StudentUser)
            //    .WithMany()
            //    .HasForeignKey(h => h.StudentUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Recommendation>()
            //    .HasOne(r => r.FromUser)
            //    .WithMany()
            //    .HasForeignKey(r => r.FromUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Recommendation>()
            //    .HasOne(r => r.ToUser)
            //    .WithMany()
            //    .HasForeignKey(r => r.ToUserId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
