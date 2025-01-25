using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS10_1.Migrations
{
    /// <inheritdoc />
    public partial class mppp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "TeacherRequestss");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "TeacherRequestss",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
