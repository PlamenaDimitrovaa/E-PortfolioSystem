namespace E_PortfolioSystem.Data.Models
{
    public class StudentSubject
    {
        public Guid UserId { get; set; }

        public Guid SubjectId { get; set; }

        public Student Student { get; set; } = null!;

        public Subject Subject { get; set; } = null!;
    }
}
