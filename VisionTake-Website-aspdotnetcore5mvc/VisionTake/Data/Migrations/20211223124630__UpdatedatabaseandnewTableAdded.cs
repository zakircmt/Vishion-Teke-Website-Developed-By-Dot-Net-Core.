using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _UpdatedatabaseandnewTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPictures");

            migrationBuilder.DropTable(
                name: "CategoryPictures");

            migrationBuilder.DropTable(
                name: "CategorySubCategories");

            migrationBuilder.DropTable(
                name: "EventPictures");

            migrationBuilder.DropTable(
                name: "NewsPictures");

            migrationBuilder.DropTable(
                name: "PartnerPictures");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "SliderPictures");

            migrationBuilder.DropTable(
                name: "SubCategoryPictures");

            migrationBuilder.DropTable(
                name: "TblPictures");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblTags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblSubCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblSliders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblReviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblProducts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblPatents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblPartners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblNewses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblEvent",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblContacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TblAbouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "TagNewses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TblMissions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblMissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblTeams",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTeams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblVisions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVisions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblMissions");

            migrationBuilder.DropTable(
                name: "TblTeams");

            migrationBuilder.DropTable(
                name: "TblVisions");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblTags");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblSubCategories");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblSliders");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblReviews");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblProducts");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblPatents");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblPartners");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblNewses");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblEvent");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblContacts");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblCategories");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblAddresses");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TblAbouts");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TagNewses");

            migrationBuilder.CreateTable(
                name: "CategorySubCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TblSubCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorySubCategories_TblCategories_TblCategoryID",
                        column: x => x.TblCategoryID,
                        principalTable: "TblCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategorySubCategories_TblSubCategories_TblSubCategoryID",
                        column: x => x.TblSubCategoryID,
                        principalTable: "TblSubCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPictures", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AboutPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblAboutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AboutPictures_TblAbouts_TblAboutID",
                        column: x => x.TblAboutID,
                        principalTable: "TblAbouts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryPictures_TblCategories_TblCategoryID",
                        column: x => x.TblCategoryID,
                        principalTable: "TblCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblEventID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPictures_TblEvent_TblEventID",
                        column: x => x.TblEventID,
                        principalTable: "TblEvent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblNewsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NewsPictures_TblNewses_TblNewsID",
                        column: x => x.TblNewsID,
                        principalTable: "TblNewses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartnerPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PartnerPictures_TblPartners_TblPartnerID",
                        column: x => x.TblPartnerID,
                        principalTable: "TblPartners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPictures_TblProducts_TblProductID",
                        column: x => x.TblProductID,
                        principalTable: "TblProducts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblSliderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SliderPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SliderPictures_TblSliders_TblSliderID",
                        column: x => x.TblSliderID,
                        principalTable: "TblSliders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblSubCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoryPictures_TblPictures_TblPictureID",
                        column: x => x.TblPictureID,
                        principalTable: "TblPictures",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryPictures_TblSubCategories_TblSubCategoryID",
                        column: x => x.TblSubCategoryID,
                        principalTable: "TblSubCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutPictures_TblAboutID",
                table: "AboutPictures",
                column: "TblAboutID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutPictures_TblPictureID",
                table: "AboutPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPictures_TblCategoryID",
                table: "CategoryPictures",
                column: "TblCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPictures_TblPictureID",
                table: "CategoryPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubCategories_TblCategoryID",
                table: "CategorySubCategories",
                column: "TblCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubCategories_TblSubCategoryID",
                table: "CategorySubCategories",
                column: "TblSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPictures_TblEventID",
                table: "EventPictures",
                column: "TblEventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPictures_TblPictureID",
                table: "EventPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPictures_TblNewsID",
                table: "NewsPictures",
                column: "TblNewsID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPictures_TblPictureID",
                table: "NewsPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerPictures_TblPartnerID",
                table: "PartnerPictures",
                column: "TblPartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerPictures_TblPictureID",
                table: "PartnerPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_TblPictureID",
                table: "ProductPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_TblProductID",
                table: "ProductPictures",
                column: "TblProductID");

            migrationBuilder.CreateIndex(
                name: "IX_SliderPictures_TblPictureID",
                table: "SliderPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_SliderPictures_TblSliderID",
                table: "SliderPictures",
                column: "TblSliderID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryPictures_TblPictureID",
                table: "SubCategoryPictures",
                column: "TblPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryPictures_TblSubCategoryID",
                table: "SubCategoryPictures",
                column: "TblSubCategoryID");
        }
    }
}
