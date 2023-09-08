using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class addingDefaultValueForPaymentAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 421, DateTimeKind.Local).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 9, 0, 29, 2, 421, DateTimeKind.Local).AddTicks(9052));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 28, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 28, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 28, DateTimeKind.Local).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 5, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 26, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 26, DateTimeKind.Local).AddTicks(9701));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 27, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 27, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 8, 23, 43, 54, 27, DateTimeKind.Local).AddTicks(7084));
        }
    }
}
