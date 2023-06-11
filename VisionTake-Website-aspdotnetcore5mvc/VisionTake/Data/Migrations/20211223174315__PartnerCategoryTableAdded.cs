using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _PartnerCategoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TblPartnerCategoryID",
                table: "TblPartners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblPartnerCategroyID",
                table: "TblPartners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblPartnerCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPartnerCategory", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPartners_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPartners_TblPartnerCategory_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID",
                principalTable: "TblPartnerCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPartners_TblPartnerCategory_TblPartnerCategoryID",
                table: "TblPartners");

            migrationBuilder.DropTable(
                name: "TblPartnerCategory");

            migrationBuilder.DropIndex(
                name: "IX_TblPartners_TblPartnerCategoryID",
                table: "TblPartners");

            migrationBuilder.DropColumn(
                name: "TblPartnerCategoryID",
                table: "TblPartners");

            migrationBuilder.DropColumn(
                name: "TblPartnerCategroyID",
                table: "TblPartners");
        }
    }
}
