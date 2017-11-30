using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BeerShop.Data.Migrations
{
    public partial class RemoveTowns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breweries_Towns_TownId",
                table: "Breweries");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropIndex(
                name: "IX_Breweries_TownId",
                table: "Breweries");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Breweries");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Breweries");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Breweries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Breweries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breweries_Countries_CountryId",
                table: "Breweries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breweries_Countries_CountryId",
                table: "Breweries");

            migrationBuilder.DropIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Breweries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Breweries");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Breweries",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Breweries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_TownId",
                table: "Breweries",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CountryId",
                table: "Towns",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breweries_Towns_TownId",
                table: "Breweries",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
