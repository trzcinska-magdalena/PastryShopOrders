using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PastryShopOrders.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "pastries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pastries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FulfilledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_orders_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_employees_ClientID",
                        column: x => x.ClientID,
                        principalTable: "employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Pastry",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    PastryID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Comme = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Pastry", x => new { x.OrderID, x.PastryID });
                    table.ForeignKey(
                        name: "FK_Order_Pastry_orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Pastry_pastries_PastryID",
                        column: x => x.PastryID,
                        principalTable: "pastries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "clients",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Anna", "Kowalska" },
                    { 2, "Karol", "Suska" },
                    { 3, "Anna", "Sowińska" }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Michał", "Rataj" },
                    { 2, "Oliwia", "Kozioł" },
                    { 3, "Ewa", "Wróbel" }
                });

            migrationBuilder.InsertData(
                table: "pastries",
                columns: new[] { "ID", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Ciasto czekoladowe", 23.399999999999999, "Czekoladowe" },
                    { 2, "Ciasto truskawkowo-śmietankowe", 27.899999999999999, "Owocowe" },
                    { 3, "Ciasto czekoladowo-karmelowe", 34.5, "Czekoladowe" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "ID", "AcceptedAt", "ClientID", "Comments", "EmployeeID", "FulfilledAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "text-Comments", 2, null },
                    { 2, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "text-Comments22", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Order_Pastry",
                columns: new[] { "OrderID", "PastryID", "Amount", "Comme" },
                values: new object[,]
                {
                    { 1, 1, 3, "comme-text" },
                    { 2, 2, 2, "comme-text2" },
                    { 3, 3, 1, "comme-text3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Pastry_PastryID",
                table: "Order_Pastry",
                column: "PastryID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ClientID",
                table: "orders",
                column: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Pastry");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "pastries");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
