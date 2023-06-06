using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpusMastery.Dal.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLeaveApplicationStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_LeaveApplicationStatuses_StatusId",
                table: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "LeaveApplicationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_StatusId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "LeaveApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedById",
                table: "LeaveApplications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "LeaveApplications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LeaveApplications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeaveApplications");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "LeaveApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LeaveApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovedById = table.Column<Guid>(type: "uuid", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplicationStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_StatusId",
                table: "LeaveApplications",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_LeaveApplicationStatuses_StatusId",
                table: "LeaveApplications",
                column: "StatusId",
                principalTable: "LeaveApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
