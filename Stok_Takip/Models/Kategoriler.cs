using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Kategoriler
    {
        [Key]
        public int Kategori_Id { get; set; }
        public string Kategori_Ad { get; set; }=string.Empty;
        public string Aciklama { get; set; }=string.Empty;
        public List<Urunler> Urunler { get; set; } = new List<Urunler>();
        //kategori birden fazla ürüne sahip olabilir 
    }
}
