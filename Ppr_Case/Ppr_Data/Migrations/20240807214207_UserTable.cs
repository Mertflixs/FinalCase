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

            migrationBuilder.CreateTable(
                name: "Coupon",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponId = table.Column<long>(type: "bigint", nullable: false),
                    CouponName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CouponAmount = table.Column<int>(type: "int", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    CartAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CouponAmount = table.Column<int>(type: "int", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointsAmount = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductFeatures = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RewardPercentage = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    MaxRewardAmount = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    InsertUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
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

            migrationBuilder.DropTable(
                name: "Coupon",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");
        }
    }
}
