using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class StokHareketleri
    {
        [Key]
        public int Hareket_Id { get; set; }
        public int ? Urun_Id { get; set; }
        public string Hareket_Turu { get; set; }=string.Empty;
        public int ? Miktari { get; set; }
        public DateTime ? Tarih { get; set; }
        public string  Aciklama { get; set; }=string.Empty;
        [ForeignKey("Urun_Id")]
        public  Urunler ? Urunler { get; set; }
        //bir defa kullanılacak
    }
}
