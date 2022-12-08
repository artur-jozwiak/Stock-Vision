using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockVision.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AskOrderBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskOrderBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidOrderBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidOrderBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AskOrderBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BidOrderBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullOrderBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullOrderBooks_AskOrderBooks_AskOrderBookId",
                        column: x => x.AskOrderBookId,
                        principalTable: "AskOrderBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FullOrderBooks_BidOrderBooks_BidOrderBookId",
                        column: x => x.BidOrderBookId,
                        principalTable: "BidOrderBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,4)", precision: 9, scale: 4, nullable: false),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    OrdersValue = table.Column<decimal>(type: "decimal(13,4)", precision: 13, scale: 4, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SharePercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    AskOrderBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BidOrderBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AskOrderBooks_AskOrderBookId",
                        column: x => x.AskOrderBookId,
                        principalTable: "AskOrderBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_BidOrderBooks_BidOrderBookId",
                        column: x => x.BidOrderBookId,
                        principalTable: "BidOrderBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FullOrderBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_FullOrderBooks_FullOrderBookId",
                        column: x => x.FullOrderBookId,
                        principalTable: "OrderBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FullOrderBookId",
                table: "Companies",
                column: "OrderBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullOrderBooks_AskOrderBookId",
                table: "OrderBooks",
                column: "AskOrderBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullOrderBooks_BidOrderBookId",
                table: "OrderBooks",
                column: "BidOrderBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AskOrderBookId",
                table: "Orders",
                column: "AskOrderBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BidOrderBookId",
                table: "Orders",
                column: "BidOrderBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderBooks");

            migrationBuilder.DropTable(
                name: "AskOrderBooks");

            migrationBuilder.DropTable(
                name: "BidOrderBooks");
        }
    }
}
