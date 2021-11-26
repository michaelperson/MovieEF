using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class CorrectAvecContraintesPlusPKNonConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Realisateurs_RealisateurId",
                table: "Film");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Realisateurs",
                newName: "IdPersonne");

            migrationBuilder.RenameColumn(
                name: "RealisateurId",
                table: "Film",
                newName: "RealisateurIdPersonne");

            migrationBuilder.RenameIndex(
                name: "IX_Film_RealisateurId",
                table: "Film",
                newName: "IX_Film_RealisateurIdPersonne");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Acteurs",
                newName: "IdPersonne");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Realisateurs_RealisateurIdPersonne",
                table: "Film",
                column: "RealisateurIdPersonne",
                principalTable: "Realisateurs",
                principalColumn: "IdPersonne",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Realisateurs_RealisateurIdPersonne",
                table: "Film");

            migrationBuilder.RenameColumn(
                name: "IdPersonne",
                table: "Realisateurs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RealisateurIdPersonne",
                table: "Film",
                newName: "RealisateurId");

            migrationBuilder.RenameIndex(
                name: "IX_Film_RealisateurIdPersonne",
                table: "Film",
                newName: "IX_Film_RealisateurId");

            migrationBuilder.RenameColumn(
                name: "IdPersonne",
                table: "Acteurs",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Realisateurs_RealisateurId",
                table: "Film",
                column: "RealisateurId",
                principalTable: "Realisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
