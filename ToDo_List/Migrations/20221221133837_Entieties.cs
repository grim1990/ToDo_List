using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo_List.Migrations
{
    public partial class Entieties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShoppingId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChoresId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cleaning = table.Column<string>(type: "TEXT", nullable: true),
                    Loundry = table.Column<string>(type: "TEXT", nullable: true),
                    Cooking = table.Column<string>(type: "TEXT", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chores_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroceriesId = table.Column<int>(type: "INTEGER", nullable: true),
                    OtherProductsId = table.Column<int>(type: "INTEGER", nullable: true),
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoppings_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkName = table.Column<string>(type: "TEXT", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ToDoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroceryName = table.Column<string>(type: "TEXT", nullable: false),
                    GroceryAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    GroceryPrice = table.Column<float>(type: "REAL", nullable: false),
                    ShoppingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groceries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groceries_Shoppings_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shoppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OtherProductsName = table.Column<string>(type: "TEXT", nullable: false),
                    OtherProductsAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    OtherProductsPrice = table.Column<float>(type: "REAL", nullable: false),
                    ShoppingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherProducts_Shoppings_ShoppingId",
                        column: x => x.ShoppingId,
                        principalTable: "Shoppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_ToDoId",
                table: "Chores",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ShoppingId",
                table: "Groceries",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherProducts_ShoppingId",
                table: "OtherProducts",
                column: "ShoppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoppings_ToDoId",
                table: "Shoppings",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ToDoId",
                table: "Works",
                column: "ToDoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "OtherProducts");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Shoppings");

            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}
