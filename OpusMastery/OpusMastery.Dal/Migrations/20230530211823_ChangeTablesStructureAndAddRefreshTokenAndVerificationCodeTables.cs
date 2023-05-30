using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpusMastery.Dal.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTablesStructureAndAddRefreshTokenAndVerificationCodeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserRoleEntityRights");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserRoleEntityRights");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EmployeeRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "EmployeeRoles");

            migrationBuilder.RenameColumn(
                name: "EntityName",
                table: "UserRoleEntityRights",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RefreshTokenId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Companies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Companies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVerificationCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerificationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVerificationCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserVerificationCodes_UserId",
                table: "UserVerificationCodes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshTokens");

            migrationBuilder.DropTable(
                name: "UserVerificationCodes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserRoleEntityRights",
                newName: "EntityName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserRoleEntityRights",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserRoleEntityRights",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EmployeeRoles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "EmployeeRoles",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
