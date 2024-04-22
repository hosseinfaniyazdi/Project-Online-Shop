using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectNA.DataLayer.Migrations
{
    public partial class mig_Clothing3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatus_ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.DropColumn(
                name: "ClothingStatusStatusId",
                table: "Clothings");

            migrationBuilder.AddColumn<int>(
                name: "ClothingStatusesStatusId",
                table: "Clothings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_ClothingStatusesStatusId",
                table: "Clothings",
                column: "ClothingStatusesStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatus_ClothingStatusesStatusId",
                table: "Clothings",
                column: "ClothingStatusesStatusId",
                principalTable: "ClothingStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatus_ClothingStatusesStatusId",
                table: "Clothings");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_ClothingStatusesStatusId",
                table: "Clothings");

            migrationBuilder.DropColumn(
                name: "ClothingStatusesStatusId",
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
                name: "FK_Clothings_ClothingStatus_ClothingStatusStatusId",
                table: "Clothings",
                column: "ClothingStatusStatusId",
                principalTable: "ClothingStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
