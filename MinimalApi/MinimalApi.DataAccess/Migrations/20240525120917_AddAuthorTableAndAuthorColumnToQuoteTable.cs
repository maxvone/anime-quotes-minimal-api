using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorTableAndAuthorColumnToQuoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "QuoteContent",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuoteContent",
                table: "Quotes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "QuoteContent" },
                values: new object[] { 1, "Test Quote Content" });
        }
    }
}
