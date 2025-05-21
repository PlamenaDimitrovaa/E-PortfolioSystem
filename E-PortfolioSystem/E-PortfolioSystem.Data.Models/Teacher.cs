namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }

        [Key]
        public Guid Id { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
