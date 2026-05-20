using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthDemoApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddSellerProfile2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SellerProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", nullable: true),
                    NexusModsProfileUrl = table.Column<string>(type: "TEXT", nullable: true),
                    GitHubProfileUrl = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StripeAccountId = table.Column<string>(type: "TEXT", nullable: true),
                    IsPayoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalSales = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalRevenue = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerProfiles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerProfiles_ApplicationUserId",
                table: "SellerProfiles",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerProfiles");
        }
    }
}
