namespace BeerShop.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class BeerImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Beers",
                type: "varbinary(max)",
                maxLength: 2097152,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Beers");
        }
    }
}
