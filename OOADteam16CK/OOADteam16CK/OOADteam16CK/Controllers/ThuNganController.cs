using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOADteam16CK.Models;

namespace OOADteam16CK.Controllers
{
    public class ThuNganController : Controller
    {
        private readonly MyDbContext db;

        public ThuNganController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            //List<Ban> bans = new List<Ban>();
            List<HoaDon> hoadons = new List<HoaDon>();
            hoadons = db.HoaDons.Include(x=>x.Ban).Where(p => p.TrangThaiID == 3).ToList();
            //bans = db.Ban.Where(p => p.BanID > 0).ToList();
            return View(hoadons);
        }
        public IActionResult thanhtoan( int ID)
        {

            List<thanhtoanViewModel> listthanhtoan = new List<thanhtoanViewModel>();
            var model = new thanhtoanview();
            HoaDon hd = new HoaDon();
            hd = db.HoaDons.Include(x => x.KhanhHang).Where(p => p.BanID == ID).First();
            model.MaHD = hd.HoaDonID;
           List<ChiTietHd> cts = new List<ChiTietHd>();
            cts = db.ChiTietHds.Include(x => x.MonAn).Where(p => p.HoaDonID == hd.HoaDonID).ToList();
            foreach(var item in cts)
            {
                var thanhtoanview = new thanhtoanViewModel();
                thanhtoanview.BanID = hd.BanID;
                thanhtoanview.KhachHangID = hd.KhanhHang.TenKh;
                thanhtoanview.MonAnId = item.MonAn.TenMon;
                thanhtoanview.DonGia = item.DonGia;
                thanhtoanview.SoLuong = item.SoLuong;
                thanhtoanview.GiamGia = item.GiamGia;
                
                listthanhtoan.Add(thanhtoanview);
            }
            model.ttviewmodel = listthanhtoan;
            double tongtien = 0;
            foreach (var item in cts)
            {
                tongtien += item.ThanhTien;
            }
            ViewBag.TongTien = tongtien;
         

            return View(model);
        }
        public IActionResult thanhtoanxong(int MaHD)
        {
            HoaDon hd = new HoaDon();
            hd = db.HoaDons.Where(p => p.HoaDonID == MaHD).First();
            hd.TrangThaiID = 2;
            db.HoaDons.Update(hd);
            db.SaveChanges();
            return RedirectToAction("Index", "ThuNgan");
        }
        
    }
}