using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Store.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsActivateDeafultTrue2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActivate",
                table: "Custumer",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActivate",
                table: "Custumer",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: false);
        }
    }
}
