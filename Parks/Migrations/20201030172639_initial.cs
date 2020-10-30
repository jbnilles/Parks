using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Solution.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsStatePark = table.Column<bool>(nullable: false),
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
                columns: new[] { "ParkId", "City", "Description", "IsStatePark", "Name", "State" },
                values: new object[,]
                {
                    { -1, "Pouslbo", "Kitsap Memorial State Park is a 63-acre public recreation area located on Hood Canal, seven miles north of Poulsbo in Kitsap County, Washington.", true, "Kitsap Memorial State Park", "WA" },
                    { -2, "Brinnon", "Dosewallips State Park is a public recreation area located where the Dosewallips River empties into Hood Canal in Jefferson County, Washington.", true, "Dosewallips State Park", "WA" },
                    { -3, "Port Angeles", "Olympic National Park is on Washington's Olympic Peninsula in the Pacific Northwest. The park sprawls across several different ecosystems, from the dramatic peaks of the Olympic Mountains to old-growth forests.", false, "Olympic National Park", "WA" },
                    { -4, "Lake Chelan", "North Cascades National Park is in northern Washington State. It’s a vast wilderness of conifer-clad mountains, glaciers and lakes.", false, "North Cascades National Park", "WA" },
                    { -5, "Mount Rainier", "Mount Rainier National Park, a 369-sq.-mile Washington state reserve southeast of Seattle, surrounds glacier-capped, 14,410-ft. Mount Rainier.", false, "Mount Rainier National Park", "WA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
