using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tower.Migrations
{
    public partial class MaintenanceUpdateOct11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MainContact",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Item",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Contact",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Contact",
                newName: "FirstName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Item",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TimeLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    LoggedMinutes = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLog_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeLog_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ContactId",
                table: "Client",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_ClientId",
                table: "TimeLog",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLog_UserId",
                table: "TimeLog",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Contact_ContactId",
                table: "Client",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Contact_ContactId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "TimeLog");

            migrationBuilder.DropIndex(
                name: "IX_Client_ContactId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Client");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Item",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Contact",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Contact",
                newName: "firstName");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainContact",
                table: "Client",
                nullable: false,
                defaultValue: "");
        }
    }
}
