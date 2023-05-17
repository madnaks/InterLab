using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterLab.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class changetablenameBookMarkStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_bookMarkStocks",
                table: "bookMarkStocks");

            migrationBuilder.RenameTable(
                name: "bookMarkStocks",
                newName: "BookMarkStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookMarkStocks",
                table: "BookMarkStocks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookMarkStocks",
                table: "BookMarkStocks");

            migrationBuilder.RenameTable(
                name: "BookMarkStocks",
                newName: "bookMarkStocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookMarkStocks",
                table: "bookMarkStocks",
                column: "Id");
        }
    }
}
