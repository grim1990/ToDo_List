using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo_List.Migrations
{
    public partial class ToDoWithCreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorGuid",
                table: "ToDos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "ToDos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_CreatorId",
                table: "ToDos",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_CreatorId",
                table: "ToDos",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_CreatorId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_CreatorId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "CreatorGuid",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ToDos");
        }
    }
}
