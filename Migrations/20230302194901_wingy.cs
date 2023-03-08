using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WingTruck.Migrations
{
    public partial class wingy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToAddr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Order_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "Order",
                        principalColumn: "OrderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Executive",
                columns: table => new
                {
                    ExecutiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutiveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTypeId = table.Column<int>(type: "int", nullable: false),
                    PhnNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executive", x => x.ExecutiveId);
                    table.ForeignKey(
                        name: "FK_Executive_Order_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "Order",
                        principalColumn: "OrderTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_OrderTypeId",
                table: "Customer",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Executive_OrderTypeId",
                table: "Executive",
                column: "OrderTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Executive");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
