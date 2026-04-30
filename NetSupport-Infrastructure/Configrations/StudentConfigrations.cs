using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSupport_MVP_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetSupport.Infrastructure.Configrations
{
    public class StudentConfigrations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(std => std.Id);
            builder.Property(std => std.Name).IsRequired().HasMaxLength(100);
            builder.Property(std => std.RoomName).IsRequired().HasDefaultValue("eval");
            builder.Property(std => std.Status).HasConversion<string>();
        }
    }
}
