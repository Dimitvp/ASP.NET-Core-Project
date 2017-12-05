namespace BeerShop.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ImageColumnForProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Glasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GiftSets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Glasses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GiftSets");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accessories");
        }
    }
}
