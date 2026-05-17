using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Stok_Takip.Models
{
    public class AppUser:IdentityUser
    {
        //IdentityUser sınıfı, ASP.NET Core Identity tarafından sağlanan bir sınıftır ve kullanıcı yönetimi için temel özellikleri içerir. AppUser sınıfı, IdentityUser sınıfından türetilerek oluşturulmuştur. Bu sayede, AppUser sınıfı, IdentityUser'ın tüm özelliklerini ve işlevselliğini devralır ve aynı zamanda kendi özel özelliklerini ekleyebilir.
        public string AdSoyad { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
        public DateTime ? DogumTarihi { get; set; }


    }
}
