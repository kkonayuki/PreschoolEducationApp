using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreschoolEducationApp.Migrations
{
    public partial class AddedDescriptionToKidGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "KidGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "KidGroups");
        }
    }
}
