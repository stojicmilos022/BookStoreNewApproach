using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingWiki_DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentPublisherAndRenameFluentAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors");

            migrationBuilder.RenameTable(
                name: "Fluent_Authors",
                newName: "Fluent_Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author",
                column: "Author_Id");

            migrationBuilder.CreateTable(
                name: "Fluent_Publisher",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publisher", x => x.Publisher_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Fluent_Author_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Fluent_Author_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropTable(
                name: "Fluent_Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author");

            migrationBuilder.RenameTable(
                name: "Fluent_Author",
                newName: "Fluent_Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
