using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripAhead.Services.Trips.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "trips");

            migrationBuilder.CreateTable(
                name: "OptionalItems",
                schema: "trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DefaultPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionalItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                schema: "trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MaxOccupancy = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentOccupancy = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripOptionalItem",
                schema: "trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionalItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripOptionalItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripOptionalItem_OptionalItems_OptionalItemId",
                        column: x => x.OptionalItemId,
                        principalSchema: "trips",
                        principalTable: "OptionalItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripOptionalItem_Trips_TripId",
                        column: x => x.TripId,
                        principalSchema: "trips",
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripOptionalItem_OptionalItemId",
                schema: "trips",
                table: "TripOptionalItem",
                column: "OptionalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TripOptionalItem_TripId",
                schema: "trips",
                table: "TripOptionalItem",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripOptionalItem",
                schema: "trips");

            migrationBuilder.DropTable(
                name: "OptionalItems",
                schema: "trips");

            migrationBuilder.DropTable(
                name: "Trips",
                schema: "trips");
        }
    }
}
