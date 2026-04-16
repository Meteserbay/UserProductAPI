using Microsoft.EntityFrameworkCore;
using urunLokasyonAPI.Dto;
using urunLokasyonAPI.Models;
using UrunLokasyonAPI.Data;
using AutoMapper;

namespace urunLokasyonAPI.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public KullaniciService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Kullanici Add(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return kullanici;
        }

        public List<Kullanici> GetAll()
        {
            return _context.Kullanicilar.ToList();
        }

        public Kullanici GetById(int id)
        {
            return _context.Kullanicilar.FirstOrDefault(x => x.Id == id);
        }

        public KullaniciUrunDto GetKullaniciUrunleri(int id)
        {
            var kullanici = _context.Kullanicilar
                .Include(u => u.Urunler)
                .FirstOrDefault(x => x.Id == id);

            if (kullanici == null)
                return null;

            return _mapper.Map<KullaniciUrunDto>(kullanici);
        }
    }
}
