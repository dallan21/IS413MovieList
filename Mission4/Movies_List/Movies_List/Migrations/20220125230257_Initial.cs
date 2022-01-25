using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies_List.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action", "Anthony Russo", false, "", "Super good, but there were a few things it was missing", "PG-13", "Avengers End Game", "2019" });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action", "Jon Watts", false, "Jake Pingree", "Super good", "PG-13", "Spider-Man No Way Home", "2021" });

            migrationBuilder.InsertData(
                table: "Response",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Comedy", "Jaume Collet-Serra", true, "", "", "PG-13", "Jungle Cruise", "2021" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");
        }
    }
}
