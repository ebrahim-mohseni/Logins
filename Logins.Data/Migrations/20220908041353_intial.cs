using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logins.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    LookupId = table.Column<int>(type: "int", nullable: false),
                    LookupTypeId = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => new { x.LookupId, x.LookupTypeId });
                });

            migrationBuilder.CreateTable(
                name: "LookupType",
                columns: table => new
                {
                    LookupTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupType", x => x.LookupTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignupDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 9, 8, 8, 43, 53, 218, DateTimeKind.Local).AddTicks(5283)),
                    Locked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "LookupId", "LookupTypeId", "Caption" },
                values: new object[,]
                {
                    { 1, 1, "Admin" },
                    { 1, 2, "CEO" },
                    { 2, 1, "Default" },
                    { 2, 2, "CMO" },
                    { 3, 2, "HR Manager" },
                    { 4, 2, "Sales Assistant" },
                    { 5, 2, "HR Assistant" },
                    { 6, 2, "IT Manager" }
                });

            migrationBuilder.InsertData(
                table: "LookupType",
                columns: new[] { "LookupTypeId", "Caption" },
                values: new object[,]
                {
                    { 1, "UserType" },
                    { 2, "Position" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BirthDate", "Email", "FirstName", "HireDate", "LastName", "Password", "PositionId", "SignupDate", "UserTypeId" },
                values: new object[] { -1, "", new DateTime(2022, 9, 8, 8, 43, 53, 218, DateTimeKind.Local).AddTicks(6746), "mahdi@goodlawsoftware.co.uk", "mahdi", new DateTime(2022, 9, 8, 8, 43, 53, 218, DateTimeKind.Local).AddTicks(6747), "joveyni", "47cd985a73d1af0f0ee2283437fb0176", 0, new DateTime(2022, 9, 8, 8, 43, 53, 218, DateTimeKind.Local).AddTicks(6737), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "LookupType");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
