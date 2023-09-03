using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class loanconditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanInCoditions_Condition_ConditionId",
                table: "LoanInCoditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Condition",
                table: "Condition");

            migrationBuilder.RenameTable(
                name: "Condition",
                newName: "Conditions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "ID", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(5566), false, "Housing", null, null },
                    { 3, new DateTime(2023, 9, 3, 0, 13, 27, 470, DateTimeKind.Local).AddTicks(6208), false, "Others", null, null }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_LoanInCoditions_Conditions_ConditionId",
                table: "LoanInCoditions",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanInCoditions_Conditions_ConditionId",
                table: "LoanInCoditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conditions",
                table: "Conditions");

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Conditions",
                newName: "Condition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Condition",
                table: "Condition",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 180, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 184, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 184, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 184, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 184, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 9, 3, 0, 6, 51, 184, DateTimeKind.Local).AddTicks(9463));

            migrationBuilder.AddForeignKey(
                name: "FK_LoanInCoditions_Condition_ConditionId",
                table: "LoanInCoditions",
                column: "ConditionId",
                principalTable: "Condition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
