using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UrunDetay(int ?id)
        {   
            if (id == null)
            {
                // Eðer id null ise, yani geçerli bir ürün ID'si saðlanmamýþsa, NotFound() döndürülür.
                return NotFound();
            }
            var urun = _context.Urunlers.FirstOrDefault(x => x.Urun_Id == id);
            // Veritabaýndaki Urunlers tablosundan, Urun_Id'si id parametresiyle eþleþen ilk ürünü bulur. Eðer böyle bir ürün yoksa, urun deðiþkeni null olur.
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        
        public IActionResult Kategoriler(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategori = _context.Urunlers.Where(x=> x.Kategori_Id == id).ToList();
            //tüm kategori id'si id parametresiyle eþleþen ürünleri bulur ve bir liste olarak kategori deðiþkenine atar. Eðer böyle bir kategori yoksa, kategori deðiþkeni boþ bir liste olur.
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
