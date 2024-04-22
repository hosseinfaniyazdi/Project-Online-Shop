using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectNA.DataLayer.Migrations
{
    public partial class mig_Clothing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTitle = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Clothings",
                columns: table => new
                {
                    ClothingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    SubGroup = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    ClothingTitle = table.Column<string>(maxLength: 450, nullable: false),
                    ClothingDescription = table.Column<string>(nullable: false),
                    ClothingPrice = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 600, nullable: true),
                    ClothingImageName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ClothingStatusStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothings", x => x.ClothingId);
                    table.ForeignKey(
                        name: "FK_Clothings_ClothingStatus_ClothingStatusStatusId",
                        column: x => x.ClothingStatusStatusId,
                        principalTable: "ClothingStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clothings_ClothingGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ClothingGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothings_ClothingGroups_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "ClothingGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_ClothingStatusStatusId",
                table: "Clothings",
                column: "ClothingStatusStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_GroupId",
                table: "Clothings",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_SubGroup",
                table: "Clothings",
                column: "SubGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clothings");

            migrationBuilder.DropTable(
                name: "ClothingStatus");
        }
    }
}
