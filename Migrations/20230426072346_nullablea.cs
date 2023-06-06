using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebsite.Migrations
{
    public partial class nullablea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Blogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
