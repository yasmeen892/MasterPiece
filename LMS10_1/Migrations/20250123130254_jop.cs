using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS10_1.Migrations
{
    /// <inheritdoc />
    public partial class jop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "AspNetUsers",
                newName: "IsTeacherRequestPending");

            migrationBuilder.AddColumn<bool>(
                name: "IsTeacher",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTeacher",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsTeacherRequestPending",
                table: "AspNetUsers",
                newName: "IsApproved");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
