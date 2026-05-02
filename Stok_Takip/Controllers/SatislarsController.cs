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
    public class SatislarsController : Controller
    {
        private readonly AppDbContext _context;

        public SatislarsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Satislars
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SatisSatislar.Include(s => s.Musteriler);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Satislars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satislar = await _context.SatisSatislar
                .Include(s => s.Musteriler)
                .FirstOrDefaultAsync(m => m.Satislar_Id == id);
            if (satislar == null)
            {
                return NotFound();
            }

            return View(satislar);
        }

        // GET: Satislars/Create
        public IActionResult Create()
        {
            ViewData["Musteri_Id"] = new SelectList(_context.Musterilers, "Musteri_Id", "Musteri_Id");
            return View();
        }

        // POST: Satislars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Satislar_Id,Musteri_Id,Tarih,Toplam_Tutar")] Satislar satislar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(satislar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Musteri_Id"] = new SelectList(_context.Musterilers, "Musteri_Id", "Musteri_Id", satislar.Musteri_Id);
            return View(satislar);
        }

        // GET: Satislars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satislar = await _context.SatisSatislar.FindAsync(id);
            if (satislar == null)
            {
                return NotFound();
            }
            ViewData["Musteri_Id"] = new SelectList(_context.Musterilers, "Musteri_Id", "Musteri_Id", satislar.Musteri_Id);
            return View(satislar);
        }

        // POST: Satislars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Satislar_Id,Musteri_Id,Tarih,Toplam_Tutar")] Satislar satislar)
        {
            if (id != satislar.Satislar_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(satislar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatislarExists(satislar.Satislar_Id))
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
            ViewData["Musteri_Id"] = new SelectList(_context.Musterilers, "Musteri_Id", "Musteri_Id", satislar.Musteri_Id);
            return View(satislar);
        }

        // GET: Satislars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satislar = await _context.SatisSatislar
                .Include(s => s.Musteriler)
                .FirstOrDefaultAsync(m => m.Satislar_Id == id);
            if (satislar == null)
            {
                return NotFound();
            }

            return View(satislar);
        }

        // POST: Satislars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satislar = await _context.SatisSatislar.FindAsync(id);
            if (satislar != null)
            {
                _context.SatisSatislar.Remove(satislar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SatislarExists(int id)
        {
            return _context.SatisSatislar.Any(e => e.Satislar_Id == id);
        }
    }
}
