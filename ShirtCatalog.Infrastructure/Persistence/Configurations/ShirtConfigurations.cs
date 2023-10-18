using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShirtCatalog.Core.Entities;

namespace ShirtCatalog.Infrastructure.Persistence.Configurations
{
    public class ShirtConfigurations : IEntityTypeConfiguration<Shirt>
    {
        public void Configure(EntityTypeBuilder<Shirt> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasData(
                    new { Id = 1, Name = "Oversized T - Shirt" },
                    new { Id = 2, Name = "Embroidered Logo T-shirt" },
                    new { Id = 3, Name = "CH1 HERO TEE" },
                    new { Id = 4, Name = "CH1 GLASS SHARDS CREWNECK" }
               );
        }
    }
}
