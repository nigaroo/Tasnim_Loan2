using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class acceptcond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accept",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "InsertTime", "Name" },
                values: new object[] { new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(3764), "Reject" });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "InsertTime", "Name" },
                values: new object[] { new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(3854), "Preview" });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[] { 1, new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(1579), false, "Accept", null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 479, DateTimeKind.Local).AddTicks(3573));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 492, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 492, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 492, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 492, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 492, DateTimeKind.Local).AddTicks(9613));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Accept",
                table: "Loans");

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "InsertTime", "Name" },
                values: new object[] { new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(5566), "Housing" });

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "InsertTime", "Name" },
                values: new object[] { new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(6208), "Others" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 465, DateTimeKind.Local).AddTicks(3889));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(4980));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(5009));
        }
    }
}
