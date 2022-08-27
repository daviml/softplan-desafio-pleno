using Microsoft.EntityFrameworkCore;
using SoftplanWebAPI.Entities;

namespace SoftplanWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SalaEntity> Salas { get; set; }
        public DbSet<ReservaEntity> Reservas { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}
