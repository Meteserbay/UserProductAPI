using urunLokasyonAPI.Dto;
using urunLokasyonAPI.Models;

namespace urunLokasyonAPI.Services
{
    public interface IKullaniciService
    {
        List<Kullanici> GetAll();
        Kullanici GetById(int id);

        Kullanici Add(Kullanici kullanici);

        KullaniciUrunDto GetKullaniciUrunleri(int id);
    }
}
