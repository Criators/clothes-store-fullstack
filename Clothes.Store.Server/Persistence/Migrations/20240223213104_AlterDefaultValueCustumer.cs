using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Store.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterDefaultValueCustumer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CriationDateHourTemp",
                table: "Custumer",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.Sql("UPDATE Custumer SET CriationDateHourTemp = CriationDateHour");

            migrationBuilder.DropColumn(
                name: "CriationDateHour",
                table: "Custumer");

            migrationBuilder.RenameColumn(
                name: "CriationDateHourTemp",
                table: "Custumer",
                newName: "CriationDateHour");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActivate",
                table: "Custumer",
                type: "BIT",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "BIT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Custumer",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActivate",
                table: "Custumer",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriationDateHour",
                table: "Custumer",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
