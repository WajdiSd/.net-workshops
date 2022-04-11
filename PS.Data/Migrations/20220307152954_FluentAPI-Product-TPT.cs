using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class FluentAPIProductTPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress_City",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Adress_StreetAdress",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Herbs",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LabName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isBiological",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "biological",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biological", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_biological_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chemical",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress_StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chemical", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_chemical_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "biological");

            migrationBuilder.DropTable(
                name: "chemical");

            migrationBuilder.AddColumn<string>(
                name: "Adress_City",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress_StreetAdress",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Herbs",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LabName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isBiological",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
