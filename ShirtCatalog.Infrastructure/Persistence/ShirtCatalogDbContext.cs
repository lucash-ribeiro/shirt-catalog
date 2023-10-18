using Microsoft.EntityFrameworkCore;
using ShirtCatalog.Core.Entities;
using System.Reflection;


namespace ShirtCatalog.Infrastructure.Persistence
{
    public class ShirtCatalogDbContext : DbContext
    {
        public ShirtCatalogDbContext(DbContextOptions<ShirtCatalogDbContext> options) : base(options) 
        { 

        }

        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
