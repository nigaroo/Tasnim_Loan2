﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasnim_Loan.Persistence.Migrations
{
    public partial class userchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewUserID",
                table: "UserInRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewUserID",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewUserID",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Userss",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    National_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unique_Payment_Identifier = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userss", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 26, 16, 25, 49, 420, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 26, 16, 25, 49, 434, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 26, 16, 25, 49, 434, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.CreateIndex(
                name: "IX_UserInRoles_NewUserID",
                table: "UserInRoles",
                column: "NewUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_NewUserID",
                table: "Transactions",
                column: "NewUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_NewUserID",
                table: "Loans",
                column: "NewUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Userss_NewUserID",
                table: "Loans",
                column: "NewUserID",
                principalTable: "Userss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Userss_NewUserID",
                table: "Transactions",
                column: "NewUserID",
                principalTable: "Userss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRoles_Userss_NewUserID",
                table: "UserInRoles",
                column: "NewUserID",
                principalTable: "Userss",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Userss_NewUserID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Userss_NewUserID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInRoles_Userss_NewUserID",
                table: "UserInRoles");

            migrationBuilder.DropTable(
                name: "Userss");

            migrationBuilder.DropIndex(
                name: "IX_UserInRoles_NewUserID",
                table: "UserInRoles");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_NewUserID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Loans_NewUserID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "NewUserID",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "NewUserID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "NewUserID",
                table: "Loans");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2023, 8, 25, 21, 9, 51, 220, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2023, 8, 25, 21, 9, 51, 234, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2023, 8, 25, 21, 9, 51, 234, DateTimeKind.Local).AddTicks(6997));
        }
    }
}
