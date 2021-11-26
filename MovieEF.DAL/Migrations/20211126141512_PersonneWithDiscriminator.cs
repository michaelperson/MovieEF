using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEF.DAL.Migrations
{
    public partial class PersonneWithDiscriminator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypePersonne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oscars = table.Column<int>(type: "int", nullable: true),
                    LongBarbe = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
