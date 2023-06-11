using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisionTake.Data.Migrations
{
    public partial class _sliderTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAbouts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAbouts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblEvent",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEvent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblNewses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblNewses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblPartners",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPartners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblPatents",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPatents", x => x.ID);
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
                name: "TblProducts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblSliders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSliders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblSubCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblSubCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblTags",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTags", x => x.ID);
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
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPartnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    TblProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    TblSliderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "SubCategoryPictures",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblSubCategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblPictureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TagNewses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblTagID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TblNewsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNewses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TagNewses_TblNewses_TblNewsID",
                        column: x => x.TblNewsID,
                        principalTable: "TblNewses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagNewses_TblTags_TblTagID",
                        column: x => x.TblTagID,
                        principalTable: "TblTags",
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

            migrationBuilder.CreateIndex(
                name: "IX_TagNewses_TblNewsID",
                table: "TagNewses",
                column: "TblNewsID");

            migrationBuilder.CreateIndex(
                name: "IX_TagNewses_TblTagID",
                table: "TagNewses",
                column: "TblTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TagNewses");

            migrationBuilder.DropTable(
                name: "TblPatents");

            migrationBuilder.DropTable(
                name: "TblAbouts");

            migrationBuilder.DropTable(
                name: "TblCategories");

            migrationBuilder.DropTable(
                name: "TblEvent");

            migrationBuilder.DropTable(
                name: "TblPartners");

            migrationBuilder.DropTable(
                name: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblSliders");

            migrationBuilder.DropTable(
                name: "TblPictures");

            migrationBuilder.DropTable(
                name: "TblSubCategories");

            migrationBuilder.DropTable(
                name: "TblNewses");

            migrationBuilder.DropTable(
                name: "TblTags");
        }
    }
}
