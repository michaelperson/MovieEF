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
    [Obsolete]
    public class PersonneConfig : IEntityTypeConfiguration<Personne>
    {
        public void Configure(EntityTypeBuilder<Personne> builder)
        {
            builder.HasKey(x => x.IdPersonne);

            builder.Property(p => p.Nom).IsRequired();
            builder.Property(p => p.Prenom).IsRequired();


            /*Heritage EF*/
            /*==> NE respecte pas le principe de base des schémas relationnels*/
            //builder.HasDiscriminator<string>("TypePersonne")
            //       .HasValue<Acteur>("Actors")
            //       .HasValue<Realisateur>("Producer");

        }
    }
}
