using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoddingWiki_DataAcess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentBookToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Fluent_Book_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book");

            migrationBuilder.RenameTable(
                name: "Fluent_Book",
                newName: "Fluent_Books");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Fluent_Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Fluent_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Fluent_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books");

            migrationBuilder.RenameTable(
                name: "Fluent_Books",
                newName: "Fluent_Book");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Fluent_Book",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Fluent_Book_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
