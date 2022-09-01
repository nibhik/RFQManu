using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RFQManufactMicroservice.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RFQ",
                columns: table => new
                {
                    rfqId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    demandid = table.Column<int>(nullable: false),
                    Part_Id = table.Column<int>(nullable: false),
                    partName = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    timetoSupply = table.Column<DateTime>(nullable: false),
                    Specification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFQ", x => x.rfqId);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIER",
                columns: table => new
                {
                    Part_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_id = table.Column<int>(nullable: false),
                    Supplier_Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Feedback = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIER", x => x.Part_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFQ");

            migrationBuilder.DropTable(
                name: "SUPPLIER");
        }
    }
}
