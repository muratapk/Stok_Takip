using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class SatisDetay
    {
        [Key]
        public int SatisDetay_Id { get; set; }
        public  int ? Satis_Id  { get; set; }
        public  int ? UrunId { get; set; }
        public int ? Miktari { get; set; }
        public decimal? Birim_Fiyati { get;set; }
        [ForeignKey("Satis_Id")]
        public Satislar ? satislar { get; set; }
        [ForeignKey("Urun_Id")]
        public Urunler ? Urunler { get; set; }

    }
}
