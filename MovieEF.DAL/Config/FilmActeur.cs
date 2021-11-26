using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL.Config
{
    public class FilmActeurConfig : IEntityTypeConfiguration<FilmActeur>
    {
        public void Configure(EntityTypeBuilder<FilmActeur> builder)
        {
            builder.HasKey(f => new { f.IdActeur, f.IdFilm });

            //Relations
            builder.HasOne<Film>(fa => fa.Film)
                   .WithMany(f => f.FActeurs)
                   .HasForeignKey(fa => fa.IdFilm);


            builder.HasOne<Acteur>(fa => fa.Acteur)
                   .WithMany(f => f.AFilm)
                   .HasForeignKey(fa => fa.IdActeur);
        }
    }
}
