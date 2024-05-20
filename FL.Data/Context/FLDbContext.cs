using FL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FL.Data.Context
{
    public class FLDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Lap> Laps { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public FLDbContext(DbContextOptions<FLDbContext> options) : base(options)
        {

        }
    }
}
