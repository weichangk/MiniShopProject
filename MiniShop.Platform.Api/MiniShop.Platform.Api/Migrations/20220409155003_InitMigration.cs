using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniShop.Platform.Api.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RenewPackage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    OperatorName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RenewPackage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RenewPackage",
                columns: new[] { "Id", "CreatedTime", "Image", "ModifiedTime", "Months", "Name", "OperatorName", "Price", "Remark" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 9, 23, 50, 2, 490, DateTimeKind.Local).AddTicks(6579), "https://gw.alipayobjects.com/zos/rmsportal/gLaIAoVWTtLbBWZNYEMg.png", new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(3392), 6, "半年", null, 299m, "续费请联系：18276743761（微信同号）" },
                    { 2, new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4660), "https://gw.alipayobjects.com/zos/rmsportal/iXjVmWVHbCJAyqvDxdtx.png", new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4666), 12, "一年", null, 499m, "续费请联系：18276743761（微信同号）" },
                    { 3, new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4669), "https://gw.alipayobjects.com/zos/rmsportal/iZBVOIhGJiAnhplqjvZW.png", new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4670), 24, "两年", null, 799m, "续费请联系：18276743761（微信同号）" },
                    { 4, new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4672), "https://gw.alipayobjects.com/zos/rmsportal/uMfMFlvUuceEyPpotzlq.png", new DateTime(2022, 4, 9, 23, 50, 2, 491, DateTimeKind.Local).AddTicks(4672), 36, "三年", null, 1099m, "续费请联系：18276743761（微信同号）" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RenewPackage_Name",
                table: "RenewPackage",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RenewPackage");
        }
    }
}
