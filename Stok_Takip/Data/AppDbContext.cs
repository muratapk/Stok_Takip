using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stok_Takip.Models;

namespace Stok_Takip.Data
{

    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Alis>? Alis {  get; set; }
        public DbSet<AlisDetay>? AlisDetay { get; set; }
        public DbSet<Kategoriler>? Kategorilers { get; set; }    
        public DbSet<Musteriler>? Musterilers { get; set; }
        public DbSet<SatisDetay>? SatisDetay { get;set; }    
        public DbSet<Satislar>? SatisSatislar { get; set; }
        public DbSet<StokHareketleri>?StokHareketleris   { get; set; }
        public DbSet<Tedarikci> ? Tedarikcis { get; set; } 
        public DbSet<Urunler> ? Urunlers { get; set; }
        public DbSet<Resimler> ? Resimlers { get; set; }
        public DbSet<Yorumlar>? Yorumlar { get;set; }

    }
}
