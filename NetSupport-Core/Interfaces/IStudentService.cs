using NetSupport.Core.DTOs;

namespace NetSupport.Core.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDisplayDto> LoginStudentAsync(StudentLoginDto studentLoginDto);
        Task<IEnumerable<StudentDisplayDto>> GetStudentsInRoomAsync(string roomName);
        Task<bool> UpdateStudentStatusAsync(UpdateStudentStatusDto updateStudentStatusDto);

        /// <summary>
        /// Sets a student's status to Offline when their SignalR connection drops.
        /// Called by ClassroomHub.OnDisconnectedAsync.
        /// </summary>
        Task SetStudentOfflineAsync(int studentId);
    }
}