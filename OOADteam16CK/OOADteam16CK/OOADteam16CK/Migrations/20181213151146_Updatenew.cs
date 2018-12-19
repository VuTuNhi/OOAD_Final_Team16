using Microsoft.EntityFrameworkCore.Migrations;

namespace OOADteam16CK.Migrations
{
    public partial class Updatenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "khachHangs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "khachHangs");
        }
    }
}
