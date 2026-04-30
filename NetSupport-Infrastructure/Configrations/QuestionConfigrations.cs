using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSupport_MVP_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSupport.Infrastructure.Configrations
{
    internal class QuestionConfigrations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(quest => quest.Id);
            builder.Property(quest => quest.Text).IsRequired();
            builder.Property(quest => quest.CorrectAnswer).IsRequired();
            builder.Property(quest => quest.WrongAswer1).IsRequired();
            builder.Property(quest => quest.WrongAswer2).IsRequired();
            builder.Property(quest => quest.WrongAswer3).IsRequired();
            builder.HasOne(quest => quest.Exam).WithMany(exam => exam.Questions).HasForeignKey(quest => quest.ExamId);
        }
    }
}
