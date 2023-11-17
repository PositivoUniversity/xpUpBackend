using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xpUpBackend.Migrations
{
    /// <inheritdoc />
    public partial class userPost_events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPost",
                table: "Events",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPost",
                table: "Events");
        }
    }
}
