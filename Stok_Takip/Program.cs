using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;
using Stok_Takip.Models;

namespace Stok_Takip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                }
                
                );
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>();
            //builder.Services.AddIdentityCore<AppUser>() kullanýcý yönetimi için gerekli olan temel hizmetleri ekler. Bu, kullanýcýlarýn kimlik doðrulamasý, yetkilendirmesi ve yönetimi gibi iþlemleri gerçekleþtirmek için gereken temel iþlevselliði saðlar. Ancak, AddIdentityCore yöntemi, tam bir kimlik yönetimi sistemi saðlamaz ve genellikle özelleþtirilmiþ bir kullanýcý yönetimi sistemi oluþturmak isteyen geliþtiriciler tarafýndan kullanýlýr.
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
