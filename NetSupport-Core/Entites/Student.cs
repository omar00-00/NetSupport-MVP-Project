using NetSupport.Core.Entites;

namespace NetSupport_MVP_Project.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; } = new HashSet<ExamResult>();

    }
}
