using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using urunLokasyonAPI.Dto;
using urunLokasyonAPI.Models;
using urunLokasyonAPI.Services;
using UrunLokasyonAPI.Data;

namespace urunLokasyonAPI.Controllers
{
    [ApiController]
    [Route("api/urun")]
    public class UrunController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UrunController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Urunler.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUrunById(int id) 
        {
            var urun = _context.Urunler.FirstOrDefault(urun =>  urun.Id == id);
            if (urun != null) 
            {
                return Ok(urun);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Urun guncelUrun)
        {
            var urun = _context.Urunler.FirstOrDefault(urun => urun.Id == id);
            if (urun != null)
            {
                urun.Name = guncelUrun.Name;
                urun.Barcode = guncelUrun.Barcode;
                urun.Location = guncelUrun.Location;
            }
            else
            {
                return NotFound();
            }
            _context.SaveChanges();

            return Ok(urun);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var urun = _context.Urunler.FirstOrDefault(urun => urun.Id == id);
            if(urun != null)
            {
                _context.Urunler.Remove(urun);
                _context.SaveChanges();
            }
            return Ok("Silindi");

        }

        [HttpPost]
        public IActionResult Add(Urun urun)
        {
            _context.Urunler.Add(urun);
            _context.SaveChanges();
            return Ok(urun);
        }
    }


    [ApiController]
    [Route("api/kullanici")]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _service;
        public KullaniciController(IKullaniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Kullanici kullanici)
        {
            _service.Add(kullanici);
            return Ok(kullanici);
        }

        [HttpGet("{id}/urunler")]
        public IActionResult GetKullaniciUrunleri(int id)
        {
            var result = _service.GetKullaniciUrunleri(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }


}
