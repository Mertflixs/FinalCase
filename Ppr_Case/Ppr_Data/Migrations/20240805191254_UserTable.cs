using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ppr_Data.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountRole = table.Column<int>(type: "int", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    AccountPoint = table.Column<int>(type: "int", nullable: false),
                    AccountWallet = table.Column<int>(type: "int", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountEmail",
                schema: "dbo",
                table: "Account",
                column: "AccountEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountNumber",
                schema: "dbo",
                table: "Account",
                column: "AccountNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
