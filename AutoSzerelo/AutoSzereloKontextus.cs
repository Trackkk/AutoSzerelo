using Microsoft.EntityFrameworkCore;
using AutoSzerelo.Shared;

namespace AutoSzerelo
{
    public class AutoSzereloKontextus : DbContext
    {
        public AutoSzereloKontextus(DbContextOptions<AutoSzereloKontextus> options) : base(options)
        {
        }

        public AutoSzereloKontextus(){}

        public virtual DbSet<Kliens> Kliensek { get; set; }
        public virtual DbSet<Munka> Munkak { get; set; }
    }
}
