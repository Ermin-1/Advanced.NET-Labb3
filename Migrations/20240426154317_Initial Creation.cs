using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Advanced.NET_Labb3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "JoinTables",
                columns: table => new
                {
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JoinTables", x => x.PersonInterestId);
                    table.ForeignKey(
                        name: "FK_JoinTables_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JoinTables_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false),
                    joinTablePersonInterestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_JoinTables_joinTablePersonInterestId",
                        column: x => x.joinTablePersonInterestId,
                        principalTable: "JoinTables",
                        principalColumn: "PersonInterestId");
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "InterestDescription", "InterestTitle" },
                values: new object[,]
                {
                    { 1, "Sitta och göra sidoprpjekt", "Programmering" },
                    { 2, "Cykla mountainbike", "Cykla" },
                    { 3, "Kitesurfa nere i viken", "Surfa" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "LinkId", "PersonInterestId", "Url", "joinTablePersonInterestId" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/programmering", null },
                    { 2, 2, "https://example.com/cykla", null },
                    { 3, 3, "https://example.com/surfa", null }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Ermin", "Husic", 72222 },
                    { 2, "Oskar", "Johansson", 7222322 },
                    { 3, "Jonathan", "Bengtsson", 7245645 }
                });

            migrationBuilder.InsertData(
                table: "JoinTables",
                columns: new[] { "PersonInterestId", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JoinTables_InterestId",
                table: "JoinTables",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_JoinTables_PersonId",
                table: "JoinTables",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_joinTablePersonInterestId",
                table: "Links",
                column: "joinTablePersonInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "JoinTables");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
