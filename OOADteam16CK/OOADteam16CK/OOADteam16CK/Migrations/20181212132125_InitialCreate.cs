using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OOADteam16CK.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTietHds",
                columns: table => new
                {
                    ChiTietHdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoaDonID = table.Column<int>(nullable: false),
                    MonAnID = table.Column<int>(nullable: false),
                    DonGia = table.Column<double>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false),
                    GiamGia = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHds", x => x.ChiTietHdID);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KhachHangID = table.Column<int>(nullable: false),
                    BanID = table.Column<int>(nullable: false),
                    ChuThich = table.Column<string>(nullable: true),
                    TrangThaiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.HoaDonID);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    KhachHangID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenKh = table.Column<string>(nullable: true),
                    Diem = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.KhachHangID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiKHs",
                columns: table => new
                {
                    LoaiKHID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoai = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiKHs", x => x.LoaiKHID);
                });

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    LoaiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenLoai = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.LoaiID);
                });

            migrationBuilder.CreateTable(
                name: "MonAns",
                columns: table => new
                {
                    MonAnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoaiID = table.Column<int>(nullable: false),
                    TenMon = table.Column<string>(nullable: true),
                    DonGia = table.Column<double>(nullable: false),
                    Hinh = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    GiamGia = table.Column<double>(nullable: false),
                    TrangThaiID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAns", x => x.MonAnID);
                });

            migrationBuilder.CreateTable(
                name: "TrangThai",
                columns: table => new
                {
                    TrangThaiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrangThai", x => x.TrangThaiID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHds");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "LoaiKHs");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropTable(
                name: "MonAns");

            migrationBuilder.DropTable(
                name: "TrangThai");
        }
    }
}
