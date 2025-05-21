namespace E_PortfolioSystem.Data.Models
{
    public class StudentSkill
    {
        public Guid StudentId { get; set; }

        public Guid SkillId { get; set; }

        public Student Student { get; set; } = null!;

        public Skill Skill { get; set; } = null!;
    }
}
