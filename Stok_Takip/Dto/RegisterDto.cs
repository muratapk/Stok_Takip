namespace Stok_Takip.Dto
{
    public class RegisterDto
    {
        public string AdSoyad { get; set; }=string.Empty;
        public DateTime DogumTarihi { get; set; }
        public string UserName { get; set; }=string.Empty;
        public string UserEmail { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
        public string ConfirmPassword { get; set; }=string.Empty;
    }
}
