using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSupport_MVP_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSupport.Infrastructure.Configrations
{
    public class ExamConfigrations : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(exam => exam.Id);
            builder.Property(exam => exam.Title).IsRequired().HasMaxLength(150);
        }
    }
}
