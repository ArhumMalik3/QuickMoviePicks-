using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickMoviePickz.Data.Migrations
{
    public partial class added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49091afa-9231-4ebb-8c5e-27a81371905d");

            migrationBuilder.CreateTable(
                name: "PrivateGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Pin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieWatchers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    MyPrivateGroupId = table.Column<int>(nullable: true),
                    QuestionnaireId = table.Column<int>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieWatchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieWatchers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieWatchers_PrivateGroups_MyPrivateGroupId",
                        column: x => x.MyPrivateGroupId,
                        principalTable: "PrivateGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieWatchers_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "195f06c5-e745-4c94-8ef1-a48edc3141a4", "2cd77c80-d8d9-42fb-bba3-d42ec6cd819f", "Movie Watcher", "MOVIEWATCHER" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatchers_IdentityUserId",
                table: "MovieWatchers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatchers_MyPrivateGroupId",
                table: "MovieWatchers",
                column: "MyPrivateGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieWatchers_QuestionnaireId",
                table: "MovieWatchers",
                column: "QuestionnaireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieWatchers");

            migrationBuilder.DropTable(
                name: "PrivateGroups");

            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195f06c5-e745-4c94-8ef1-a48edc3141a4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49091afa-9231-4ebb-8c5e-27a81371905d", "7c6cc472-d3a1-4a71-9d07-8c486a9da809", "Movie Watcher", "MOVIEWATCHER" });
        }
    }
}
