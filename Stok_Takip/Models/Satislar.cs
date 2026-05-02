using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class Satislar
    {
        [Key]
        public int Satislar_Id { get; set; }
        public int ? Musteri_Id { get; set; }
        public DateTime? Tarih { get; set; }
        public  decimal Toplam_Tutar { get; set; }
        [ForeignKey("Musteri_Id")]
        public Musteriler? Musteriler { get; set; }
        public List<SatisDetay>? SatisDetays { get; set; } = new List<SatisDetay>();
    }
}
