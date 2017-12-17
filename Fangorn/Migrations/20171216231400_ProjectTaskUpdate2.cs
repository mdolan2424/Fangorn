using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tower.Migrations
{
    public partial class ProjectTaskUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompletedById",
                table: "ProjectTasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTasks_CompletedById",
                table: "ProjectTasks",
                column: "CompletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_CompletedById",
                table: "ProjectTasks",
                column: "CompletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_AspNetUsers_CompletedById",
                table: "ProjectTasks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTasks_CompletedById",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "CompletedById",
                table: "ProjectTasks");
        }
    }
}
