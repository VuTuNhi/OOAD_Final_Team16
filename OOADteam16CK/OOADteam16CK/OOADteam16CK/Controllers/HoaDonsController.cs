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
    public class HoaDonsController : Controller
    {
        private readonly MyDbContext _context;

        public HoaDonsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: HoaDons
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.HoaDons.Include(h => h.Ban).Include(h => h.KhanhHang).Include(h => h.TrangThai);
            return View(await myDbContext.ToListAsync());
        }

        // GET: HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.Ban)
                .Include(h => h.KhanhHang)
                .Include(h => h.TrangThai)
                .FirstOrDefaultAsync(m => m.HoaDonID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public IActionResult Create()
        {
            ViewData["BanID"] = new SelectList(_context.Set<Ban>(), "BanID", "BanID");
            ViewData["KhachHangID"] = new SelectList(_context.khachHangs, "KhachHangID", "KhachHangID");
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoaDonID,KhachHangID,BanID,ChuThich,TrangThaiID")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BanID"] = new SelectList(_context.Set<Ban>(), "BanID", "BanID", hoaDon.BanID);
            ViewData["KhachHangID"] = new SelectList(_context.khachHangs, "KhachHangID", "KhachHangID", hoaDon.KhachHangID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID", hoaDon.TrangThaiID);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["BanID"] = new SelectList(_context.Set<Ban>(), "BanID", "BanID", hoaDon.BanID);
            ViewData["KhachHangID"] = new SelectList(_context.khachHangs, "KhachHangID", "KhachHangID", hoaDon.KhachHangID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID", hoaDon.TrangThaiID);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoaDonID,KhachHangID,BanID,ChuThich,TrangThaiID")] HoaDon hoaDon)
        {
            if (id != hoaDon.HoaDonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.HoaDonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BanID"] = new SelectList(_context.Set<Ban>(), "BanID", "BanID", hoaDon.BanID);
            ViewData["KhachHangID"] = new SelectList(_context.khachHangs, "KhachHangID", "KhachHangID", hoaDon.KhachHangID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID", hoaDon.TrangThaiID);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.Ban)
                .Include(h => h.KhanhHang)
                .Include(h => h.TrangThai)
                .FirstOrDefaultAsync(m => m.HoaDonID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.HoaDonID == id);
        }
    }
}
