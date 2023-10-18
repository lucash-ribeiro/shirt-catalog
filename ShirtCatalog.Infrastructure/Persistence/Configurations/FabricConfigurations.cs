using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShirtCatalog.Core.Entities;

namespace ShirtCatalog.Infrastructure.Persistence.Configurations
{
    public class FabricConfigurations : IEntityTypeConfiguration<Fabric>
    {
        public void Configure(EntityTypeBuilder<Fabric> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasData(
                    new { Id = 1, Name = "Cotton" },
                    new { Id = 2, Name = "Polyester Blend" }
               );
        }
    }
}
