using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class MoviesEF_Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnneeDeSortie = table.Column<int>(type: "int", nullable: false),
                    Realisateur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Acteur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                    table.CheckConstraint("Chk_AnneeDeSortie", "AnneeDeSortie>1975");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_Titre",
                table: "Film",
                column: "Titre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
