using urunLokasyonAPI.Models;

namespace urunLokasyonAPI.Dto
{
    public class KullaniciUrunDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<UrunDto> Urunler { get; set; }

    }
}
