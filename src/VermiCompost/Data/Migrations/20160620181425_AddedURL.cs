using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VermiCompost.data.migrations
{
    public partial class AddedURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Blogs",
                nullable: true);
        }
    }
}
