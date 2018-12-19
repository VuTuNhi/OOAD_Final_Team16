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
    public class ChiTietHdsController : Controller
    {
        private readonly MyDbContext _context;

        public ChiTietHdsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ChiTietHds
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ChiTietHds.Include(c => c.HoaDon).Include(c => c.MonAn);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ChiTietHds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHds
                .Include(c => c.HoaDon)
                .Include(c => c.MonAn)
                .FirstOrDefaultAsync(m => m.ChiTietHdID == id);
            if (chiTietHd == null)
            {
                return NotFound();
            }

            return View(chiTietHd);
        }

        // GET: ChiTietHds/Create
        public IActionResult Create()
        {
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "HoaDonID", "HoaDonID");
            ViewData["MonAnID"] = new SelectList(_context.MonAns, "MonAnID", "MonAnID");
            return View();
        }

        // POST: ChiTietHds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChiTietHdID,HoaDonID,MonAnID,DonGia,SoLuong,GiamGia")] ChiTietHd chiTietHd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietHd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "HoaDonID", "HoaDonID", chiTietHd.HoaDonID);
            ViewData["MonAnID"] = new SelectList(_context.MonAns, "MonAnID", "MonAnID", chiTietHd.MonAnID);
            return View(chiTietHd);
        }

        // GET: ChiTietHds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHds.FindAsync(id);
            if (chiTietHd == null)
            {
                return NotFound();
            }
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "HoaDonID", "HoaDonID", chiTietHd.HoaDonID);
            ViewData["MonAnID"] = new SelectList(_context.MonAns, "MonAnID", "MonAnID", chiTietHd.MonAnID);
            return View(chiTietHd);
        }

        // POST: ChiTietHds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChiTietHdID,HoaDonID,MonAnID,DonGia,SoLuong,GiamGia")] ChiTietHd chiTietHd)
        {
            if (id != chiTietHd.ChiTietHdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHdExists(chiTietHd.ChiTietHdID))
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
            ViewData["HoaDonID"] = new SelectList(_context.HoaDons, "HoaDonID", "HoaDonID", chiTietHd.HoaDonID);
            ViewData["MonAnID"] = new SelectList(_context.MonAns, "MonAnID", "MonAnID", chiTietHd.MonAnID);
            return View(chiTietHd);
        }

        // GET: ChiTietHds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietHd = await _context.ChiTietHds
                .Include(c => c.HoaDon)
                .Include(c => c.MonAn)
                .FirstOrDefaultAsync(m => m.ChiTietHdID == id);
            if (chiTietHd == null)
            {
                return NotFound();
            }

            return View(chiTietHd);
        }

        // POST: ChiTietHds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietHd = await _context.ChiTietHds.FindAsync(id);
            _context.ChiTietHds.Remove(chiTietHd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHdExists(int id)
        {
            return _context.ChiTietHds.Any(e => e.ChiTietHdID == id);
        }
    }
}
