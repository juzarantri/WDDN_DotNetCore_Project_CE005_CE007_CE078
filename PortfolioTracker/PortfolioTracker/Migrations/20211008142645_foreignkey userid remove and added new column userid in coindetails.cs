using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTracker.Migrations
{
    public partial class foreignkeyuseridremoveandaddednewcolumnuseridincoindetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinDetails_AspNetUsers_userid",
                table: "CoinDetails");

            migrationBuilder.DropIndex(
                name: "IX_CoinDetails_userid",
                table: "CoinDetails");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "CoinDetails",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "CoinDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CoinDetails_userid",
                table: "CoinDetails",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinDetails_AspNetUsers_userid",
                table: "CoinDetails",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
