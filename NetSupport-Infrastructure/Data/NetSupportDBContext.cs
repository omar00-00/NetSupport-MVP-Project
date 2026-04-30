using Microsoft.EntityFrameworkCore;
using NetSupport.Infrastructure.Configrations;
using NetSupport_MVP_Project.Models;

namespace NetSupport.Infrastructure.Data
{
    public class NetSupportDBContext : DbContext
    {
        public NetSupportDBContext(DbContextOptions<NetSupportDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionConfigrations());
            modelBuilder.ApplyConfiguration(new StudentConfigrations());
            modelBuilder.ApplyConfiguration(new ExamResultConfigrations());
            modelBuilder.ApplyConfiguration(new ExamConfigrations());
        }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamResult> ExamResults { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
