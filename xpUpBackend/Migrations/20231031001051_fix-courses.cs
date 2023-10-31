using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xpUpBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixcourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_Users",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_Courses",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Courses",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Users",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Courses",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Users",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseId",
                table: "Users",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_CourseId",
                table: "Users",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Courses_CourseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CourseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Courses",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Users",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Courses",
                table: "Users",
                column: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Users",
                table: "Courses",
                column: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_Users",
                table: "Courses",
                column: "Users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Courses_Courses",
                table: "Users",
                column: "Courses",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
