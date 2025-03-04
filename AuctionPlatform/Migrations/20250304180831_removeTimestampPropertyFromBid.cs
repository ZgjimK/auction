using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionPlatform.Migrations
{
    /// <inheritdoc />
    public partial class removeTimestampPropertyFromBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Bids");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Timestamp",
                table: "Bids",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
