using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class AjoutDeFilms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Chk_AnneeDeSortie",
                table: "Film");

            migrationBuilder.RenameColumn(
                name: "AnneeDeSortie",
                table: "Film",
                newName: "Annee");

            migrationBuilder.RenameColumn(
                name: "Acteur",
                table: "Film",
                newName: "ActeurPrincipal");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Film",
                newName: "FilmId");

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

            migrationBuilder.AddCheckConstraint(
                name: "Chk_AnneeDeSortie",
                table: "Film",
                sql: "Annee>1975");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Chk_AnneeDeSortie",
                table: "Film");

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

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "Film",
                newName: "AnneeDeSortie");

            migrationBuilder.RenameColumn(
                name: "ActeurPrincipal",
                table: "Film",
                newName: "Acteur");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Film",
                newName: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "Chk_AnneeDeSortie",
                table: "Film",
                sql: "AnneeDeSortie>1975");
        }
    }
}
