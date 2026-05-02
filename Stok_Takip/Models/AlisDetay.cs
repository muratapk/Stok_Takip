using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class AlisDetay
    {
        [Key]
        public int AlisDetay_Id { get; set; }
        public  int ? Alis_Id { get; set; }
        public int ? Urun_Id  { get; set; }
        public int ?  Miktari { get; set; }
        public decimal ? BirimFiyat { get; set; }
        [ForeignKey("Alis_Id")]
        public Alis ? Alis { get; set;  }
        [ForeignKey("Urun_Id")]
        public Urunler? Urunler { get; set; }
    }
}
