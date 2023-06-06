using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebsite.Migrations
{
    public partial class testone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Details_LoginId",
                table: "Details");

            migrationBuilder.RenameColumn(
                name: "PicUrl",
                table: "Details",
                newName: "Gender");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserLoginId",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_LoginId",
                table: "Details",
                column: "LoginId",
                unique: true,
                filter: "[LoginId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserLoginId",
                table: "Blogs",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs",
                column: "UserLoginId",
                principalTable: "Logins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Logins_UserLoginId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Details_LoginId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserLoginId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "UserLoginId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Details",
                newName: "PicUrl");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Details_LoginId",
                table: "Details",
                column: "LoginId");
        }
    }
}
