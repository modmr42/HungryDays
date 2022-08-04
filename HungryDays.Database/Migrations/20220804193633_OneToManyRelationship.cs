using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryDays.Database.Migrations
{
    public partial class OneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HungryItems_HungryDays_HungryDayEntityId",
                table: "HungryItems");

            migrationBuilder.DropIndex(
                name: "IX_HungryItems_HungryDayEntityId",
                table: "HungryItems");

            migrationBuilder.DropColumn(
                name: "HungryDayEntityId",
                table: "HungryItems");

            migrationBuilder.AddColumn<int>(
                name: "HungryDayID",
                table: "HungryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HungryItems_HungryDayID",
                table: "HungryItems",
                column: "HungryDayID");

            migrationBuilder.AddForeignKey(
                name: "FK_HungryItems_HungryDays_HungryDayID",
                table: "HungryItems",
                column: "HungryDayID",
                principalTable: "HungryDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HungryItems_HungryDays_HungryDayID",
                table: "HungryItems");

            migrationBuilder.DropIndex(
                name: "IX_HungryItems_HungryDayID",
                table: "HungryItems");

            migrationBuilder.DropColumn(
                name: "HungryDayID",
                table: "HungryItems");

            migrationBuilder.AddColumn<int>(
                name: "HungryDayEntityId",
                table: "HungryItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HungryItems_HungryDayEntityId",
                table: "HungryItems",
                column: "HungryDayEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HungryItems_HungryDays_HungryDayEntityId",
                table: "HungryItems",
                column: "HungryDayEntityId",
                principalTable: "HungryDays",
                principalColumn: "Id");
        }
    }
}
