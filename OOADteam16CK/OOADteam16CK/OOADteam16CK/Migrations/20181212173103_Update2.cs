using Microsoft.EntityFrameworkCore.Migrations;

namespace OOADteam16CK.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MonAns_TrangThaiID",
                table: "MonAns",
                column: "TrangThaiID");

            migrationBuilder.AddForeignKey(
                name: "FK_MonAns_TrangThai_TrangThaiID",
                table: "MonAns",
                column: "TrangThaiID",
                principalTable: "TrangThai",
                principalColumn: "TrangThaiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonAns_TrangThai_TrangThaiID",
                table: "MonAns");

            migrationBuilder.DropIndex(
                name: "IX_MonAns_TrangThaiID",
                table: "MonAns");
        }
    }
}
