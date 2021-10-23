using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioTracker.Migrations
{
    public partial class MadeForeignKeyInPortfolioDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDetails_UserDetails_userid",
                table: "PortfolioDetails");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioDetails_userid",
                table: "PortfolioDetails");

            migrationBuilder.AlterColumn<string>(
                name: "userid",
                table: "PortfolioDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDetails_userid",
                table: "PortfolioDetails",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDetails_AspNetUsers_userid",
                table: "PortfolioDetails",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioDetails_AspNetUsers_userid",
                table: "PortfolioDetails");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioDetails_userid",
                table: "PortfolioDetails");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "PortfolioDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioDetails_userid",
                table: "PortfolioDetails",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioDetails_UserDetails_userid",
                table: "PortfolioDetails",
                column: "userid",
                principalTable: "UserDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
