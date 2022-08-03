using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryDays.Database.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HungryDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HungryDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HungryItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Store = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bought = table.Column<bool>(type: "bit", nullable: false),
                    HungryDayEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HungryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HungryItems_HungryDays_HungryDayEntityId",
                        column: x => x.HungryDayEntityId,
                        principalTable: "HungryDays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HungryItems_HungryDayEntityId",
                table: "HungryItems",
                column: "HungryDayEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HungryItems");

            migrationBuilder.DropTable(
                name: "HungryDays");
        }
    }
}
