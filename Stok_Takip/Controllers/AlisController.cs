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
    public class AlisController : Controller
    {
        private readonly AppDbContext _context;

        public AlisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alis
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Alis.Include(a => a.Tedarikci);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Alis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alis = await _context.Alis
                .Include(a => a.Tedarikci)
                .FirstOrDefaultAsync(m => m.Alis_Id == id);
            if (alis == null)
            {
                return NotFound();
            }

            return View(alis);
        }

        // GET: Alis/Create
        public IActionResult Create()
        {
            ViewData["Tedarikci_Id"] = new SelectList(_context.Tedarikcis, "Tedarikci_Id", "Tedarikci_Id");
            return View();
        }

        // POST: Alis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Alis_Id,Tedarikci_Id,Tarih,Toplam_Tutar")] Alis alis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tedarikci_Id"] = new SelectList(_context.Tedarikcis, "Tedarikci_Id", "Tedarikci_Id", alis.Tedarikci_Id);
            return View(alis);
        }

        // GET: Alis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alis = await _context.Alis.FindAsync(id);
            if (alis == null)
            {
                return NotFound();
            }
            ViewData["Tedarikci_Id"] = new SelectList(_context.Tedarikcis, "Tedarikci_Id", "Tedarikci_Id", alis.Tedarikci_Id);
            return View(alis);
        }

        // POST: Alis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Alis_Id,Tedarikci_Id,Tarih,Toplam_Tutar")] Alis alis)
        {
            if (id != alis.Alis_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlisExists(alis.Alis_Id))
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
            ViewData["Tedarikci_Id"] = new SelectList(_context.Tedarikcis, "Tedarikci_Id", "Tedarikci_Id", alis.Tedarikci_Id);
            return View(alis);
        }

        // GET: Alis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alis = await _context.Alis
                .Include(a => a.Tedarikci)
                .FirstOrDefaultAsync(m => m.Alis_Id == id);
            if (alis == null)
            {
                return NotFound();
            }

            return View(alis);
        }

        // POST: Alis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alis = await _context.Alis.FindAsync(id);
            if (alis != null)
            {
                _context.Alis.Remove(alis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlisExists(int id)
        {
            return _context.Alis.Any(e => e.Alis_Id == id);
        }
    }
}
