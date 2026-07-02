using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthDemoApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddSellerStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "SellerProfiles",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SellerProfiles",
                newName: "IsApproved");
        }
    }
}
