using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class Yorumlar
    {
        [Key]
        public int YorumlarId { get; set; } 
        public string YorumYapan { get; set; }=string.Empty;
        public string Aciklama {  get; set; }=string.Empty;
        [ForeignKey("Urun_Id")]
        public int Urun_Id {  get; set; }
        public Urunler? Urunler { get; set; }
    }
}
