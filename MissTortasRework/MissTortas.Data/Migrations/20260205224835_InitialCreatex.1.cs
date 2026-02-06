using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissTortas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatex1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SaleQuantityInteger",
                table: "SaleProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "IntegerQuantity",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleQuantityInteger",
                table: "SaleProduct");

            migrationBuilder.DropColumn(
                name: "IntegerQuantity",
                table: "Product");
        }
    }
}
