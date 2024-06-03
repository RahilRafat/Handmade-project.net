using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_SWD.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category_Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.category_ID);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    seller_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seller_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.seller_ID);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    report_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    customer_ID1 = table.Column<int>(type: "int", nullable: false),
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.report_ID);
                    table.ForeignKey(
                        name: "FK_comments_customers_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "customers",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_ID);
                    table.ForeignKey(
                        name: "FK_orders_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_price = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    sellerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_ID);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "category_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_sellers_sellerID",
                        column: x => x.sellerID,
                        principalTable: "sellers",
                        principalColumn: "seller_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    product_ID = table.Column<int>(type: "int", nullable: false),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => new { x.product_ID, x.customer_ID });
                    table.ForeignKey(
                        name: "FK_payments_customers_customer_ID",
                        column: x => x.customer_ID,
                        principalTable: "customers",
                        principalColumn: "customer_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_products_product_ID",
                        column: x => x.product_ID,
                        principalTable: "products",
                        principalColumn: "product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    orderItem_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_price = table.Column<int>(type: "int", nullable: false),
                    product_ID1 = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    product_ID = table.Column<int>(type: "int", nullable: false),
                    order_ID = table.Column<int>(type: "int", nullable: false),
                    paymentcustomer_ID = table.Column<int>(type: "int", nullable: true),
                    paymentproduct_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.orderItem_ID);
                    table.ForeignKey(
                        name: "FK_order_items_orders_order_ID",
                        column: x => x.order_ID,
                        principalTable: "orders",
                        principalColumn: "order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_items_payments_paymentproduct_ID_paymentcustomer_ID",
                        columns: x => new { x.paymentproduct_ID, x.paymentcustomer_ID },
                        principalTable: "payments",
                        principalColumns: new[] { "product_ID", "customer_ID" });
                    table.ForeignKey(
                        name: "FK_order_items_products_product_ID",
                        column: x => x.product_ID,
                        principalTable: "products",
                        principalColumn: "product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_customer_ID",
                table: "comments",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_ID",
                table: "order_items",
                column: "order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_paymentproduct_ID_paymentcustomer_ID",
                table: "order_items",
                columns: new[] { "paymentproduct_ID", "paymentcustomer_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_ID",
                table: "order_items",
                column: "product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerID",
                table: "orders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_customer_ID",
                table: "payments",
                column: "customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryID",
                table: "products",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_products_sellerID",
                table: "products",
                column: "sellerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "sellers");
        }
    }
}
