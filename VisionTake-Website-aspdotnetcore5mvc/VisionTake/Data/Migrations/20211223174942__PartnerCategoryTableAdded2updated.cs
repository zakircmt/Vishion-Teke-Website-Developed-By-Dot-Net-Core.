using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _PartnerCategoryTableAdded2updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPartners_TblPartnerCategories_TblPartnerCategoryID",
                table: "TblPartners");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_TblPartners_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPartners_TblPartnerCategories_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID",
                principalTable: "TblPartnerCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
