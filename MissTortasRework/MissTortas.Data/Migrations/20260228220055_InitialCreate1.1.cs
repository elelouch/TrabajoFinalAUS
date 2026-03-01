using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissTortas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_PermissionRole_PermissionRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_PermissionUser_PermissionUserId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_PermissionRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_PermissionUserId",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser");

            migrationBuilder.DropColumn(
                name: "PermissionRoleId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "PermissionUserId",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "PermissionUser",
                newName: "Permission");

            migrationBuilder.AlterColumn<int>(
                name: "ViewUserPermission",
                table: "Permission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Permission",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RolePermission",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApplicationRolePermission",
                columns: table => new
                {
                    PermissionsId = table.Column<long>(type: "bigint", nullable: false),
                    RolesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRolePermission", x => new { x.PermissionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ApplicationRolePermission_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationRolePermission_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRolePermission_RolesId",
                table: "ApplicationRolePermission",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "RolePermission",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "PermissionUser");

            migrationBuilder.AddColumn<long>(
                name: "PermissionRoleId",
                table: "AspNetRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PermissionUserId",
                table: "AspNetRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ViewUserPermission",
                table: "PermissionUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PermissionUser",
                table: "PermissionUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_PermissionRoleId",
                table: "AspNetRoles",
                column: "PermissionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_PermissionUserId",
                table: "AspNetRoles",
                column: "PermissionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_PermissionRole_PermissionRoleId",
                table: "AspNetRoles",
                column: "PermissionRoleId",
                principalTable: "PermissionRole",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_PermissionUser_PermissionUserId",
                table: "AspNetRoles",
                column: "PermissionUserId",
                principalTable: "PermissionUser",
                principalColumn: "Id");
        }
    }
}
