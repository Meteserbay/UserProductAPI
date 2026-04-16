namespace urunLokasyonAPI.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public List<Urun>? Urunler { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
