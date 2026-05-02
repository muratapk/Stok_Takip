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
    public class TedarikcisController : Controller
    {
        private readonly AppDbContext _context;

        public TedarikcisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tedarikcis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tedarikcis.ToListAsync());
        }

        // GET: Tedarikcis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tedarikci = await _context.Tedarikcis
                .FirstOrDefaultAsync(m => m.Tedarikci_Id == id);
            if (tedarikci == null)
            {
                return NotFound();
            }

            return View(tedarikci);
        }

        // GET: Tedarikcis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tedarikcis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tedarikci_Id,Firma_Adi,Yetkili_Kisi,Telefon,Email,Adres")] Tedarikci tedarikci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tedarikci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tedarikci);
        }

        // GET: Tedarikcis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tedarikci = await _context.Tedarikcis.FindAsync(id);
            if (tedarikci == null)
            {
                return NotFound();
            }
            return View(tedarikci);
        }

        // POST: Tedarikcis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tedarikci_Id,Firma_Adi,Yetkili_Kisi,Telefon,Email,Adres")] Tedarikci tedarikci)
        {
            if (id != tedarikci.Tedarikci_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tedarikci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TedarikciExists(tedarikci.Tedarikci_Id))
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
            return View(tedarikci);
        }

        // GET: Tedarikcis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tedarikci = await _context.Tedarikcis
                .FirstOrDefaultAsync(m => m.Tedarikci_Id == id);
            if (tedarikci == null)
            {
                return NotFound();
            }

            return View(tedarikci);
        }

        // POST: Tedarikcis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tedarikci = await _context.Tedarikcis.FindAsync(id);
            if (tedarikci != null)
            {
                _context.Tedarikcis.Remove(tedarikci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TedarikciExists(int id)
        {
            return _context.Tedarikcis.Any(e => e.Tedarikci_Id == id);
        }
    }
}
