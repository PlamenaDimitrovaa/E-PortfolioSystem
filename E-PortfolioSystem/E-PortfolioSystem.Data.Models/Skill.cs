namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Skill
    {
        public Skill()
        {
            this.Students = new HashSet<Student>();     
        }

        [Key]
        public Guid Id { get; set; }

        public string SkillName { get; set; } = null!;

        public string Level { get; set; } = null!;

        public ICollection<Student> Students { get; set; }
    }
}
