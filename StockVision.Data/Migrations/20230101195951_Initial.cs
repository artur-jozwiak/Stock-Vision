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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskOrderBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidOrderBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidOrderBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockIndexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIndexes", x => x.Id);
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
                    AskOrderBookId = table.Column<int>(type: "int", nullable: true),
                    BidOrderBookId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IndexAssignment",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    StockIndexId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexAssignment", x => new { x.CompanyId, x.StockIndexId });
                    table.ForeignKey(
                        name: "FK_IndexAssignment_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndexAssignment_StockIndexes_StockIndexId",
                        column: x => x.StockIndexId,
                        principalTable: "StockIndexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoadTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AskOrderBookId = table.Column<int>(type: "int", nullable: false),
                    BidOrderBookId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderBooks_AskOrderBooks_AskOrderBookId",
                        column: x => x.AskOrderBookId,
                        principalTable: "AskOrderBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBooks_BidOrderBooks_BidOrderBookId",
                        column: x => x.BidOrderBookId,
                        principalTable: "BidOrderBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderBooks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorId",
                table: "Companies",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexAssignment_StockIndexId",
                table: "IndexAssignment",
                column: "StockIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_AskOrderBookId",
                table: "OrderBooks",
                column: "AskOrderBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_BidOrderBookId",
                table: "OrderBooks",
                column: "BidOrderBookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_CompanyId",
                table: "OrderBooks",
                column: "CompanyId");

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
                name: "IndexAssignment");

            migrationBuilder.DropTable(
                name: "OrderBooks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "StockIndexes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "AskOrderBooks");

            migrationBuilder.DropTable(
                name: "BidOrderBooks");

            migrationBuilder.DropTable(
                name: "Sectors");
        }
    }
}
