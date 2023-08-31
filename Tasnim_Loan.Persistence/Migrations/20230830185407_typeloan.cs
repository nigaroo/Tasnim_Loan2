using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class typeloan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 22, 24, 5, 146, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 22, 24, 5, 355, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 22, 24, 5, 355, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 30, 22, 24, 5, 355, DateTimeKind.Local).AddTicks(6753), false, "treatment", null, null },
                    { 2, new DateTime(2023, 8, 30, 22, 24, 5, 356, DateTimeKind.Local).AddTicks(1364), false, "Housing", null, null },
                    { 3, new DateTime(2023, 8, 30, 22, 24, 5, 356, DateTimeKind.Local).AddTicks(1622), false, "Others", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 3, 41, 20, 634, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 3, 41, 20, 647, DateTimeKind.Local).AddTicks(6445));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 30, 3, 41, 20, 647, DateTimeKind.Local).AddTicks(6952));
        }
    }
}
