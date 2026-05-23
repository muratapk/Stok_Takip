using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokApi.Models;

namespace StokApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)  : base(options)
        {

        }
        public DbSet<Musteriler>Musterilers { get; set; }
        //Dbset yapısı ile sisteme tanıtıyoruz...
        //Ari_2019!
    }
    
   
}
