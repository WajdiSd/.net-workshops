using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Data.Migrations
{
    public partial class FluentAPIProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Products_ProductsProductId",
                table: "ProductProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersProviderId",
                table: "ProductProvider");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MyCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProvider",
                table: "ProductProvider");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductProvider",
                newName: "Providings");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_ProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProvider_ProvidersProviderId",
                table: "Providings",
                newName: "IX_Providings_ProvidersProviderId");

            migrationBuilder.AddColumn<int>(
                name: "isBiological",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providings",
                table: "Providings",
                columns: new[] { "ProductsProductId", "ProvidersProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryFK",
                table: "Products",
                column: "CategoryFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MyCategories_CategoryFK",
                table: "Products",
                column: "CategoryFK",
                principalTable: "MyCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId1",
                table: "Products",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providings_Products_ProductsProductId",
                table: "Providings",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Providings_Providers_ProvidersProviderId",
                table: "Providings",
                column: "ProvidersProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MyCategories_CategoryFK",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Providings_Products_ProductsProductId",
                table: "Providings");

            migrationBuilder.DropForeignKey(
                name: "FK_Providings_Providers_ProvidersProviderId",
                table: "Providings");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryFK",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providings",
                table: "Providings");

            migrationBuilder.DropColumn(
                name: "isBiological",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Providings",
                newName: "ProductProvider");

            migrationBuilder.RenameColumn(
                name: "ProductId1",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductId1",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Providings_ProvidersProviderId",
                table: "ProductProvider",
                newName: "IX_ProductProvider_ProvidersProviderId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProvider",
                table: "ProductProvider",
                columns: new[] { "ProductsProductId", "ProvidersProviderId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Products_ProductsProductId",
                table: "ProductProvider",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProvider_Providers_ProvidersProviderId",
                table: "ProductProvider",
                column: "ProvidersProviderId",
                principalTable: "Providers",
                principalColumn: "ProviderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MyCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "MyCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
