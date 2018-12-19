using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOADteam16CK.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace OOADteam16CK.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyDbContext db;

        public KhachHangController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
            
    
            
        }
        public async Task<IActionResult>  Montrangmieng()
        {
            List<MonAn> Dsmon = new List<MonAn>();
            Dsmon = db.MonAns.Where(p => p.LoaiID == 3).ToList();
            var model = new KhachHangDatMonViewModel();
            model.Monans = Dsmon.Select(h => new MonAnViewModel
            {
                MaMA = h.MonAnID,
                TenMA = h.TenMon,
                Hinh = h.Hinh,
                DonGia = h.DonGia
            }).ToList();
            List<ChiTietHd> cthds = new List<ChiTietHd>();
            cthds = db.ChiTietHds.Include(x=>x.MonAn).Where(p => p.HoaDonID == HttpContext.Session.Get<int>("hoadonid")).ToList();
            double tongtien=0;
            foreach(var item in cthds)
            {
                tongtien += item.ThanhTien;
            }
            ViewBag.TongTien = tongtien;
            ViewBag.tenmon = new SelectList(db.MonAns, "MonAnID", "TenMon");
            model.chiTietHds = cthds;
            return View(model);
        }
        public IActionResult Monchinh()
        {
            List<MonAn> Dsmon = new List<MonAn>();
            Dsmon = db.MonAns.Where(p => p.LoaiID == 2).ToList();
            var model = new KhachHangDatMonViewModel();
            model.Monans = Dsmon.Select(h => new MonAnViewModel
            {
                MaMA = h.MonAnID,
                TenMA = h.TenMon,
                Hinh = h.Hinh,
                DonGia = h.DonGia
            }).ToList();
            List<ChiTietHd> cthds = new List<ChiTietHd>();
            cthds = db.ChiTietHds.Include(x => x.MonAn).Where(p => p.HoaDonID == HttpContext.Session.Get<int>("hoadonid")).ToList();
            double tongtien = 0;
            foreach (var item in cthds)
            {
                tongtien += item.ThanhTien;
            }
            ViewBag.TongTien = tongtien;
            ViewBag.tenmon = new SelectList(db.MonAns, "MonAnID", "TenMon");
            model.chiTietHds = cthds;
            return View(model);
        }
        public IActionResult Monkhaivi()
        {
            List<MonAn> Dsmon = new List<MonAn>();
            Dsmon = db.MonAns.Where(p => p.LoaiID == 1).ToList();
            var model = new KhachHangDatMonViewModel();
            model.Monans = Dsmon.Select(h => new MonAnViewModel
            {
                MaMA = h.MonAnID,
                TenMA = h.TenMon,
                Hinh = h.Hinh,
                DonGia = h.DonGia
            }).ToList();
            List<ChiTietHd> cthds = new List<ChiTietHd>();
            cthds = db.ChiTietHds.Include(x => x.MonAn).Where(p => p.HoaDonID == HttpContext.Session.Get<int>("hoadonid")).ToList();
            double tongtien = 0;
            foreach (var item in cthds)
            {
                tongtien += item.ThanhTien;
            }
            ViewBag.TongTien = tongtien;
            ViewBag.tenmon = new SelectList(db.MonAns, "MonAnID", "TenMon");
            model.chiTietHds = cthds;
            return View(model);
        }
        public IActionResult Mondactrung()
        {
            List<MonAn> Dsmon = new List<MonAn>();
            Dsmon = db.MonAns.Where(p => p.LoaiID == 4).ToList();
            var model = new KhachHangDatMonViewModel();
            model.Monans = Dsmon.Select(h => new MonAnViewModel
            {
                MaMA = h.MonAnID,
                TenMA = h.TenMon,
                Hinh = h.Hinh,
                DonGia = h.DonGia
            }).ToList();
            List<ChiTietHd> cthds = new List<ChiTietHd>();
            cthds = db.ChiTietHds.Include(x => x.MonAn).Where(p => p.HoaDonID == HttpContext.Session.Get<int>("hoadonid")).ToList();
            double tongtien = 0;
            foreach (var item in cthds)
            {
                tongtien += item.ThanhTien;
            }
            ViewBag.TongTien = tongtien;
            ViewBag.tenmon = new SelectList(db.MonAns, "MonAnID", "TenMon");
            model.chiTietHds = cthds;
            return View(model);
        }
        [HttpPost]
        public  IActionResult mua(int mamon, int soluong)
        {
            MonAn ma = new MonAn();
            ma = db.MonAns.Where(p => p.MonAnID == mamon).First();
            // = new KhachHang();
            // kh = db.khachHangs.Where(p => p.TenKh == HttpContext.Session.Get<KhachHang>("MaKH"));
            
            if (HttpContext.Session.Get<int>("xacnhanmuaxong")!=1)
            {
                HoaDon hd = new HoaDon();
                hd.BanID = 1;
                hd.ChuThich = null;
                 
                hd.KhachHangID = HttpContext.Session.Get<int>("MaKH");
                hd.TrangThaiID = 8;
                
                db.HoaDons.Add(hd);
                db.SaveChanges();
                HttpContext.Session.Set("hoadonid", hd.HoaDonID);
                ChiTietHd cthd = new ChiTietHd();
                
                cthd.HoaDonID = hd.HoaDonID;
               
                cthd.MonAnID = mamon;
                cthd.DonGia = ma.DonGia;
                cthd.SoLuong = soluong;

                cthd.GiamGia = ma.GiamGia;
                
                db.ChiTietHds.Add(cthd);
                db.SaveChanges();
                HttpContext.Session.Set("xacnhanmuaxong", 1);
                if (HttpContext.Session.Get<int>("view") == 4)
                {
                    return RedirectToAction("Montrangmieng", "KhachHang");
                }else if(HttpContext.Session.Get<int>("view") == 3)
                {
                    return RedirectToAction("Monchinh", "KhachHang");
                }
                else if (HttpContext.Session.Get<int>("view") == 2)
                {
                    return RedirectToAction("Monkhaivi", "KhachHang");
                }
                else
                {
                    return RedirectToAction("Mondactrung", "KhachHang");
                }

            }
            else if(HttpContext.Session.Get<int>("xacnhanmuaxong") == 1)
            {
                ChiTietHd cthd = new ChiTietHd();

                cthd.HoaDonID = HttpContext.Session.Get<int>("hoadonid");
                cthd.MonAnID = mamon;
                cthd.DonGia = ma.DonGia;
                cthd.SoLuong = soluong;

                cthd.GiamGia = ma.GiamGia;

                db.ChiTietHds.Add(cthd);
                db.SaveChanges();

                if (HttpContext.Session.Get<int>("view") == 4)
                {
                    return RedirectToAction("Montrangmieng", "KhachHang");
                }
                else if (HttpContext.Session.Get<int>("view") == 3)
                {
                    return RedirectToAction("Monchinh", "KhachHang");
                }
                else if (HttpContext.Session.Get<int>("view") == 2)
                {
                    return RedirectToAction("Monkhaivi", "KhachHang");
                }
                else
                {
                    return RedirectToAction("Mondactrung", "KhachHang");
                }
            }




            return RedirectToAction("Montrangmieng", "KhachHang");
        }
        public IActionResult dangnhap()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult dangnhap(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                KhachHang kh = db.khachHangs.SingleOrDefault(p => p.TenKh == model.MaKH && p.MatKhau == model.MatKhau);
                if (kh == null)
                {
                    ModelState.AddModelError("Loi", "Không có khách hàng này.");
                    return View();
                }
                //ghi session
                //HttpContext.Session.SetString("MaKH", kh.MaKh);
                HttpContext.Session.Set("MaKH", kh.KhachHangID);
                
                //chuyển tới trang HangHoa (--> MyProfile)
                return RedirectToAction("Monchinh", "KhachHang");
            }
            return View();
        }
        public IActionResult xacnhanchonmon()
        {
            HttpContext.Session.Set("cohoadonmoi", 1);
            HoaDon hd = new HoaDon();
            hd = db.HoaDons.Where(p => p.HoaDonID == HttpContext.Session.Get<int>("hoadonid")).First();
            hd.TrangThaiID = 7;
            db.HoaDons.Update(hd);
            db.SaveChanges();
            HttpContext.Session.Set("xacnhanmuaxong", 0);

            if (HttpContext.Session.Get<int>("view") == 4)
            {
                return RedirectToAction("Montrangmieng", "KhachHang");
            }
            else if (HttpContext.Session.Get<int>("view") == 3)
            {
                return RedirectToAction("Monchinh", "KhachHang");
            }
            else if (HttpContext.Session.Get<int>("view") == 2)
            {
                return RedirectToAction("Monkhaivi", "KhachHang");
            }
            else
            {
                return RedirectToAction("Mondactrung", "KhachHang");
            }
        
        }
        public IActionResult laydshd(int keyword=1)
        {
            if (keyword == 1)
            {
                HttpContext.Session.Set("cohoadonmoi", 0);
                List<HoaDon> hds = new List<HoaDon>();
                hds = db.HoaDons.Where(p => p.TrangThaiID == 7).ToList();
                return PartialView(hds);
            }
            else
            {
                return RedirectToAction("Index", "NhaBep");
            }
            
        }
       
    }
}