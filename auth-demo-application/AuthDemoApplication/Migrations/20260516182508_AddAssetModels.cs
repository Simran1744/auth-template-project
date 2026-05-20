using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthDemoApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    LongDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalDownloads = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    ReviewCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SellerProfileId = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_SellerProfiles_SellerProfileId",
                        column: x => x.SellerProfileId,
                        principalTable: "SellerProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetCompatibilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequiresTool = table.Column<string>(type: "TEXT", nullable: false),
                    CompatibleGameVersion = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCompatibilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetCompatibilities_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    FileUrl = table.Column<string>(type: "TEXT", nullable: false),
                    FileSizeBytes = table.Column<long>(type: "INTEGER", nullable: false),
                    FileFormat = table.Column<string>(type: "TEXT", nullable: false),
                    VersionLabel = table.Column<string>(type: "TEXT", nullable: true),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetFiles_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetPreviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MediaType = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    Caption = table.Column<string>(type: "TEXT", nullable: true),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPreviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetPreviews_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetTags_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetCompatibilities_AssetId",
                table: "AssetCompatibilities",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetFiles_AssetId",
                table: "AssetFiles",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPreviews_AssetId",
                table: "AssetPreviews",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CategoryId",
                table: "Assets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_GameId",
                table: "Assets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SellerProfileId",
                table: "Assets",
                column: "SellerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetTags_AssetId",
                table: "AssetTags",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetCompatibilities");

            migrationBuilder.DropTable(
                name: "AssetFiles");

            migrationBuilder.DropTable(
                name: "AssetPreviews");

            migrationBuilder.DropTable(
                name: "AssetTags");

            migrationBuilder.DropTable(
                name: "Assets");
        }
    }
}
