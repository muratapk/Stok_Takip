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
    public class AlisDetaysController : Controller
    {
        private readonly AppDbContext _context;

        public AlisDetaysController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AlisDetays
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AlisDetay.Include(a => a.Alis).Include(a => a.Urunler);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AlisDetays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisDetay = await _context.AlisDetay
                .Include(a => a.Alis)
                .Include(a => a.Urunler)
                .FirstOrDefaultAsync(m => m.AlisDetay_Id == id);
            if (alisDetay == null)
            {
                return NotFound();
            }

            return View(alisDetay);
        }

        // GET: AlisDetays/Create
        public IActionResult Create()
        {
            ViewData["Alis_Id"] = new SelectList(_context.Alis, "Alis_Id", "Alis_Id");
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id");
            return View();
        }

        // POST: AlisDetays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlisDetay_Id,Alis_Id,Urun_Id,Miktari,BirimFiyat")] AlisDetay alisDetay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alisDetay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Alis_Id"] = new SelectList(_context.Alis, "Alis_Id", "Alis_Id", alisDetay.Alis_Id);
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", alisDetay.Urun_Id);
            return View(alisDetay);
        }

        // GET: AlisDetays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisDetay = await _context.AlisDetay.FindAsync(id);
            if (alisDetay == null)
            {
                return NotFound();
            }
            ViewData["Alis_Id"] = new SelectList(_context.Alis, "Alis_Id", "Alis_Id", alisDetay.Alis_Id);
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", alisDetay.Urun_Id);
            return View(alisDetay);
        }

        // POST: AlisDetays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlisDetay_Id,Alis_Id,Urun_Id,Miktari,BirimFiyat")] AlisDetay alisDetay)
        {
            if (id != alisDetay.AlisDetay_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alisDetay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlisDetayExists(alisDetay.AlisDetay_Id))
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
            ViewData["Alis_Id"] = new SelectList(_context.Alis, "Alis_Id", "Alis_Id", alisDetay.Alis_Id);
            ViewData["Urun_Id"] = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Id", alisDetay.Urun_Id);
            return View(alisDetay);
        }

        // GET: AlisDetays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisDetay = await _context.AlisDetay
                .Include(a => a.Alis)
                .Include(a => a.Urunler)
                .FirstOrDefaultAsync(m => m.AlisDetay_Id == id);
            if (alisDetay == null)
            {
                return NotFound();
            }

            return View(alisDetay);
        }

        // POST: AlisDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alisDetay = await _context.AlisDetay.FindAsync(id);
            if (alisDetay != null)
            {
                _context.AlisDetay.Remove(alisDetay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlisDetayExists(int id)
        {
            return _context.AlisDetay.Any(e => e.AlisDetay_Id == id);
        }
    }
}
