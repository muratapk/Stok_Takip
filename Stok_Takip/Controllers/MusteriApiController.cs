using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stok_Takip.Models;
using System.Text;

namespace Stok_Takip.Controllers
{
    public class MusteriApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7233/api");
        //api üzerinden bağlanacağım url adresi uri üzerinden baseAddress atıyorum

        private readonly HttpClient _httpClient;
        //httpClient  class burada tanım
        //Ogrenci ali =new Ali();
        //Ogrenci Ali;
        //Custructor nesnede  ali=new Ogrenci()
        //karşı istek bulunur bu sonucu alarak işlem yapacağız.
        public MusteriApiController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        //HttpGet HttpDelete HttpPut HttpPost
        //Veriler listelediğimiz Kısım
        public IActionResult Index()
        {
            List<Musteriler> musterilers = new List<Musteriler>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Musteriler/").Result;
            //api üzerindeki yola bağlanarak response verileri çekiyorum..
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //gelen datalar json formatında 
                musterilers = JsonConvert.DeserializeObject<List<Musteriler>>(data);

            }

            return View(musterilers);
            //html sayfama gönderiyorum

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Musteriler musteriler)
        {
            try
            {
                //kodu yazıyoruz
                //string data=JsonConvert.SerializeObject(musteriler);
                //form verileri seriliazeobject data çevirdim...
                //StringContent content = new StringContent(data,Encoding.UTF8,"Application/Json");
                //gönderilerilen içeriğin Json sayfası olduğunu içeriğin json çeviriyoruz.
                //HttpResponseMessage response=_httpClient.PostAsJsonAsync(_httpClient.BaseAddress+"/Musteriler/", content).Result;
                HttpResponseMessage response = _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "/Musteriler/", musteriler).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }



            }
            catch (Exception ex)
            {
                //program kapanmasın diye 
                //hata yakalamayı çalıştırıyoruz.
                TempData["Mesaj"] = ex;
                return View();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Musteriler musteriler = new Musteriler();
                //musteril ismindeki klass çağırdım
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Musteriler/" + id).Result;
                //id numarasına göre o ürünü çekmesini istiyorum
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    //içindeki veri okuyup data içine atıyorum
                    musteriler = JsonConvert.DeserializeObject<Musteriler>(data);
                    return View(musteriler);
                }


            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = ex;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Musteriler musteriler, int id)
        {
           
            try
            {
                //string data=JsonConvert.SerializeObject(musteriler);
                //gelen bilgileri Json Formatına çeviriyoruz
                //HttpResponseMessage response=_httpClient.PutAsJsonAsync(_httpClient.BaseAddress+"/Musteriler/"+id,data).Result;
                HttpResponseMessage response =_httpClient.PutAsJsonAsync(_httpClient.BaseAddress + "/Musteriler/"+ id, musteriler).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["Mesaj"] = "Kayıt Düzeltildi";
                    return RedirectToAction("Index");
                }

                


            }
            catch (Exception ex)
            {
                TempData["Mesaj"] = ex;
                return View();
            }
                return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "/Musteriler/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Mesaj"] = "Kayıt Silindi";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["Mesaj"]= ex;
                return View();
            }
            return View();
        }
    }
}
