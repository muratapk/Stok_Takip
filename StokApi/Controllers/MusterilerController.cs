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
    }
}
