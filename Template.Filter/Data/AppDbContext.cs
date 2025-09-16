using Microsoft.EntityFrameworkCore;
using Template.Models;

namespace Template.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AnimalEntity> Animaux { get; set; }
        public DbSet<FruitEntity> Fruits { get; set; }
    }
}
