using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS10_1.Migrations
{
    /// <inheritdoc />
    public partial class newskkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_ApplicationUserId",
                table: "TeacherRequestss");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss");

            migrationBuilder.DropIndex(
                name: "IX_TeacherRequestss_ApplicationUserId",
                table: "TeacherRequestss");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TeacherRequestss");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TeacherRequestss",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherRequestss_ApplicationUserId",
                table: "TeacherRequestss",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_ApplicationUserId",
                table: "TeacherRequestss",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherRequestss_AspNetUsers_UserId",
                table: "TeacherRequestss",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
