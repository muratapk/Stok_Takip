using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;
using Stok_Takip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        [Authorize]
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
        public async Task<IActionResult> Create([Bind("Urun_Id,Urun_Adi,Kategori_Id,Barkod,Alis_Fiyati,Satis_Fiyati,Stok_Miktari,Minumum_Miktari")] Urunler urunler,IFormFile Images)
        {

            if (Images != null)
            {
                //Path.getExtension(Images.FileName) ile resmin uzantısını alıyoruz
                //Guid.NewGuid().ToString() ile benzersiz bir dosya adı oluşturuyoruz
                var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(Images.FileName);
                //Images.FileName Dosya Adını alır
                //Images.Length dosya boyutunu alır
                //Images.Type dosya türünü alır
                //benzersiz dosya adını dosyadi kaydet
                //Path.Combine ile dosya yolunu oluşturuyoruz. Directory.GetCurrentDirectory() ile projenin kök dizinini alıyoruz, ardından "wwwroot/Product_Images" klasörünü ve dosya adını ekliyoruz
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product_Images", dosyaAdi);
                //using var ile dosya akışını açıyoruz ve dosyayı oluşturuyoruz. FileMode.Create, dosya zaten varsa üzerine yazılmasını sağlar
                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    Images.CopyTo(stream);
                    //CopyTo yöntemi, yüklenen dosyanın içeriğini oluşturduğumuz dosya akışına kopyalar
                }
                urunler.Urun_Resim = "/Urun_Resim/" + dosyaAdi;
                //veritabanına kaydedilecek resim yolu, oluşturduğumuz benzersiz dosya adını içeren bir URL olarak ayarlanır

            }







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
        public async Task<IActionResult> Edit(int id, [Bind("Urun_Id,Urun_Adi,Kategori_Id,Barkod,Alis_Fiyati,Satis_Fiyati,Stok_Miktari,Minumum_Miktari")] Urunler urunler,IFormFile Images)
        {

            if (Images != null)
            {
                //Path.getExtension(Images.FileName) ile resmin uzantısını alıyoruz
                //Guid.NewGuid().ToString() ile benzersiz bir dosya adı oluşturuyoruz
                var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(Images.FileName);
                //Images.FileName Dosya Adını alır
                //Images.Length dosya boyutunu alır
                //Images.Type dosya türünü alır
                //benzersiz dosya adını dosyadi kaydet
                //Path.Combine ile dosya yolunu oluşturuyoruz. Directory.GetCurrentDirectory() ile projenin kök dizinini alıyoruz, ardından "wwwroot/Product_Images" klasörünü ve dosya adını ekliyoruz
                var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product_Images", dosyaAdi);
                //using var ile dosya akışını açıyoruz ve dosyayı oluşturuyoruz. FileMode.Create, dosya zaten varsa üzerine yazılmasını sağlar
                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    Images.CopyTo(stream);
                    //CopyTo yöntemi, yüklenen dosyanın içeriğini oluşturduğumuz dosya akışına kopyalar
                }
                urunler.Urun_Resim = "/Urun_Resim/" + dosyaAdi;
                //veritabanına kaydedilecek resim yolu, oluşturduğumuz benzersiz dosya adını içeren bir URL olarak ayarlanır

            }


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
