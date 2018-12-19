using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OOADteam16CK.Models;

namespace OOADteam16CK.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<ChiTietHd> ChiTietHds { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> khachHangs { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<LoaiKH> LoaiKHs { get; set; }
        public DbSet<MonAn> MonAns { get; set; }
        public DbSet<TrangThai> TrangThai { get; set; }
                                                                                                                            

        public MyDbContext(DbContextOptions options) : base(options)
        { }
                                                                                                                            

        public DbSet<OOADteam16CK.Models.Ban> Ban { get; set; }
    }
}
