using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tower.Migrations
{
    public partial class Projectv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PercentComplete",
                table: "Projects",
                type: "float",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PercentComplete",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
