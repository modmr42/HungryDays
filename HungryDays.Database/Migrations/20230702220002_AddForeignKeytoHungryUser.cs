using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryDays.Database.Migrations
{
    public partial class AddForeignKeytoHungryUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HungryUserId",
                table: "HungryDays",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_HungryDays_HungryUserId",
                table: "HungryDays",
                column: "HungryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HungryDays_AspNetUsers_HungryUserId",
                table: "HungryDays",
                column: "HungryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HungryDays_AspNetUsers_HungryUserId",
                table: "HungryDays");

            migrationBuilder.DropIndex(
                name: "IX_HungryDays_HungryUserId",
                table: "HungryDays");

            migrationBuilder.AlterColumn<string>(
                name: "HungryUserId",
                table: "HungryDays",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
