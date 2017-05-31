using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fangorn.Data.Migrations
{
    public partial class Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ClosdUserId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ClosdUserId",
                table: "Tickets",
                newName: "ClosedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ClosdUserId",
                table: "Tickets",
                newName: "IX_Tickets_ClosedUserId");

            migrationBuilder.AddColumn<string>(
                name: "AssignedId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedId",
                table: "Tickets",
                column: "AssignedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedId",
                table: "Tickets",
                column: "AssignedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ClosedUserId",
                table: "Tickets",
                column: "ClosedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_ClosedUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AssignedId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AssignedId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ClosedUserId",
                table: "Tickets",
                newName: "ClosdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ClosedUserId",
                table: "Tickets",
                newName: "IX_Tickets_ClosdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_ClosdUserId",
                table: "Tickets",
                column: "ClosdUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
