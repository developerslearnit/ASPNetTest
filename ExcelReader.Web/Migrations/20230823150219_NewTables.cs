using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelReader.Web.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OrgNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Address4 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Town = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Unknown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Id",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_Id",
                table: "Organisations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
