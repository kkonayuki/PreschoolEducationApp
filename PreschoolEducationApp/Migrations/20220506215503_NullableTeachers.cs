using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PreschoolEducationApp.Migrations
{
    public partial class NullableTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_KidGroups_KidGroupId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "KidGroupId",
                table: "Teachers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_KidGroups_KidGroupId",
                table: "Teachers",
                column: "KidGroupId",
                principalTable: "KidGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_KidGroups_KidGroupId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "KidGroupId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_KidGroups_KidGroupId",
                table: "Teachers",
                column: "KidGroupId",
                principalTable: "KidGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
