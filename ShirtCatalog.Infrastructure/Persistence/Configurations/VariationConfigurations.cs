using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShirtCatalog.Core.Entities;
using System.Drawing;

namespace ShirtCatalog.Infrastructure.Persistence.Configurations
{
    public class VariationConfigurations : IEntityTypeConfiguration<Variation>
    {
        public void Configure(EntityTypeBuilder<Variation> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(v => v.Color)
                .WithMany(c => c.Variations)
                .HasForeignKey(v => v.IdColor)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Fabric)
                .WithMany(f => f.Variations)
                .HasForeignKey(v => v.IdFabric)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.Shirt)
                .WithMany(s => s.Variations)
                .HasForeignKey(v => v.IdShirt)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(
                    //"Oversized T - Shirt"
                    new { Id = 1, IdShirt = 1, IdColor = 4, IdFabric = 1},
                    new { Id = 2, IdShirt = 1, IdColor = 5, IdFabric = 2},
                    new { Id = 3, IdShirt = 1, IdColor = 6, IdFabric = 1},

                    //Embroidered Logo T-shirt
                    new { Id = 4, IdShirt = 2, IdColor = 2, IdFabric = 1},
                    new { Id = 5, IdShirt = 2, IdColor = 3, IdFabric = 1},
                    new { Id = 6, IdShirt = 2, IdColor = 1, IdFabric = 2},

                    //CH1 HERO TEE
                    new { Id = 7, IdShirt = 3, IdColor = 1, IdFabric = 1},

                    //CH1 GLASS SHARDS CREWNECK
                    new { Id = 8, IdShirt = 4, IdColor = 1, IdFabric = 2}
               );
        }
    }
}
