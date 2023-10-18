using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShirtCatalog.Core.Entities;

namespace ShirtCatalog.Infrastructure.Persistence.Configurations
{
    public class ColorConfigurations : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasData(
                    new { Id = 1, Name = "Black" },
                    new { Id = 2, Name = "Pink" },
                    new { Id = 3, Name = "White" },
                    new { Id = 4, Name = "Off-white" },
                    new { Id = 5, Name = "Brown Truffle" },
                    new { Id = 6, Name = "Brown" }
               );
        }
    }
}
