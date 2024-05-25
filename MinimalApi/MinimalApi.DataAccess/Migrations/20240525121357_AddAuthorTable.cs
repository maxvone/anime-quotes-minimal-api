using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuoteAuthorId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    QuoteAuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.QuoteAuthorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteAuthorId",
                table: "Quotes",
                column: "QuoteAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Authors_QuoteAuthorId",
                table: "Quotes",
                column: "QuoteAuthorId",
                principalTable: "Authors",
                principalColumn: "QuoteAuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Authors_QuoteAuthorId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuoteAuthorId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteAuthorId",
                table: "Quotes");
        }
    }
}
