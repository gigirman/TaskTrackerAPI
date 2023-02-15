using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerAPI.Migrations
{
    public partial class _4MigrationNullableAfterSafe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskStatusLookup",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TaskStatusLookup",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProjectStatusLookup",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProjectStatusLookup",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskStatusLookup");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TaskStatusLookup");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProjectStatusLookup");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProjectStatusLookup");
        }
    }
}
