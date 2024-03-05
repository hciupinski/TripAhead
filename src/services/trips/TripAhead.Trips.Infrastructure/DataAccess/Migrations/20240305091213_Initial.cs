using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripAhead.Trips.Infrastructure.DataAccess.Migrations
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
                name: "OptionalItem",
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
                    table.PrimaryKey("PK_OptionalItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                schema: "trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(350)", maxLength: 350, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxOccupancy = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
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
                        name: "FK_TripOptionalItem_OptionalItem_OptionalItemId",
                        column: x => x.OptionalItemId,
                        principalSchema: "trips",
                        principalTable: "OptionalItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripOptionalItem_Trip_TripId",
                        column: x => x.TripId,
                        principalSchema: "trips",
                        principalTable: "Trip",
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
                name: "OptionalItem",
                schema: "trips");

            migrationBuilder.DropTable(
                name: "Trip",
                schema: "trips");
        }
    }
}
