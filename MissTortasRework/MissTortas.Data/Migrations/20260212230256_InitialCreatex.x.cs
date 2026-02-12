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
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPreparation_AspNetUsers_AssigneeId",
                table: "OrderPreparation");

            migrationBuilder.AlterColumn<long>(
                name: "AssigneeId",
                table: "OrderPreparation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BakeryNotes",
                table: "Consultancy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Consultancy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PersonalizedProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultancyId = table.Column<long>(type: "bigint", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    FinalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalizedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalizedProduct_Consultancy_ConsultancyId",
                        column: x => x.ConsultancyId,
                        principalTable: "Consultancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalizedProduct_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizedProduct_ConsultancyId",
                table: "PersonalizedProduct",
                column: "ConsultancyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizedProduct_ProductCategoryId",
                table: "PersonalizedProduct",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPreparation_AspNetUsers_AssigneeId",
                table: "OrderPreparation",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPreparation_AspNetUsers_AssigneeId",
                table: "OrderPreparation");

            migrationBuilder.DropTable(
                name: "PersonalizedProduct");

            migrationBuilder.DropColumn(
                name: "BakeryNotes",
                table: "Consultancy");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Consultancy");

            migrationBuilder.AlterColumn<long>(
                name: "AssigneeId",
                table: "OrderPreparation",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPreparation_AspNetUsers_AssigneeId",
                table: "OrderPreparation",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
