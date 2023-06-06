using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterLab.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class new_column_previous_close_price_time_BookMarkStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Previous_close_price_time",
                table: "BookMarkStocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Previous_close_price_time",
                table: "BookMarkStocks");
        }
    }
}
