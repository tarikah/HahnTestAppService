using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HahnTestAppService.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntities_04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartTypeId",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PartTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts",
                column: "PartTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_PartTypes_PartTypeId",
                table: "Parts",
                column: "PartTypeId",
                principalTable: "PartTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_PartTypes_PartTypeId",
                table: "Parts");

            migrationBuilder.DropTable(
                name: "PartTypes");

            migrationBuilder.DropIndex(
                name: "IX_Parts_PartTypeId",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "PartTypeId",
                table: "Parts");
        }
    }
}
