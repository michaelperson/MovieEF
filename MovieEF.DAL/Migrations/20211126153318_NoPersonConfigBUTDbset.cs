using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class NoPersonConfigBUTDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Personnes");

            migrationBuilder.AlterColumn<double>(
                name: "LongBarbe",
                table: "Personnes",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personnes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Oscars",
                table: "Personnes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Personnes_RealisateurId",
                table: "Film",
                column: "RealisateurId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmActeur_Personnes_IdActeur",
                table: "FilmActeur",
                column: "IdActeur",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Personnes_RealisateurId",
                table: "Film");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmActeur_Personnes_IdActeur",
                table: "FilmActeur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personnes",
                table: "Personnes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personnes");

            migrationBuilder.DropColumn(
                name: "Oscars",
                table: "Personnes");

            migrationBuilder.RenameTable(
                name: "Personnes",
                newName: "Realisateurs");

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
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oscars = table.Column<int>(type: "int", nullable: false),
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
    }
}
