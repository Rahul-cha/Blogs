using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebsite.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Details",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "UserLoginId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs",
                column: "UserLoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Details",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserLoginId",
                table: "Blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs",
                column: "UserLoginId",
                principalTable: "Logins",
                principalColumn: "Id");
        }
    }
}
