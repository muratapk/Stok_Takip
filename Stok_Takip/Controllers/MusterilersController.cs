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
    public class MusterilersController : Controller
    {
        private readonly AppDbContext _context;

        public MusterilersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Musterilers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Musterilers.ToListAsync());
        }

        // GET: Musterilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musterilers
                .FirstOrDefaultAsync(m => m.Musteri_Id == id);
            if (musteriler == null)
            {
                return NotFound();
            }

            return View(musteriler);
        }

        // GET: Musterilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musterilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Musteri_Id,Musteri_Adi,Telefon,Email,Adres")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteriler);
        }

        // GET: Musterilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musterilers.FindAsync(id);
            if (musteriler == null)
            {
                return NotFound();
            }
            return View(musteriler);
        }

        // POST: Musterilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Musteri_Id,Musteri_Adi,Telefon,Email,Adres")] Musteriler musteriler)
        {
            if (id != musteriler.Musteri_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusterilerExists(musteriler.Musteri_Id))
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
            return View(musteriler);
        }

        // GET: Musterilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriler = await _context.Musterilers
                .FirstOrDefaultAsync(m => m.Musteri_Id == id);
            if (musteriler == null)
            {
                return NotFound();
            }

            return View(musteriler);
        }

        // POST: Musterilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteriler = await _context.Musterilers.FindAsync(id);
            if (musteriler != null)
            {
                _context.Musterilers.Remove(musteriler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusterilerExists(int id)
        {
            return _context.Musterilers.Any(e => e.Musteri_Id == id);
        }
    }
}
