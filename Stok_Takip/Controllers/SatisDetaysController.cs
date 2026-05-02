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
    public class SatisDetaysController : Controller
    {
        private readonly AppDbContext _context;

        public SatisDetaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SatisDetays
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SatisDetay.Include(s => s.satislar);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SatisDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satisDetay = await _context.SatisDetay
                .Include(s => s.satislar)
                .FirstOrDefaultAsync(m => m.SatisDetay_Id == id);
            if (satisDetay == null)
            {
                return NotFound();
            }

            return View(satisDetay);
        }

        // GET: SatisDetays/Create
        public IActionResult Create()
        {
            ViewData["Satis_Id"] = new SelectList(_context.SatisSatislar, "Satislar_Id", "Satislar_Id");
            return View();
        }

        // POST: SatisDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SatisDetay_Id,Satis_Id,UrunId,Miktari,Birim_Fiyati")] SatisDetay satisDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(satisDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Satis_Id"] = new SelectList(_context.SatisSatislar, "Satislar_Id", "Satislar_Id", satisDetay.Satis_Id);
            return View(satisDetay);
        }

        // GET: SatisDetays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satisDetay = await _context.SatisDetay.FindAsync(id);
            if (satisDetay == null)
            {
                return NotFound();
            }
            ViewData["Satis_Id"] = new SelectList(_context.SatisSatislar, "Satislar_Id", "Satislar_Id", satisDetay.Satis_Id);
            return View(satisDetay);
        }

        // POST: SatisDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SatisDetay_Id,Satis_Id,UrunId,Miktari,Birim_Fiyati")] SatisDetay satisDetay)
        {
            if (id != satisDetay.SatisDetay_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(satisDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatisDetayExists(satisDetay.SatisDetay_Id))
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
            ViewData["Satis_Id"] = new SelectList(_context.SatisSatislar, "Satislar_Id", "Satislar_Id", satisDetay.Satis_Id);
            return View(satisDetay);
        }

        // GET: SatisDetays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satisDetay = await _context.SatisDetay
                .Include(s => s.satislar)
                .FirstOrDefaultAsync(m => m.SatisDetay_Id == id);
            if (satisDetay == null)
            {
                return NotFound();
            }

            return View(satisDetay);
        }

        // POST: SatisDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satisDetay = await _context.SatisDetay.FindAsync(id);
            if (satisDetay != null)
            {
                _context.SatisDetay.Remove(satisDetay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SatisDetayExists(int id)
        {
            return _context.SatisDetay.Any(e => e.SatisDetay_Id == id);
        }
    }
}
