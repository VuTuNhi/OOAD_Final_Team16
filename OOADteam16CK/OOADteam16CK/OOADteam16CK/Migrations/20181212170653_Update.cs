using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OOADteam16CK.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenTrangThai",
                table: "TrangThai",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ban",
                columns: table => new
                {
                    BanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SoBan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ban", x => x.BanID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_LoaiID",
                table: "MonAns",
                column: "LoaiID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_BanID",
                table: "HoaDons",
                column: "BanID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangID",
                table: "HoaDons",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TrangThaiID",
                table: "HoaDons",
                column: "TrangThaiID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_HoaDonID",
                table: "ChiTietHds",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_MonAnID",
                table: "ChiTietHds",
                column: "MonAnID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHds_HoaDons_HoaDonID",
                table: "ChiTietHds",
                column: "HoaDonID",
                principalTable: "HoaDons",
                principalColumn: "HoaDonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHds_MonAns_MonAnID",
                table: "ChiTietHds",
                column: "MonAnID",
                principalTable: "MonAns",
                principalColumn: "MonAnID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_Ban_BanID",
                table: "HoaDons",
                column: "BanID",
                principalTable: "Ban",
                principalColumn: "BanID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_khachHangs_KhachHangID",
                table: "HoaDons",
                column: "KhachHangID",
                principalTable: "khachHangs",
                principalColumn: "KhachHangID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_TrangThai_TrangThaiID",
                table: "HoaDons",
                column: "TrangThaiID",
                principalTable: "TrangThai",
                principalColumn: "TrangThaiID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonAns_Loais_LoaiID",
                table: "MonAns",
                column: "LoaiID",
                principalTable: "Loais",
                principalColumn: "LoaiID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHds_HoaDons_HoaDonID",
                table: "ChiTietHds");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHds_MonAns_MonAnID",
                table: "ChiTietHds");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_Ban_BanID",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_khachHangs_KhachHangID",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_TrangThai_TrangThaiID",
                table: "HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_MonAns_Loais_LoaiID",
                table: "MonAns");

            migrationBuilder.DropTable(
                name: "Ban");

            migrationBuilder.DropIndex(
                name: "IX_MonAns_LoaiID",
                table: "MonAns");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_BanID",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_KhachHangID",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_TrangThaiID",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHds_HoaDonID",
                table: "ChiTietHds");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietHds_MonAnID",
                table: "ChiTietHds");

            migrationBuilder.DropColumn(
                name: "TenTrangThai",
                table: "TrangThai");
        }
    }
}
