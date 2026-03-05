using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerPOSApplication.Migrations
{
    /// <inheritdoc />
    public partial class OrderNameChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AfterTaxTotal",
                table: "Orders",
                newName: "TaxAmount");

            migrationBuilder.RenameColumn(
                name: "AfterDiscountTotal",
                table: "Orders",
                newName: "PreTaxTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TaxAmount",
                table: "Orders",
                newName: "AfterTaxTotal");

            migrationBuilder.RenameColumn(
                name: "PreTaxTotal",
                table: "Orders",
                newName: "AfterDiscountTotal");
        }
    }
}
