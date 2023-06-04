using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpusMastery.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Companies",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Companies",
                newName: "ContactEmail");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "Companies",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Companies",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "text",
                nullable: true);
        }
    }
}
