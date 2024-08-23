using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspire.Pizzeria.Data.Migrations;

/// <inheritdoc />
public partial class PizzaOrders : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Orders",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                DeliveryAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                IsPrepared = table.Column<bool>(type: "bit", nullable: false),
                PreparationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDelivered = table.Column<bool>(type: "bit", nullable: false),
                DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Orders", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Pizzas",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pizzas", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "OrderPizza",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                PizzaId = table.Column<int>(type: "int", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OrderPizza", x => x.Id);
                table.ForeignKey(
                    name: "FK_OrderPizza_Orders_OrderId",
                    column: x => x.OrderId,
                    principalTable: "Orders",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_OrderPizza_Pizzas_PizzaId",
                    column: x => x.PizzaId,
                    principalTable: "Pizzas",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_OrderPizza_OrderId",
            table: "OrderPizza",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_OrderPizza_PizzaId",
            table: "OrderPizza",
            column: "PizzaId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "OrderPizza");

        migrationBuilder.DropTable(
            name: "Orders");

        migrationBuilder.DropTable(
            name: "Pizzas");
    }
}
