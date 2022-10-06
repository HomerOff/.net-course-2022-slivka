﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Db.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    passport = table.Column<int>(type: "integer", nullable: false),
                    birthday_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    phone_number = table.Column<int>(type: "integer", nullable: false),
                    bonus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    currency_id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.currency_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    passport = table.Column<int>(type: "integer", nullable: false),
                    birthday_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    phone_number = table.Column<int>(type: "integer", nullable: false),
                    bonus = table.Column<int>(type: "integer", nullable: false),
                    salary = table.Column<int>(type: "integer", nullable: false),
                    contract = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    client_id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "FK_accounts_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accounts_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "currency_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_client_id",
                table: "accounts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_currency_id",
                table: "accounts",
                column: "currency_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "currencies");
        }
    }
}
