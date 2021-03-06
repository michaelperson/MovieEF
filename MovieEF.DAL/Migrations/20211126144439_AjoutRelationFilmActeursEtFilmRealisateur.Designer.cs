// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieEF.DAL;

namespace MovieEF.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211126144439_AjoutRelationFilmActeursEtFilmRealisateur")]
    partial class AjoutRelationFilmActeursEtFilmRealisateur
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

                    b.Property<int?>("RealisateurId")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("");

                    b.HasKey("FilmId");

                    b.HasIndex("RealisateurId");

                    b.HasIndex("Titre")
                        .IsUnique();

                    b.ToTable("Film");

                    b.HasCheckConstraint("Chk_AnneeDeSortie", "Annee>1975");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.FilmActeur", b =>
                {
                    b.Property<int>("IdActeur")
                        .HasColumnType("int");

                    b.Property<int>("IdFilm")
                        .HasColumnType("int");

                    b.HasKey("IdActeur", "IdFilm");

                    b.HasIndex("IdFilm");

                    b.ToTable("FilmActeur");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypePersonne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personne");

                    b.HasDiscriminator<string>("TypePersonne").HasValue("Personne");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Acteur", b =>
                {
                    b.HasBaseType("MovieEF.DAL.Entities.Personne");

                    b.Property<int>("Oscars")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Actors");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Realisateur", b =>
                {
                    b.HasBaseType("MovieEF.DAL.Entities.Personne");

                    b.Property<double>("LongBarbe")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Producer");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Film", b =>
                {
                    b.HasOne("MovieEF.DAL.Entities.Realisateur", "Realisateur")
                        .WithMany("Films")
                        .HasForeignKey("RealisateurId");

                    b.Navigation("Realisateur");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.FilmActeur", b =>
                {
                    b.HasOne("MovieEF.DAL.Entities.Acteur", "Acteur")
                        .WithMany("AFilm")
                        .HasForeignKey("IdActeur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieEF.DAL.Entities.Film", "Film")
                        .WithMany("FActeurs")
                        .HasForeignKey("IdFilm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acteur");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Film", b =>
                {
                    b.Navigation("FActeurs");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Acteur", b =>
                {
                    b.Navigation("AFilm");
                });

            modelBuilder.Entity("MovieEF.DAL.Entities.Realisateur", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
