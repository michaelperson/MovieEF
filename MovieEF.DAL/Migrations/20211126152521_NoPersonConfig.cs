using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class NoPersonConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Personne_RealisateurId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmActeur_Personne_IdActeur",
                table: "FilmActeur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personne",
                table: "Personne");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personne");

            migrationBuilder.DropColumn(
                name: "Oscars",
                table: "Personne");

            migrationBuilder.RenameTable(
                name: "Personne",
                newName: "Realisateurs");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Realisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Realisateurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "LongBarbe",
                table: "Realisateurs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Realisateurs",
                table: "Realisateurs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Acteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oscars = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acteurs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Realisateurs_RealisateurId",
                table: "Film",
                column: "RealisateurId",
                principalTable: "Realisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmActeur_Acteurs_IdActeur",
                table: "FilmActeur",
                column: "IdActeur",
                principalTable: "Acteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Realisateurs_RealisateurId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmActeur_Acteurs_IdActeur",
                table: "FilmActeur");

            migrationBuilder.DropTable(
                name: "Acteurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Realisateurs",
                table: "Realisateurs");

            migrationBuilder.RenameTable(
                name: "Realisateurs",
                newName: "Personne");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Personne",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Personne",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "LongBarbe",
                table: "Personne",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personne",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Oscars",
                table: "Personne",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personne",
                table: "Personne",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Personne_RealisateurId",
                table: "Film",
                column: "RealisateurId",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmActeur_Personne_IdActeur",
                table: "FilmActeur",
                column: "IdActeur",
                principalTable: "Personne",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
