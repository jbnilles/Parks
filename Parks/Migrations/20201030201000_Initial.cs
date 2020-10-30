using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Solution.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOfPark = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "City", "Description", "Name", "State", "TypeOfPark" },
                values: new object[,]
                {
                    { -1, "Pouslbo", "Kitsap Memorial State Park is a 63-acre public recreation area located on Hood Canal, seven miles north of Poulsbo in Kitsap County, Washington.", "Kitsap Memorial State Park", "WA", "State" },
                    { -2, "Brinnon", "Dosewallips State Park is a public recreation area located where the Dosewallips River empties into Hood Canal in Jefferson County, Washington.", "Dosewallips State Park", "WA", "State" },
                    { -3, "Port Angeles", "Olympic National Park is on Washington's Olympic Peninsula in the Pacific Northwest. The park sprawls across several different ecosystems, from the dramatic peaks of the Olympic Mountains to old-growth forests.", "Olympic National Park", "WA", "National" },
                    { -4, "Lake Chelan", "North Cascades National Park is in northern Washington State. It’s a vast wilderness of conifer-clad mountains, glaciers and lakes.", "North Cascades National Park", "WA", "National" },
                    { -5, "Mount Rainier", "Mount Rainier National Park, a 369-sq.-mile Washington state reserve southeast of Seattle, surrounds glacier-capped, 14,410-ft. Mount Rainier.", "Mount Rainier National Park", "WA", "National" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
