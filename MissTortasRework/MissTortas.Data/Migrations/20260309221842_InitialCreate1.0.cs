using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissTortas.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultancies_AspNetUsers_AssigneeId",
                table: "Consultancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultancies_AspNetUsers_ClientId",
                table: "Consultancies");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPreparations_AspNetUsers_AssigneeId",
                table: "OrderPreparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "ApplicationUserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "ApplicationUserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "ApplicationUserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "ApplicationUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "ApplicationRole");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "ApplicationRoleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Email_UserName",
                table: "ApplicationUser",
                newName: "IX_ApplicationUser_Email_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "ApplicationUserLogin",
                newName: "IX_ApplicationUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "ApplicationUserClaim",
                newName: "IX_ApplicationUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "ApplicationRoleClaim",
                newName: "IX_ApplicationRoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserToken",
                table: "ApplicationUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserLogin",
                table: "ApplicationUserLogin",
                columns: new[] { "ProviderKey", "LoginProvider" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserClaim",
                table: "ApplicationUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRole",
                table: "ApplicationRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationRoleClaim",
                table: "ApplicationRoleClaim",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRole_UserId",
                table: "ApplicationUserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationRoleClaim_ApplicationRole_RoleId",
                table: "ApplicationRoleClaim",
                column: "RoleId",
                principalTable: "ApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserClaim_ApplicationUser_UserId",
                table: "ApplicationUserClaim",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserLogin_ApplicationUser_UserId",
                table: "ApplicationUserLogin",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRole_RoleId",
                table: "ApplicationUserRole",
                column: "RoleId",
                principalTable: "ApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserId",
                table: "ApplicationUserRole",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserToken_ApplicationUser_UserId",
                table: "ApplicationUserToken",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultancies_ApplicationUser_AssigneeId",
                table: "Consultancies",
                column: "AssigneeId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultancies_ApplicationUser_ClientId",
                table: "Consultancies",
                column: "ClientId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPreparations_ApplicationUser_AssigneeId",
                table: "OrderPreparations",
                column: "AssigneeId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationRoleClaim_ApplicationRole_RoleId",
                table: "ApplicationRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserClaim_ApplicationUser_UserId",
                table: "ApplicationUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserLogin_ApplicationUser_UserId",
                table: "ApplicationUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationRole_RoleId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRole_ApplicationUser_UserId",
                table: "ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserToken_ApplicationUser_UserId",
                table: "ApplicationUserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultancies_ApplicationUser_AssigneeId",
                table: "Consultancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultancies_ApplicationUser_ClientId",
                table: "Consultancies");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPreparations_ApplicationUser_AssigneeId",
                table: "OrderPreparations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserToken",
                table: "ApplicationUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRole",
                table: "ApplicationUserRole");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserRole_UserId",
                table: "ApplicationUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserLogin",
                table: "ApplicationUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserClaim",
                table: "ApplicationUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                table: "ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRoleClaim",
                table: "ApplicationRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationRole",
                table: "ApplicationRole");

            migrationBuilder.RenameTable(
                name: "ApplicationUserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "ApplicationUserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "ApplicationUserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "ApplicationUserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ApplicationRoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "ApplicationRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUser_Email_UserName",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Email_UserName");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultancies_AspNetUsers_AssigneeId",
                table: "Consultancies",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultancies_AspNetUsers_ClientId",
                table: "Consultancies",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPreparations_AspNetUsers_AssigneeId",
                table: "OrderPreparations",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
