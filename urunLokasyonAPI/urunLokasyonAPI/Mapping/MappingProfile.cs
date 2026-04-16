using AutoMapper;
using urunLokasyonAPI.Dto;
using urunLokasyonAPI.Models;
namespace urunLokasyonAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Kullanici, KullaniciUrunDto>();
            CreateMap<Urun, UrunDto>();
        }
    }
}
