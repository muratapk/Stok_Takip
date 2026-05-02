using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class Alis
    {
        [Key]
        public  int Alis_Id { get; set; }
        public int ? Tedarikci_Id { get; set; }
        public DateTime ? Tarih { get; set; }
        public decimal Toplam_Tutar { get; set;  }
        [ForeignKey("Tedarikci_Id")]
        public Tedarikci? Tedarikci { get; set; }
        public List<AlisDetay> ? AlisDetays { get; set; }=new List<AlisDetay>();
    }
}
