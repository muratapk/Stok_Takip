using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public class Tedarikci
    {
        [Key]
        public int Tedarikci_Id { get; set; }
        public string Firma_Adi { get; set; } = string.Empty;
        public string Yetkili_Kisi { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Adres {  get; set; } = string.Empty;
        public List<Alis> ? Alis { get; set; } = new List<Alis>();
    }
}
