using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stok_Takip.Dto;
using Stok_Takip.Models;

namespace Stok_Takip.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;
        // UserManager, kullanıcı yönetimi işlemlerini gerçekleştirmek için kullanılan bir sınıftır. Kullanıcı oluşturma, silme, güncelleme gibi işlemleri yapmanızı sağlar.
        // SignInManager, kullanıcıların oturum açma işlemlerini yönetmek için kullanılan bir sınıftır. Kullanıcıların kimlik doğrulaması, oturum açma ve kapatma işlemlerini gerçekleştirmenizi sağlar.
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //Custroctor ile UserManager ve SignInManager sınıflarını enjekte ediyoruz. Bu sayede, bu sınıfların işlevselliğini AccountController içinde kullanabiliriz.
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto loginUserDto)
        {
           var result =  _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false).Result;
            // PasswordSignInAsync, kullanıcıların kimlik doğrulaması için kullanılan bir yöntemdir. Bu yöntem, kullanıcının e-posta adresi ve şifresini alır ve kimlik doğrulama işlemini gerçekleştirir. Sonuç olarak, oturum açma işleminin başarılı olup olmadığını belirten bir sonuç döndürür.
             if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
           
           

            TempData["Mesaj"] = "Email adresi ve Şifreniz Hatalı";

                return View(loginUserDto);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            AppUser user = new AppUser
            {
                AdSoyad=registerDto.AdSoyad,
                DogumTarihi=registerDto.DogumTarihi,
                Email=registerDto.UserEmail,
                UserName=registerDto.UserName
               
            };

            var result =await _userManager.CreateAsync(user, registerDto.Password);
            if(result.Succeeded)
            {
                return Redirect("Account");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            TempData["Mesaj"] = "İşlem Gerçekleşmedi";
            return View(registerDto);

        }
        public IActionResult Account()
        {
            return View();
        }
    }
}
