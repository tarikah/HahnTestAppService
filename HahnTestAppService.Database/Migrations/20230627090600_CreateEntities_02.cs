using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufacturers_Parts_PartId",
                table: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_PartId",
                table: "Manufacturers");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Brands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts",
                column: "ManufacturerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Manufacturers_ManufacturerId",
                table: "Parts",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Manufacturers_ManufacturerId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ManufacturerId",
                table: "Parts");

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_PartId",
                table: "Manufacturers",
                column: "PartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Parts_PartId",
                table: "Brands",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufacturers_Parts_PartId",
                table: "Manufacturers",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
