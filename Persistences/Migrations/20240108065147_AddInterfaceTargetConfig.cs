using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistences.Migrations
{
    /// <inheritdoc />
    public partial class AddInterfaceTargetConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "InterfaceTarget",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "InterfaceTarget",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Div",
                table: "InterfaceTarget",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Area2",
                table: "InterfaceTarget",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Area1",
                table: "InterfaceTarget",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "InterfaceTargetConfig",
                columns: table => new
                {
                    TargetIdx = table.Column<int>(type: "int", nullable: false),
                    ExtractType = table.Column<int>(type: "int", nullable: false),
                    ExtractFuncName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area1Index = table.Column<int>(type: "int", nullable: true),
                    Area2Index = table.Column<int>(type: "int", nullable: true),
                    Area3Index = table.Column<int>(type: "int", nullable: true),
                    AddressIndex = table.Column<int>(type: "int", nullable: true),
                    LatitudeIndex = table.Column<int>(type: "int", nullable: true),
                    LongitudeIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterfaceTargetConfig", x => x.TargetIdx);
                    table.ForeignKey(
                        name: "FK_InterfaceTargetConfig_InterfaceTarget_TargetIdx",
                        column: x => x.TargetIdx,
                        principalTable: "InterfaceTarget",
                        principalColumn: "Idx",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterfaceTargetConfig");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "InterfaceTarget",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "InterfaceTarget",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Div",
                table: "InterfaceTarget",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Area2",
                table: "InterfaceTarget",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Area1",
                table: "InterfaceTarget",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
