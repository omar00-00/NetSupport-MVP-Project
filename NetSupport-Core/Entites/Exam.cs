using System.ComponentModel.DataAnnotations;

namespace NetSupport_MVP_Project.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Range(1,300)]
        public double DurationInMinutes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public virtual ICollection<ExamResult> ExamResults { get; set; } = new HashSet<ExamResult>();

    }
}
