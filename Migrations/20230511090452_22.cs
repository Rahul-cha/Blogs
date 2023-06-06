using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebsite.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileBio",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicUrl",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileBio",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "ProfilePicUrl",
                table: "Details");
        }
    }
}
