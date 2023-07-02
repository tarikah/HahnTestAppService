using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Manufacturers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Manufacturers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
