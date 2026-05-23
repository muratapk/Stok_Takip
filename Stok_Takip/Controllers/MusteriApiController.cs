using Microsoft.AspNetCore.Mvc;

namespace Stok_Takip.Controllers
{
    public class MusteriApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7233/api");
        //api üzerinden bağlanacağım url adresi uri üzerinden baseAddress atıyorum

        private readonly HttpClient _httpClient;
        public MusteriApiController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        //HttpGet HttpDelete HttpPut HttpPost
        public IActionResult Index()
        {
            return View();
        }
    }
}
