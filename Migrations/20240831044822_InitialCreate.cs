using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    A_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_ORDER_NO = table.Column<int>(type: "int", nullable: false),
                    H_ORDER_INT = table.Column<int>(type: "int", nullable: false),
                    A_FILE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    A_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.A_ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    H_ORDER_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_ORDER_INT = table.Column<int>(type: "int", nullable: false),
                    H_SUPP_NO = table.Column<int>(type: "int", nullable: false),
                    H_SUPP_COM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_SUP_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_STORE_NO = table.Column<int>(type: "int", nullable: false),
                    H_INVOICE_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_INVOICE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    H_TAX_NO = table.Column<int>(type: "int", nullable: false),
                    H_INV_AMT = table.Column<int>(type: "int", nullable: false),
                    H_SECTOR_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_UPDATEBY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    H_UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    H_STATUS = table.Column<int>(type: "int", nullable: false),
                    H_COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.H_ORDER_NO);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    DETAIL_ORDER_NO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    D_ORDER_NO = table.Column<int>(type: "int", nullable: false),
                    D_ORDER_INT = table.Column<int>(type: "int", nullable: false),
                    D_LINE = table.Column<int>(type: "int", nullable: false),
                    D_ART_NO = table.Column<int>(type: "int", nullable: false),
                    D_ART_DVT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_MMUNT = table.Column<int>(type: "int", nullable: false),
                    D_ARTNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    D_QTY = table.Column<int>(type: "int", nullable: false),
                    D_GOLDVAT = table.Column<int>(type: "int", nullable: false),
                    D_GOLD_PRICE = table.Column<int>(type: "int", nullable: false),
                    D_SUPVAT = table.Column<int>(type: "int", nullable: false),
                    D_SUP_PRICE = table.Column<int>(type: "int", nullable: false),
                    D_UPDATEBY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    H_UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    D_STATUS = table.Column<int>(type: "int", nullable: false),
                    D_COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.DETAIL_ORDER_NO);
                });

            migrationBuilder.CreateTable(
                name: "ProgressOrder",
                columns: table => new
                {
                    PO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    H_ORDER_NO = table.Column<int>(type: "int", nullable: false),
                    H_ORDER_INT = table.Column<int>(type: "int", nullable: false),
                    HISTORY_ID = table.Column<int>(type: "int", nullable: false),
                    HISTORY_STATUS = table.Column<int>(type: "int", nullable: false),
                    HISTORY_COMMIT_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HISTORY_CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressOrder", x => x.PO_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    H_SECTOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H_SECTOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.H_SECTOR_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProgressOrder");

            migrationBuilder.DropTable(
                name: "Sector");
        }
    }
}
