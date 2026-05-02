using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class StokHareketlerisController : Controller
    {
        private readonly AppDbContext _context;

        public StokHareketlerisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StokHareketleris
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.StokHareketleris.Include(s => s.Urunler);
            return View(await appDbContext.ToListAsync());
        }

        // GET: StokHareketleris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stokHareketleri = await _context.StokHareketleris
                .Include(s => s.Urunler)
                .FirstOrDefaultAsync(m => m.Hareket_Id == id);
            if (stokHareketleri == null)
            {
                return NotFound();
            }

            return View(stokHareketleri);
        }

        // GET: StokHareketleris/Create
        public IActionResult Create()
        {
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id");
            return View();
        }

        // POST: StokHareketleris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hareket_Id,Urun_Id,Hareket_Turu,Miktari,Tarih,Aciklama")] StokHareketleri stokHareketleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stokHareketleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", stokHareketleri.Urun_Id);
            return View(stokHareketleri);
        }

        // GET: StokHareketleris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stokHareketleri = await _context.StokHareketleris.FindAsync(id);
            if (stokHareketleri == null)
            {
                return NotFound();
            }
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", stokHareketleri.Urun_Id);
            return View(stokHareketleri);
        }

        // POST: StokHareketleris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hareket_Id,Urun_Id,Hareket_Turu,Miktari,Tarih,Aciklama")] StokHareketleri stokHareketleri)
        {
            if (id != stokHareketleri.Hareket_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stokHareketleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StokHareketleriExists(stokHareketleri.Hareket_Id))
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
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", stokHareketleri.Urun_Id);
            return View(stokHareketleri);
        }

        // GET: StokHareketleris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stokHareketleri = await _context.StokHareketleris
                .Include(s => s.Urunler)
                .FirstOrDefaultAsync(m => m.Hareket_Id == id);
            if (stokHareketleri == null)
            {
                return NotFound();
            }

            return View(stokHareketleri);
        }

        // POST: StokHareketleris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stokHareketleri = await _context.StokHareketleris.FindAsync(id);
            if (stokHareketleri != null)
            {
                _context.StokHareketleris.Remove(stokHareketleri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StokHareketleriExists(int id)
        {
            return _context.StokHareketleris.Any(e => e.Hareket_Id == id);
        }
    }
}
