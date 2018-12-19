using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOADteam16CK.Models;

namespace OOADteam16CK.Controllers
{
    public class MonAnsController : Controller
    {
        private readonly MyDbContext _context;

        public MonAnsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: MonAns
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.MonAns.Include(m => m.Loai).Include(m => m.TrangThai);
            return View(await myDbContext.ToListAsync());
        }

        // GET: MonAns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns
                .Include(m => m.Loai)
                .Include(m => m.TrangThai)
                .FirstOrDefaultAsync(m => m.MonAnID == id);
            if (monAn == null)
            {
                return NotFound();
            }
            string[] arrListStr = monAn.Hinh.Split(';');
            ViewBag.arr = arrListStr;
            return View(monAn);
        }

        // GET: MonAns/Create
        public IActionResult Create()
        {
            ViewData["LoaiID"] = new SelectList(_context.Loais, "LoaiID", "TenLoai");
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TenTrangThai");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonAnID,LoaiID,TenMon,DonGia,Hinh,MoTa,GiamGia,TrangThaiID")] MonAn monAn, IFormFile[] myfile)
        {
            if (ModelState.IsValid)
            {
                string arr = "";

                if (myfile != null)
                {
                    foreach (var item in myfile)
                    {
                        string url = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", item.FileName);
                        using (var f = new FileStream(url, FileMode.Create))
                        {
                            item.CopyTo(f);
                        }
                        arr += item.FileName ;
                    }
                    monAn.Hinh = arr;
                }
                _context.Add(monAn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiID"] = new SelectList(_context.Loais, "LoaiID", "LoaiID", monAn.LoaiID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID", monAn.TrangThaiID);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            ViewData["LoaiID"] = new SelectList(_context.Loais, "LoaiID", "TenLoai", monAn.LoaiID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai,  "TrangThaiID", "TenTrangThai", monAn.TrangThaiID);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonAnID,LoaiID,TenMon,DonGia,Hinh,MoTa,GiamGia,TrangThaiID")] MonAn monAn)
        {
            if (id != monAn.MonAnID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonAnExists(monAn.MonAnID))
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
            ViewData["LoaiID"] = new SelectList(_context.Loais, "LoaiID", "LoaiID", monAn.LoaiID);
            ViewData["TrangThaiID"] = new SelectList(_context.TrangThai, "TrangThaiID", "TrangThaiID", monAn.TrangThaiID);
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await _context.MonAns
                .Include(m => m.Loai)
                .Include(m => m.TrangThai)
                .FirstOrDefaultAsync(m => m.MonAnID == id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monAn = await _context.MonAns.FindAsync(id);
            _context.MonAns.Remove(monAn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonAnExists(int id)
        {
            return _context.MonAns.Any(e => e.MonAnID == id);
        }
    }
}
