using NetSupport.Core.Entites;

namespace NetSupport.Core.DTOs
{
    public class UpdateStudentStatusDto
    {
        public int StudentId { get; set; }
        public Status NewStatus { get; set; }
    }
}
