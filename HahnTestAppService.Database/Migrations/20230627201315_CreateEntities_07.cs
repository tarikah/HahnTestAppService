using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities_07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts",
                column: "PartTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts",
                column: "ManufacturerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts",
                column: "PartTypeId",
                unique: true);
        }
    }
}
