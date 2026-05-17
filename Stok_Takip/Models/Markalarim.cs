using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Markalarim
    {
        [Key]
        public int Marka_Id { get; set; }   
        public string? Marka_Ad { get; set; }
    }
}
