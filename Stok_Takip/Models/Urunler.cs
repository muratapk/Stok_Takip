using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class Urunler
    {
        [Key]
        public int Urun_Id { get; set; }
        public string Urun_Adi { get; set; } = string.Empty;
        public int ? Kategori_Id { get; set; }
        public string Barkod { get; set; }=string.Empty;
        public decimal ? Alis_Fiyati { get; set; }
        public decimal ? Satis_Fiyati { get; set; }
        public int ? Stok_Miktari { get; set; }
        public int ? Minumum_Miktari { get; set; }

        [ForeignKey("Kategori_Id")]
        public Kategoriler ? kategoriler { get; set; }
        //ürünler tablosu sadece bir kategori verisi alabiir
        //kategori id forekey ikinci anahtar 
        public List<StokHareketleri> StokHareketleris { get; set; } = new List<StokHareketleri>();
        //bir ürünün birden çok stok stokhareketi olabilir
        public List<AlisDetay>? AlisDetays { get; set; } = new List<AlisDetay>();
        public List<SatisDetay>? SatisDetays { get;set; } = new List<SatisDetay>();

    }
}
