using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Store.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsActivateDeafultTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActivate",
                table: "Custumer",
                type: "BIT",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "BIT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
