using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Stok_Takip.Data;
using Stok_Takip.Models;
using System.Reflection.Metadata.Ecma335;

namespace Stok_Takip.Controllers
{
    public class YorumlarController : Controller
    {
        private readonly AppDbContext _context;
        //otomatik olarak devre girmesi 
        public YorumlarController(AppDbContext context)
        {
            _context = context;
        }
        //ilk başta programlar
        public IActionResult Index()
        {
            var listem = _context.Yorumlar.ToList();
            //birden fazla liste Liste yapısı var
            //veritabanındaki tüm listeleri getir

            return View(listem);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Yorumlar yorum)
        {
            if (ModelState.IsValid)//benim koymuş olduğum kuralları kontrol et
            {
                _context.Yorumlar.Add(yorum);
                _context.SaveChanges();
                TempData["Kayit"] = "Kayıt Başarılı Şekilde Yapıldı";
                return RedirectToAction("Index");
                //yorumlar içindeki index isimli action gönder

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            
                if (id == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var bul = _context.Yorumlar.Where(x => x.YorumlarId == id).FirstOrDefault();
                    return View(bul);
                }
                return View();
            
        }
        [HttpPost]
        public IActionResult Edit(int id,Yorumlar yorum)
        {
            ViewBag.UrunListe = new SelectList(_context.Urunlers, "Urun_Id", "Urun_Adi");
            if (ModelState.IsValid)
            {
                var bul=_context.Yorumlar.Where(x=>x.YorumlarId==id).FirstOrDefault();
                //değiştirilecek veri bul
                bul.YorumYapan = yorum.YorumYapan;
                bul.Aciklama = yorum.Aciklama;
                bul.Urun_Id = yorum.Urun_Id;
                _context.Yorumlar.Update(bul);
                _context.SaveChanges();
                TempData["Mesaj"] = "Kayıt Güncellendi";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bul=_context.Yorumlar.Where(x=>x.YorumlarId== id).FirstOrDefault();
            //select * from yorumlar where YorumlarId=1
            //_context.Yourmlar.ToList()
            //_context.Yorumlar.Where(x=>x.YorumlarId==id).FirstOrDefault();
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(int ? id )
        {
            if(id==null)
            {
                return NotFound();
            }
            var bul=_context.Yorumlar.Where(x=>x.YorumlarId== id).FirstOrDefault();
            _context.Yorumlar.Remove(bul);
            _context.SaveChanges();
            TempData["Mesaj"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}
