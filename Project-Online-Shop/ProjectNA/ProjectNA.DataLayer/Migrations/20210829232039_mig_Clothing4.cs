using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectNA.DataLayer.Migrations
{
    public partial class mig_Clothing4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatus_ClothingStatusesStatusId",
                table: "Clothings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingStatus",
                table: "ClothingStatus");

            migrationBuilder.RenameTable(
                name: "ClothingStatus",
                newName: "ClothingStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingStatuses",
                table: "ClothingStatuses",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatuses_ClothingStatusesStatusId",
                table: "Clothings",
                column: "ClothingStatusesStatusId",
                principalTable: "ClothingStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingStatuses_ClothingStatusesStatusId",
                table: "Clothings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClothingStatuses",
                table: "ClothingStatuses");

            migrationBuilder.RenameTable(
                name: "ClothingStatuses",
                newName: "ClothingStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClothingStatus",
                table: "ClothingStatus",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingStatus_ClothingStatusesStatusId",
                table: "Clothings",
                column: "ClothingStatusesStatusId",
                principalTable: "ClothingStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
