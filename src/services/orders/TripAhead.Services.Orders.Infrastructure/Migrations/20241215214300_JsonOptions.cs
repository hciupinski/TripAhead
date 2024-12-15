using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using TripAhead.Services.Orders.Domain.Entities;

#nullable disable

namespace TripAhead.Services.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class JsonOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Options",
                schema: "orders",
                table: "Orders",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(List<OrderOption>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<OrderOption>>(
                name: "Options",
                schema: "orders",
                table: "Orders",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
