using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSupport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDurationFromIntToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DurationInMinutes",
                table: "Exams",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DurationInMinutes",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
