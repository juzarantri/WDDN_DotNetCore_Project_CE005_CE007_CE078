using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTracker.Migrations
{
    public partial class cointablenamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioDetails");

            migrationBuilder.CreateTable(
                name: "CoinDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coin = table.Column<string>(nullable: false),
                    qyantity = table.Column<double>(nullable: false),
                    buyingprice = table.Column<double>(nullable: false),
                    totalinvested = table.Column<double>(nullable: false),
                    userid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoinDetails_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinDetails_userid",
                table: "CoinDetails",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinDetails");

            migrationBuilder.CreateTable(
                name: "PortfolioDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buyingprice = table.Column<double>(type: "float", nullable: false),
                    coin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qyantity = table.Column<double>(type: "float", nullable: false),
                    totalinvested = table.Column<double>(type: "float", nullable: false),
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_PortfolioDetails_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDetails_userid",
                table: "PortfolioDetails",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");
        }
    }
}
