using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreschoolEducationApp.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_KidGroups_KidGroupId",
                table: "Kids");

            migrationBuilder.AlterColumn<int>(
                name: "KidGroupId",
                table: "Kids",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_KidGroups_KidGroupId",
                table: "Kids",
                column: "KidGroupId",
                principalTable: "KidGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kids_KidGroups_KidGroupId",
                table: "Kids");

            migrationBuilder.AlterColumn<int>(
                name: "KidGroupId",
                table: "Kids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kids_KidGroups_KidGroupId",
                table: "Kids",
                column: "KidGroupId",
                principalTable: "KidGroups",
                principalColumn: "Id");
        }
    }
}
