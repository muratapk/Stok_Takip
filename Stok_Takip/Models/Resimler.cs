using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stok_Takip.Models
{
    public class Resimler
    {
        [Key]
        public  int Resim_Id  { get; set; }
        public string Resim_Ad { get;set; }=string.Empty;
        public string Resim_Yolu { get; set; }=string.Empty;

    
        public int Urun_Id { get; set; }


        [ForeignKey("Urun_Id")]
        public Urunler ? Urunler { get; set; }
        //? soru işareti boş değer kabul edilebilir
        [NotMapped]
        //IFormFile, dosya yükleme işlemi için kullanılır. Bu özellik, veritabanında saklanmaz ve sadece geçici olarak dosya yükleme işlemi sırasında kullanılır.
        public IFormFile ? Images { get; set; }
    }
}
