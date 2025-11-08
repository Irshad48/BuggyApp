using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuggyAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInvoiceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "CustomerName" },
                values: new object[] { 1, "John Doe" }
            );

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "ItemID", "InvoiceID", "Name", "Price" },
                values: new object[] { 1, 1, "Widget A", 19.99m }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceItems",
                keyColumn: "ItemID",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceID",
                keyValue: 1
            );
        }

    }
}
