using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HungryDays.Database.Migrations
{
    public partial class AddUserIdToHungryDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HungryUserId",
                table: "HungryDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HungryUserId",
                table: "HungryDays");
        }
    }
}
