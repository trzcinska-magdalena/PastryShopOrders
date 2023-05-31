using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PastryShopOrders.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pastry_orders_OrderID",
                table: "Order_Pastry");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pastry_pastries_PastryID",
                table: "Order_Pastry");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_clients_ClientID",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_employees_ClientID",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pastries",
                table: "pastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clients",
                table: "clients");

            migrationBuilder.RenameTable(
                name: "pastries",
                newName: "Pastry");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ClientID",
                table: "Order",
                newName: "IX_Order_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pastry_Order_OrderID",
                table: "Order_Pastry",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pastry_Pastry_PastryID",
                table: "Order_Pastry",
                column: "PastryID",
                principalTable: "Pastry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pastry_Order_OrderID",
                table: "Order_Pastry");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pastry_Pastry_PastryID",
                table: "Order_Pastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Pastry",
                newName: "pastries");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "clients");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientID",
                table: "orders",
                newName: "IX_orders_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pastries",
                table: "pastries",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employees",
                table: "employees",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clients",
                table: "clients",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pastry_orders_OrderID",
                table: "Order_Pastry",
                column: "OrderID",
                principalTable: "orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pastry_pastries_PastryID",
                table: "Order_Pastry",
                column: "PastryID",
                principalTable: "pastries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_clients_ClientID",
                table: "orders",
                column: "ClientID",
                principalTable: "clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_employees_ClientID",
                table: "orders",
                column: "ClientID",
                principalTable: "employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
