﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShirtCatalog.Infrastructure.Persistence;

#nullable disable

namespace ShirtCatalog.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ShirtCatalogDbContext))]
    [Migration("20231015190145_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pink"
                        },
                        new
                        {
                            Id = 3,
                            Name = "White"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Off-white"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Brown Truffle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Brown"
                        });
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Fabric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabrics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cotton"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Polyester Blend"
                        });
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdVariation")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdVariation");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdVariation = 8,
                            ImagePath = "~\\Upload\\Files\\638329820517217377.png"
                        },
                        new
                        {
                            Id = 2,
                            IdVariation = 8,
                            ImagePath = "~\\Upload\\Files\\638329820517217377.png"
                        },
                        new
                        {
                            Id = 3,
                            IdVariation = 8,
                            ImagePath = "~\\Upload\\Files\\638329820636101975.png"
                        });
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Shirt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shirts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Oversized T - Shirt"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Embroidered Logo T-shirt"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CH1 HERO TEE"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CH1 GLASS SHARDS CREWNECK"
                        });
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Variation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdFabric")
                        .HasColumnType("int");

                    b.Property<int>("IdShirt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdFabric");

                    b.HasIndex("IdShirt");

                    b.ToTable("Variations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdColor = 4,
                            IdFabric = 1,
                            IdShirt = 1
                        },
                        new
                        {
                            Id = 2,
                            IdColor = 5,
                            IdFabric = 2,
                            IdShirt = 1
                        },
                        new
                        {
                            Id = 3,
                            IdColor = 6,
                            IdFabric = 1,
                            IdShirt = 1
                        },
                        new
                        {
                            Id = 4,
                            IdColor = 2,
                            IdFabric = 1,
                            IdShirt = 2
                        },
                        new
                        {
                            Id = 5,
                            IdColor = 3,
                            IdFabric = 1,
                            IdShirt = 2
                        },
                        new
                        {
                            Id = 6,
                            IdColor = 1,
                            IdFabric = 2,
                            IdShirt = 2
                        },
                        new
                        {
                            Id = 7,
                            IdColor = 1,
                            IdFabric = 1,
                            IdShirt = 3
                        },
                        new
                        {
                            Id = 8,
                            IdColor = 1,
                            IdFabric = 2,
                            IdShirt = 4
                        });
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Image", b =>
                {
                    b.HasOne("ShirtCatalog.Core.Entities.Variation", "Variation")
                        .WithMany("Images")
                        .HasForeignKey("IdVariation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Variation", b =>
                {
                    b.HasOne("ShirtCatalog.Core.Entities.Color", "Color")
                        .WithMany("Variations")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShirtCatalog.Core.Entities.Fabric", "Fabric")
                        .WithMany("Variations")
                        .HasForeignKey("IdFabric")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShirtCatalog.Core.Entities.Shirt", "Shirt")
                        .WithMany("Variations")
                        .HasForeignKey("IdShirt")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Fabric");

                    b.Navigation("Shirt");
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Color", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Fabric", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Shirt", b =>
                {
                    b.Navigation("Variations");
                });

            modelBuilder.Entity("ShirtCatalog.Core.Entities.Variation", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
