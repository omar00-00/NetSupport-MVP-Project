namespace NetSupport.Core.DTOs
{
    public class StudentQuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> Answers { get; set; } = new();
    }
}