using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leantraining.Data.Migrations
{
    public partial class AddedRoundIdToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "End", "RoundId", "Start" },
                values: new object[] { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 1, 10, 7, 56, 49, 369, DateTimeKind.Local).AddTicks(2480) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);
        }
    }
}
