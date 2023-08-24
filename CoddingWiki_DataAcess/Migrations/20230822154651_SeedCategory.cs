using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingWiki_DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO Categories Values ('Cat 1')");
            migrationBuilder.Sql("Insert INTO Categories Values ('Cat 2')");
            migrationBuilder.Sql("Insert INTO Categories Values ('Cat 3')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
