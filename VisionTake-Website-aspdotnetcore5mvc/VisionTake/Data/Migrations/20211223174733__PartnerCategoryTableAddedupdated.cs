using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _PartnerCategoryTableAddedupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPartners_TblPartnerCategory_TblPartnerCategoryID",
                table: "TblPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblPartnerCategory",
                table: "TblPartnerCategory");

            migrationBuilder.RenameTable(
                name: "TblPartnerCategory",
                newName: "TblPartnerCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblPartnerCategories",
                table: "TblPartnerCategories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPartners_TblPartnerCategories_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID",
                principalTable: "TblPartnerCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblPartners_TblPartnerCategories_TblPartnerCategoryID",
                table: "TblPartners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblPartnerCategories",
                table: "TblPartnerCategories");

            migrationBuilder.RenameTable(
                name: "TblPartnerCategories",
                newName: "TblPartnerCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblPartnerCategory",
                table: "TblPartnerCategory",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblPartners_TblPartnerCategory_TblPartnerCategoryID",
                table: "TblPartners",
                column: "TblPartnerCategoryID",
                principalTable: "TblPartnerCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
