using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class transactionss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creditor",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Debtor",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Trans_Num",
                table: "Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "IsPay",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_AmountID",
                table: "Transactions",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Total_AmountID",
                table: "Transactions",
                column: "Total_AmountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Loans_Total_AmountID",
                table: "Transactions",
                column: "Total_AmountID",
                principalTable: "Loans",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Loans_Total_AmountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Total_AmountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsPay",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Total_AmountID",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Creditor",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Debtor",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Trans_Num",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 1, 29, 1, 493, DateTimeKind.Local).AddTicks(3854));

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
    }
}
