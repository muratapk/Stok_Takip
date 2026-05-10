using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;

namespace Stok_Takip.Component
{
    public class UrunListe:ViewComponent
    {
        private readonly AppDbContext _context;
        public UrunListe(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var listem = _context.Urunlers.Include(x=>x.Resimlers).ToList();
            //databasedeki Urunlerin listesini listem ata
            return View(listem);
        }
    }
}
