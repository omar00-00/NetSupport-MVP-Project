namespace NetSupport_MVP_Project.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAswer1 { get; set; }
        public string WrongAswer2 { get; set; }
        public string WrongAswer3 { get; set; }
        public virtual Exam Exam { get; set; }

    }
}
