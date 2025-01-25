using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS10_1.Migrations
{
    /// <inheritdoc />
    public partial class npopo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TeacherRequestss",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TeacherRequestss",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
