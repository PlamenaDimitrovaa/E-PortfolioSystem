namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Skill;
    public class Skill
    {
        public Skill()
        {
            this.Id = Guid.NewGuid();
            this.StudentSkills = new HashSet<StudentSkill>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(SkillNameMaxLength)]
        public string SkillName { get; set; } = null!;

        [Required]
        [MaxLength(LevelMaxLength)]
        public string Level { get; set; } = null!;

        public ICollection<StudentSkill> StudentSkills { get; set; }
    }
}
