using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tower.Migrations
{
    public partial class ServerOrderUpdateNov19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceOrders");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ServiceOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ClientId",
                table: "ServiceOrders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Client_ClientId",
                table: "ServiceOrders",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Client_ClientId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ClientId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ServiceOrders");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ServiceOrders",
                nullable: true);
        }
    }
}
