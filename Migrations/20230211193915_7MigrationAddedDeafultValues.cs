using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTrackerAPI.Migrations
{
    public partial class _7MigrationAddedDeafultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatusLookup_CurrentStatusId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentStatusId",
                table: "Projects",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatusLookup_CurrentStatusId",
                table: "Projects",
                column: "CurrentStatusId",
                principalTable: "ProjectStatusLookup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatusLookup_CurrentStatusId",
                table: "Projects");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentStatusId",
                table: "Projects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatusLookup_CurrentStatusId",
                table: "Projects",
                column: "CurrentStatusId",
                principalTable: "ProjectStatusLookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
