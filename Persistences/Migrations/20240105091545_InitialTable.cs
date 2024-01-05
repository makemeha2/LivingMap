using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistences.Migrations
{
    /// <inheritdoc />
    public partial class InitialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonCode",
                columns: table => new
                {
                    CodeGroup = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseYn = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonCode", x => new { x.CodeGroup, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "InterfaceTarget",
                columns: table => new
                {
                    Idx = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Div = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedIf = table.Column<bool>(type: "bit", nullable: false),
                    RegistDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Ifdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceTarget", x => x.Idx);
                });

            migrationBuilder.CreateTable(
                name: "LocationInfo",
                columns: table => new
                {
                    Div = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Area1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Area2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Area3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    UseYN = table.Column<bool>(type: "bit", nullable: false),
                    RegistDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInfo", x => new { x.Div, x.Address });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonCode");

            migrationBuilder.DropTable(
                name: "InterfaceTarget");

            migrationBuilder.DropTable(
                name: "LocationInfo");
        }
    }
}
