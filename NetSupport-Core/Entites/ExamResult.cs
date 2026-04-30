namespace NetSupport_MVP_Project.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        
    }
}
