using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSupport_MVP_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSupport.Infrastructure.Configrations
{
    public class ExamResultConfigrations : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.HasKey(ER => ER.Id);
            builder.HasOne(ER => ER.Student).WithMany(std => std.ExamResults).HasForeignKey(ER => ER.StudentId);
            builder.HasOne(ER => ER.Exam).WithMany(exam => exam.ExamResults).HasForeignKey(ER => ER.ExamId);
        }
    }
}
