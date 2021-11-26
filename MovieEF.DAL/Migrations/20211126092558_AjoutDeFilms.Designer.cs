﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieEF.DAL;

namespace MovieEF.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211126092558_AjoutDeFilms")]
    partial class AjoutDeFilms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieEF.DAL.Entities.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActeurPrincipal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Realisateur")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.HasKey("FilmId");

                    b.HasIndex("Titre")
                        .IsUnique();

                    b.ToTable("Film");

                    b.HasCheckConstraint("Chk_AnneeDeSortie", "Annee>1975");

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            ActeurPrincipal = "Mark Hammil",
                            Annee = 1977,
                            Genre = "Science-Fiction",
                            Realisateur = "Georges Lucas",
                            Titre = "Star Wars : Un nouvel espoir"
                        },
                        new
                        {
                            FilmId = 2,
                            ActeurPrincipal = "Mark Hammil",
                            Annee = 1980,
                            Genre = "Science-Fiction",
                            Realisateur = "Georges Lucas",
                            Titre = "Star Wars : L'empire contre-attaque"
                        },
                        new
                        {
                            FilmId = 3,
                            ActeurPrincipal = "Mark Hammil",
                            Annee = 1983,
                            Genre = "Science-Fiction",
                            Realisateur = "Georges Lucas",
                            Titre = "Star Wars : Le retour du Jedi"
                        },
                        new
                        {
                            FilmId = 4,
                            ActeurPrincipal = "Charlie Hunnam",
                            Annee = 2005,
                            Genre = "Société",
                            Realisateur = "Lexi Alexander",
                            Titre = "Hooligans"
                        },
                        new
                        {
                            FilmId = 5,
                            ActeurPrincipal = "Elijah Wood",
                            Annee = 2001,
                            Genre = "Heroic-Fantasy",
                            Realisateur = "Peter Jackson",
                            Titre = "LOTR - La communauté de l'anneau"
                        },
                        new
                        {
                            FilmId = 6,
                            ActeurPrincipal = "Elijah Wood",
                            Annee = 2002,
                            Genre = "Heroic-Fantasy",
                            Realisateur = "Peter Jackson",
                            Titre = "LOTR - Les deux tours"
                        },
                        new
                        {
                            FilmId = 7,
                            ActeurPrincipal = "Elijah Wood",
                            Annee = 2003,
                            Genre = "Heroic-Fantasy",
                            Realisateur = "Peter Jackson",
                            Titre = "LOTR - Le retour du roi"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
