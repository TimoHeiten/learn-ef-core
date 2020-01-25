using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leantraining.Data.Migrations
{
    public partial class AddedNameToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "Start",
                value: new DateTime(2020, 1, 25, 13, 41, 23, 399, DateTimeKind.Local).AddTicks(9930));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.CreateTable(
                name: "Temp_Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    End = table.Column<DateTime>(nullable: false),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql("INSERT INTO Temp_Products SELECT Id, Start, End, RoundId FROM Products;", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"0\"", true);
            migrationBuilder.Sql("DROP TABLE Products;", true);
            migrationBuilder.Sql("ALTER TABLE Temp_Products RENAME TO Products", true);
            migrationBuilder.Sql("PRAGMA foreign_keys=\"1\"", true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "Start",
                value: new DateTime(2020, 1, 10, 7, 56, 49, 369, DateTimeKind.Local).AddTicks(2480));
        }
    }
}
