using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber_Value",
                schema: "dbo",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email_Value",
                schema: "dbo",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "BankAccountNumber_Value",
                schema: "dbo",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNumber",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountNumber",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Customers",
                newName: "PhoneNumber_Value");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "dbo",
                table: "Customers",
                newName: "Email_Value");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Customers",
                newName: "BankAccountNumber_Value");
        }
    }
}
