using Microsoft.AspNetCore.Mvc;
using urunLokasyonAPI.Dto;
using urunLokasyonAPI.Models;
using urunLokasyonAPI.Services;
using UrunLokasyonAPI.Data;

namespace urunLokasyonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        public AuthController(AppDbContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            
            var kullanici = _context.Kullanicilar
                .FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (kullanici == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.CreateToken(kullanici);
            return Ok(new { token });

        }
    }
}
