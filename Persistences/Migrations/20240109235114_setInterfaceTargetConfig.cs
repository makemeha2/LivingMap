using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistences.Migrations
{
    /// <inheritdoc />
    public partial class setInterfaceTargetConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExtractType",
                table: "InterfaceTargetConfig",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExtractType",
                table: "InterfaceTargetConfig",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
