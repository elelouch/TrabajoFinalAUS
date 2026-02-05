using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissTortas.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleProduct_StockProductId",
                table: "SaleProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_StockProductId",
                table: "SaleProduct",
                column: "StockProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SaleProduct_StockProductId",
                table: "SaleProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_StockProductId",
                table: "SaleProduct",
                column: "StockProductId");
        }
    }
}
