using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StokApi.Data;
using StokApi.Models;
using System.Collections;

namespace StokApi.Controllers
{
    [Route("api/[controller]")]
    //sen uzaktan bağlanacaksan buradaki api/Musteriler
    [ApiController]
    public class MusterilerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MusterilerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musteriler>>>GetMusteriler()
        {
            return await _context.Musterilers.ToListAsync();
            //tüm Müsteri verilerini çekmesini istiyorum bana geri gönder 
        }
        [HttpGet("id")]
        public async Task<ActionResult<Musteriler>>GetMusteriId(int id) 
        {
             var result=await _context.Musterilers.Where(x=>x.Musteri_Id==id).FirstOrDefaultAsync();
            return result;
            

        
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Musteriler>>DeleteMusteriler(int id)
        {
            var result = await _context.Musterilers.Where(x => x.Musteri_Id == id).FirstOrDefaultAsync();
            if(result!=null)
            {
                _context.Musterilers.Remove(result);
                await _context.SaveChangesAsync();
                
            }
            return result;
        }
        [HttpPut("id")]
        public async Task<ActionResult<Musteriler>>PutMusteriler(Musteriler musteri,int id)
        {
            var result=await _context.Musterilers.Where(x=>x.Musteri_Id==id).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Musteri_Adi = musteri.Musteri_Adi;
                result.Email= musteri.Email;
                result.Telefon= musteri.Telefon;
                result.Adres= musteri.Adres; 
                _context.Musterilers.Update(result);
                await _context.SaveChangesAsync();
            }
            return result;

        }
        [HttpPost]
        public async Task<ActionResult<Musteriler>>PostMusteriler(Musteriler musteri)
        {
            _context.Musterilers.Add(musteri);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
