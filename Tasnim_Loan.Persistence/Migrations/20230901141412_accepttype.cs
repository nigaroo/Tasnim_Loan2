using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class accepttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Accept",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 61, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 66, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 66, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 66, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 66, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 1, 17, 44, 11, 66, DateTimeKind.Local).AddTicks(4923));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accept",
                table: "Loans",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 677, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 692, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 692, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 692, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 692, DateTimeKind.Local).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 31, 0, 16, 20, 692, DateTimeKind.Local).AddTicks(9358));
        }
    }
}
