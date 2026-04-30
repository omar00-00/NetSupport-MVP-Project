using Microsoft.EntityFrameworkCore;
using NetSupport.Core.DTOs;
using NetSupport.Core.Entites;
using NetSupport.Core.Interfaces;
using NetSupport.Infrastructure.Data;
using NetSupport_MVP_Project.Models;

namespace NetSupport.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly NetSupportDBContext _context;

        public StudentService(NetSupportDBContext context)
        {
            _context = context;
        }

        public async Task<StudentDisplayDto> LoginStudentAsync(StudentLoginDto studentLoginDto)
        {
            if (studentLoginDto == null)
                throw new ArgumentNullException(nameof(studentLoginDto), "Student login DTO cannot be null");

            if (string.IsNullOrWhiteSpace(studentLoginDto.Name))
                throw new ArgumentException("Student name cannot be null or empty", nameof(studentLoginDto.Name));

            var existingStudent = await _context.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Name.ToLower() == studentLoginDto.Name.ToLower());

            if (existingStudent != null)
            {
                throw new InvalidOperationException("NameAlreadyExists");
            }

            var newStudent = new Student
            {
                Name = studentLoginDto.Name,
                Status = Status.Ready
            };

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();

            return new StudentDisplayDto
            {
                Id = newStudent.Id,
                Name = newStudent.Name,
                Status = newStudent.Status
            };
        }

        public async Task<IEnumerable<StudentDisplayDto>> GetStudentsInRoomAsync(string roomName)
        {
            if (string.IsNullOrWhiteSpace(roomName))
                throw new ArgumentException("Room name cannot be null or empty", nameof(roomName));

            var students = await _context.Students
                .Where(s => s.RoomName == roomName && s.Status != Status.Offline)
                .AsNoTracking()
                .Select(s => new StudentDisplayDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Status = s.Status
                })
                .ToListAsync();

            return students;
        }

        public async Task<bool> UpdateStudentStatusAsync(UpdateStudentStatusDto updateStudentStatusDto)
        {
            if (updateStudentStatusDto == null)
                throw new ArgumentNullException(nameof(updateStudentStatusDto), "Update student status DTO cannot be null");

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == updateStudentStatusDto.StudentId);

            if (student == null)
                return false;

            student.Status = updateStudentStatusDto.NewStatus;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// FIX #4: New method called by ClassroomHub.OnDisconnectedAsync to persist
        /// the Offline status when a student's SignalR connection drops. Without this,
        /// the student would remain visible as "Ready" in the tutor's dashboard indefinitely
        /// after a browser close or network drop.
        /// </summary>
        public async Task SetStudentOfflineAsync(int studentId)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
                return;

            student.Status = Status.Offline;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}