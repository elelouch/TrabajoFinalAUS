using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissTortas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatexx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ManageQuantityAsInteger",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManageQuantityAsInteger",
                table: "Product");
        }
    }
}
