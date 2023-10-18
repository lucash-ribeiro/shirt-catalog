using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShirtCatalog.Core.Entities;
using System.Drawing;

namespace ShirtCatalog.Infrastructure.Persistence.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .HasOne(i => i.Variation)
                .WithMany(v => v.Images)
                .HasForeignKey(v => v.IdVariation)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(
                    //CH1 GLASS SHARDS CREWNECK
                    new { Id = 1, IdVariation = 8, ImagePath = "~\\Upload\\Files\\638329820517217377.png" },
                    new { Id = 2, IdVariation = 8, ImagePath = "~\\Upload\\Files\\638329820517217377.png" },
                    new { Id = 3, IdVariation = 8, ImagePath = "~\\Upload\\Files\\638329820636101975.png" }
               );
        }
    }
}
