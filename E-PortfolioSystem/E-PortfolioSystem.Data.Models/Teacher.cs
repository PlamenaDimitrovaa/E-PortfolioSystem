namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Teacher
    {
        public Teacher()
        {
            this.Id = Guid.NewGuid();
            this.Subjects = new HashSet<Subject>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public ICollection<Subject> Subjects { get; set; }
    }
}
