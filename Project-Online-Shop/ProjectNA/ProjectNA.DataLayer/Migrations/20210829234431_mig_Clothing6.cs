using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectNA.DataLayer.Migrations
{
    public partial class mig_Clothing6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatuses_NeStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_NeStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropColumn(
                name: "NeStatusStatusId",
                table: "Clothings");

            migrationBuilder.AddColumn<int>(
                name: "ClothingStatusStatusId",
                table: "Clothings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_ClothingStatusStatusId",
                table: "Clothings",
                column: "ClothingStatusStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatuses_ClothingStatusStatusId",
                table: "Clothings",
                column: "ClothingStatusStatusId",
                principalTable: "ClothingStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatuses_ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropColumn(
                name: "ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.AddColumn<int>(
                name: "NeStatusStatusId",
                table: "Clothings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_NeStatusStatusId",
                table: "Clothings",
                column: "NeStatusStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatuses_NeStatusStatusId",
                table: "Clothings",
                column: "NeStatusStatusId",
                principalTable: "ClothingStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
