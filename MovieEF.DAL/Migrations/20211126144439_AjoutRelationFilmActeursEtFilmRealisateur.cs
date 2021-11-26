using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class AjoutRelationFilmActeursEtFilmRealisateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Film",
                keyColumn: "FilmId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Realisateur",
                table: "Film");

            migrationBuilder.AddColumn<int>(
                name: "RealisateurId",
                table: "Film",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmActeur",
                columns: table => new
                {
                    IdFilm = table.Column<int>(type: "int", nullable: false),
                    IdActeur = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmActeur", x => new { x.IdActeur, x.IdFilm });
                    table.ForeignKey(
                        name: "FK_FilmActeur_Film_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmActeur_Personne_IdActeur",
                        column: x => x.IdActeur,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_RealisateurId",
                table: "Film",
                column: "RealisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmActeur_IdFilm",
                table: "FilmActeur",
                column: "IdFilm");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Personne_RealisateurId",
                table: "Film",
                column: "RealisateurId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Personne_RealisateurId",
                table: "Film");

            migrationBuilder.DropTable(
                name: "FilmActeur");

            migrationBuilder.DropIndex(
                name: "IX_Film_RealisateurId",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "RealisateurId",
                table: "Film");

            migrationBuilder.AddColumn<string>(
                name: "Realisateur",
                table: "Film",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "FilmId", "ActeurPrincipal", "Annee", "Genre", "Realisateur", "Titre" },
                values: new object[,]
                {
                    { 1, "Mark Hammil", 1977, "Science-Fiction", "Georges Lucas", "Star Wars : Un nouvel espoir" },
                    { 2, "Mark Hammil", 1980, "Science-Fiction", "Georges Lucas", "Star Wars : L'empire contre-attaque" },
                    { 3, "Mark Hammil", 1983, "Science-Fiction", "Georges Lucas", "Star Wars : Le retour du Jedi" },
                    { 4, "Charlie Hunnam", 2005, "Société", "Lexi Alexander", "Hooligans" },
                    { 5, "Elijah Wood", 2001, "Heroic-Fantasy", "Peter Jackson", "LOTR - La communauté de l'anneau" },
                    { 6, "Elijah Wood", 2002, "Heroic-Fantasy", "Peter Jackson", "LOTR - Les deux tours" },
                    { 7, "Elijah Wood", 2003, "Heroic-Fantasy", "Peter Jackson", "LOTR - Le retour du roi" }
                });
        }
    }
}
