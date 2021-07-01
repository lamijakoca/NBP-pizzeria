using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class PizzaPizzaActual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaActual",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaActual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaActual_Pizzas_Id",
                        column: x => x.Id,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaActual");
        }
    }
}
