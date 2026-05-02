using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Musteriler
    {
        [Key]
        public int Musteri_Id { get; set; }
        public string Musteri_Adi { get; set; } = string.Empty;
      
        public string Telefon { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
        public List<Satislar> Satislars { get; set; }=new List<Satislar>();
    }
}
