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
    public class UrunlersController : Controller
    {
        private readonly AppDbContext _context;

        public UrunlersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Urunlers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Urunlers.Include(u => u.kategoriler);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Urunlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunlers
                .Include(u => u.kategoriler)
                .FirstOrDefaultAsync(m => m.Urun_Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // GET: Urunlers/Create
        public IActionResult Create()
        {
            ViewData["Kategori_Id"] = new SelectList(_context.Kategorilers, "Kategori_Id", "Kategori_Id");
            return View();
        }

        // POST: Urunlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Urun_Id,Urun_Adi,Kategori_Id,Barkod,Alis_Fiyati,Satis_Fiyati,Stok_Miktari,Minumum_Miktari")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kategori_Id"] = new SelectList(_context.Kategorilers, "Kategori_Id", "Kategori_Id", urunler.Kategori_Id);
            return View(urunler);
        }

        // GET: Urunlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunlers.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }
            ViewData["Kategori_Id"] = new SelectList(_context.Kategorilers, "Kategori_Id", "Kategori_Id", urunler.Kategori_Id);
            return View(urunler);
        }

        // POST: Urunlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Urun_Id,Urun_Adi,Kategori_Id,Barkod,Alis_Fiyati,Satis_Fiyati,Stok_Miktari,Minumum_Miktari")] Urunler urunler)
        {
            if (id != urunler.Urun_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunlerExists(urunler.Urun_Id))
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
            ViewData["Kategori_Id"] = new SelectList(_context.Kategorilers, "Kategori_Id", "Kategori_Id", urunler.Kategori_Id);
            return View(urunler);
        }

        // GET: Urunlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunlers
                .Include(u => u.kategoriler)
                .FirstOrDefaultAsync(m => m.Urun_Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // POST: Urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urunler = await _context.Urunlers.FindAsync(id);
            if (urunler != null)
            {
                _context.Urunlers.Remove(urunler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunlerExists(int id)
        {
            return _context.Urunlers.Any(e => e.Urun_Id == id);
        }
    }
}
