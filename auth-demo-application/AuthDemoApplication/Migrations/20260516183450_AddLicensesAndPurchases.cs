using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthDemoApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddLicensesAndPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AllowsRedistribution = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowsCommercialUse = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowsModification = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowsResale = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetLicenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LicenseTypeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLicenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetLicenses_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetLicenses_LicenseTypes_LicenseTypeId",
                        column: x => x.LicenseTypeId,
                        principalTable: "LicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    PlatformFee = table.Column<decimal>(type: "TEXT", nullable: false),
                    SellerPayout = table.Column<decimal>(type: "TEXT", nullable: false),
                    StripePaymentIntentId = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BuyerId = table.Column<string>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetLicenseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_AssetLicenses_AssetLicenseId",
                        column: x => x.AssetLicenseId,
                        principalTable: "AssetLicenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Downloads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    UserAgent = table.Column<string>(type: "TEXT", nullable: true),
                    DownloadedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PurchaseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetFileId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downloads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Downloads_AssetFiles_AssetFileId",
                        column: x => x.AssetFileId,
                        principalTable: "AssetFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Downloads_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenses_AssetId",
                table: "AssetLicenses",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetLicenses_LicenseTypeId",
                table: "AssetLicenses",
                column: "LicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Downloads_AssetFileId",
                table: "Downloads",
                column: "AssetFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Downloads_PurchaseId",
                table: "Downloads",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_AssetId",
                table: "Purchases",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_AssetLicenseId",
                table: "Purchases",
                column: "AssetLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerId",
                table: "Purchases",
                column: "BuyerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "AssetLicenses");

            migrationBuilder.DropTable(
                name: "LicenseTypes");
        }
    }
}
