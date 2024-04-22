using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectNA.DataLayer.Migrations
{
    public partial class mig_Clothing7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_StatusId",
                table: "Clothings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatuses_StatusId",
                table: "Clothings",
                column: "StatusId",
                principalTable: "ClothingStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatuses_StatusId",
                table: "Clothings");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_StatusId",
                table: "Clothings");

            migrationBuilder.AddColumn<int>(
                name: "ClothingStatusStatusId",
                table: "Clothings",
                type: "int",
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
    }
}
