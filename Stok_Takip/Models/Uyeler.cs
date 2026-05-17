using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Uyeler
    {
        [Key]
        public int Uye_Id { get; set; } 
        public string? Uye_Ad { get; set; }

    }
}
