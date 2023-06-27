using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities_09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_PartId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Brands");

            migrationBuilder.CreateTable(
                name: "PartBrands",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartBrands", x => new { x.PartId, x.BrandId });
                    table.ForeignKey(
                        name: "FK_PartBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartBrands_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartBrands_BrandId",
                table: "PartBrands",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartBrands");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_PartId",
                table: "Brands",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");
        }
    }
}
