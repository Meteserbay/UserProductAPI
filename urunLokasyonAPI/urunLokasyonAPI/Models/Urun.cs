using System.Text.Json.Serialization;

namespace urunLokasyonAPI.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        [JsonIgnore]
        public Kullanici? Kullanici { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Location { get; set; } // Showroom / Depo
    }
}
