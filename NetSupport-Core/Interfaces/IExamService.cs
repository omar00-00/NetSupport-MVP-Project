using NetSupport.Core.DTOs;
using NetSupport_MVP_Project.Models;

namespace NetSupport.Core.Interfaces
{
    public interface IExamService
    {
        /// <summary>
        /// Create a new exam
        /// </summary>
        Task<int> CreateExamAsync(CreateExamDto createExamDto);

        /// <summary>
        /// Update exam status (start/stop)
        /// </summary>
        Task<bool> UpdateExamStatusAsync(int examId, string status);

        /// <summary>
        /// Bulk add questions to an exam
        /// </summary>
        Task<bool> AddQuestionsAsync(List<Question> questions);

        /// <summary>
        /// Check if student answer is correct and save the result
        /// </summary>
        Task<int> CheckAndSaveAnswerAsync(int studentId, int examId, int questionId, string answer);
        /// <summary>
        /// Get exam questions with shuffled answers for student
        /// </summary>
        Task<IEnumerable<StudentQuestionDto>> GetExamQuestionsAsync(int examId);

        /// <summary>
        /// Generate PDF report for exam results
        /// </summary>
        Task<byte[]> GenerateExamReportPdfAsync(int examId);
    }
}