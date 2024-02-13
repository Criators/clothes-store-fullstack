using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Store.Server.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custumer",
                columns: table => new
                {
                    CustumerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustumerName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Password = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CriationDateHour = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UserType = table.Column<int>(type: "INT", nullable: false),
                    IsActivate = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custumer", x => x.CustumerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Custumer");
        }
    }
}
