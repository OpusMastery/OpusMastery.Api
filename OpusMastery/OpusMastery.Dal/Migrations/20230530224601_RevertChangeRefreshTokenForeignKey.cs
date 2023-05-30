using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpusMastery.Dal.Migrations
{
    /// <inheritdoc />
    public partial class RevertChangeRefreshTokenForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RefreshTokenId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserRefreshTokens",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_RefreshTokenId",
                table: "Users",
                column: "RefreshTokenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRefreshTokens_RefreshTokenId",
                table: "Users",
                column: "RefreshTokenId",
                principalTable: "UserRefreshTokens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRefreshTokens_RefreshTokenId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RefreshTokenId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRefreshTokens");
        }
    }
}
