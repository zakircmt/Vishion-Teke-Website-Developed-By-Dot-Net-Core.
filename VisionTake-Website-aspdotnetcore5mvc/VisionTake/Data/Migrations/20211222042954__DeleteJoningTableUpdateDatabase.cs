using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _DeleteJoningTableUpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblSubCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblCategoryID",
                table: "TblSubCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblSliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TblCategoryID",
                table: "TblProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TblSubCategoryID",
                table: "TblProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblPatents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblPartners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblNewses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblEvent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TblAbouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "TagNewses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblSubCategories_TblCategoryID",
                table: "TblSubCategories",
                column: "TblCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_TblCategoryID",
                table: "TblProducts",
                column: "TblCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_TblSubCategoryID",
                table: "TblProducts",
                column: "TblSubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblCategories_TblCategoryID",
                table: "TblProducts",
                column: "TblCategoryID",
                principalTable: "TblCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblProducts_TblSubCategories_TblSubCategoryID",
                table: "TblProducts",
                column: "TblSubCategoryID",
                principalTable: "TblSubCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblSubCategories_TblCategories_TblCategoryID",
                table: "TblSubCategories",
                column: "TblCategoryID",
                principalTable: "TblCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblCategories_TblCategoryID",
                table: "TblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblProducts_TblSubCategories_TblSubCategoryID",
                table: "TblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_TblSubCategories_TblCategories_TblCategoryID",
                table: "TblSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_TblSubCategories_TblCategoryID",
                table: "TblSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_TblCategoryID",
                table: "TblProducts");

            migrationBuilder.DropIndex(
                name: "IX_TblProducts_TblSubCategoryID",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblSubCategories");

            migrationBuilder.DropColumn(
                name: "TblCategoryID",
                table: "TblSubCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblSliders");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "TblCategoryID",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "TblSubCategoryID",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblPatents");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblPartners");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblNewses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblEvent");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblCategories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TblAbouts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "TagNewses");
        }
    }
}
