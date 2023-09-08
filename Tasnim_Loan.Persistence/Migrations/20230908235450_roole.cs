using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class roole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 480, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 480, DateTimeKind.Local).AddTicks(2422));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 480, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 467, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 479, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 479, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 479, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 3, 24, 47, 479, DateTimeKind.Local).AddTicks(8300));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 422, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 423, DateTimeKind.Local).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 423, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 408, DateTimeKind.Local).AddTicks(2927));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 421, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[] { 2, new DateTime(2023, 9, 9, 0, 29, 2, 421, DateTimeKind.Local).AddTicks(8231), false, "Operator", null, null });

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 422, DateTimeKind.Local).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 422, DateTimeKind.Local).AddTicks(6929));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 422, DateTimeKind.Local).AddTicks(7124));
        }
    }
}
