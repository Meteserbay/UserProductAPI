using Microsoft.EntityFrameworkCore;
using urunLokasyonAPI.Models;

namespace UrunLokasyonAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

    }
}