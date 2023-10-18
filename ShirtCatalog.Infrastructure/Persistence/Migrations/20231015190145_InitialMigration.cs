using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShirtCatalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShirt = table.Column<int>(type: "int", nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdFabric = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variations_Colors_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variations_Fabrics_IdFabric",
                        column: x => x.IdFabric,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Variations_Shirts_IdShirt",
                        column: x => x.IdShirt,
                        principalTable: "Shirts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVariation = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Variations_IdVariation",
                        column: x => x.IdVariation,
                        principalTable: "Variations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "Pink" },
                    { 3, "White" },
                    { 4, "Off-white" },
                    { 5, "Brown Truffle" },
                    { 6, "Brown" }
                });

            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cotton" },
                    { 2, "Polyester Blend" }
                });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Oversized T - Shirt" },
                    { 2, "Embroidered Logo T-shirt" },
                    { 3, "CH1 HERO TEE" },
                    { 4, "CH1 GLASS SHARDS CREWNECK" }
                });

            migrationBuilder.InsertData(
                table: "Variations",
                columns: new[] { "Id", "IdColor", "IdFabric", "IdShirt" },
                values: new object[,]
                {
                    { 1, 4, 1, 1 },
                    { 2, 5, 2, 1 },
                    { 3, 6, 1, 1 },
                    { 4, 2, 1, 2 },
                    { 5, 3, 1, 2 },
                    { 6, 1, 2, 2 },
                    { 7, 1, 1, 3 },
                    { 8, 1, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IdVariation", "ImagePath" },
                values: new object[,]
                {
                    { 1, 8, "~\\Upload\\Files\\638329820517217377.png" },
                    { 2, 8, "~\\Upload\\Files\\638329820517217377.png" },
                    { 3, 8, "~\\Upload\\Files\\638329820636101975.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdVariation",
                table: "Images",
                column: "IdVariation");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_IdColor",
                table: "Variations",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_IdFabric",
                table: "Variations",
                column: "IdFabric");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_IdShirt",
                table: "Variations",
                column: "IdShirt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "Shirts");
        }
    }
}
