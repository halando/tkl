using Microsoft.EntityFrameworkCore;

namespace KoktelosAPIKezdemeny.Models
{
    public class Koktelok_Adatbazisa:DbContext
    {
        //public Koktelok_Adatbazisa() { }
        public Koktelok_Adatbazisa(DbContextOptions o) : base(o) { }
        public DbSet<Koktel> Koktelok { get; set; }
        public DbSet<Osszetevo> Osszetevok { get; set; }
        public DbSet<Recept> Receptek { get; set; }
    }
}
