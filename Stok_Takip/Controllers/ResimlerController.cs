using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stok_Takip.Data;
using Stok_Takip.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Stok_Takip.Controllers
{
    public class ResimlerController : Controller
    {
        private readonly AppDbContext _context;
        public ResimlerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listem=_context.Resimlers.ToList();
            //databasedeki Resimlerin listesini listem ata 
            return View(listem);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var bul=_context.Resimlers.Where(x=>x.Resim_Id==id).FirstOrDefault();
            //bulduğunuz ilk değeri al 
            if (bul == null)
            { 
                return NotFound();
            }
            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(Resimler ? resimler,int ?id,IFormFile Images)
        {
           



            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            var bul=_context.Resimlers.Where(x=>x.Resim_Id==id).FirstOrDefault();


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
                bul.Resim_Yolu = "/Product_Images/" + dosyaAdi;
                //veritabanına kaydedilecek resim yolu, oluşturduğumuz benzersiz dosya adını içeren bir URL olarak ayarlanır

            }




            if (bul == null)
            {
                return NotFound();
            }
            bul.Resim_Ad = resimler.Resim_Ad;
            bul.Resim_Yolu = resimler.Resim_Yolu;
            bul.Urun_Id = resimler.Urun_Id;
            _context.Resimlers.Update(bul);
            _context.SaveChanges();
            //database kayıt etmek için kullandığım kısım
            //mutlaka _context.SaveChanges() kullanmak zorundayız.
            TempData["Mesaj"] = "Kayıt Düzeltildi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Resimler resimler,IFormFile Images)
        {
            //resim dosyas != null ise işlemi yap
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
                resimler.Resim_Yolu = "/Product_Images/" + dosyaAdi;
                //veritabanına kaydedilecek resim yolu, oluşturduğumuz benzersiz dosya adını içeren bir URL olarak ayarlanır

            }

            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            _context.Resimlers.Add(resimler);
            _context.SaveChanges();
            //add ekleme update güncelleme remove silme 
            //saveChanges kullanmak zorundayız.
            TempData["Mesaj"] = "Yeni Kayıt Eklendi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul=_context.Resimlers.Where(x=>x.Resim_Id == id).FirstOrDefault();
            if(bul == null) { return NotFound(); }
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(int ?id)
        {
            var bul=_context.Resimlers.Where(x=>x.Resim_Id == id).FirstOrDefault();
            _context.Resimlers.Remove(bul);
            _context.SaveChanges();
            TempData["Mesaj"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
