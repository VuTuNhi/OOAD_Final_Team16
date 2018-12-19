using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOADteam16CK.Models;

namespace OOADteam16CK.Controllers
{
    public class NhaBepController : Controller
    {
        private readonly MyDbContext db;

        public NhaBepController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            List<bans> BANSS = new List<bans>();
            
            List<HoaDon> hds = new List<HoaDon>();
        
            hds = db.HoaDons.Include(x => x.KhanhHang).Where(p => p.TrangThaiID == 7).ToList();
            List<ChiTietHd> cts = new List<ChiTietHd>();
            foreach(var item in hds)
            {
                bans bans = new bans();
                List<mon> listmonss = new List<mon>();
                
                List<ChiTietHd> ct = new List<ChiTietHd>();
                ct = db.ChiTietHds.Include(x => x.MonAn).Where(p => p.HoaDonID == item.HoaDonID).ToList();
                foreach(var tmp in ct)
                {
                    mon mon = new mon();
                    mon.BanID = item.BanID;
                    mon.KhachHangID = item.KhanhHang.TenKh;
                    mon.MonAnId = tmp.MonAn.TenMon;
                    mon.soluong = tmp.SoLuong;
                    listmonss.Add(mon);
                }
                bans.listmons = listmonss;
                bans.MaHD = item.HoaDonID;
                BANSS.Add(bans);
            }
            ViewData["KhachHangID"] = new SelectList(db.khachHangs, "KhachHangID", "TenKh");
            ViewData["MonAnID"] = new SelectList(db.MonAns, "MonAnID", "TenMon");
            return View(BANSS);
        }
        public IActionResult daxong(int MaHD)
        {
            HoaDon hd = new HoaDon();
            hd = db.HoaDons.Where(p => p.HoaDonID == MaHD).First();
            hd.TrangThaiID = 3;
            db.HoaDons.Update(hd);
            db.SaveChanges();
            return RedirectToAction("Index", "NhaBep");
        }
    }
}