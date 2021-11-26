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
    public class ActeurConfig : IEntityTypeConfiguration<Acteur>
    {
        public void Configure(EntityTypeBuilder<Acteur> builder)
        { 
         builder.HasKey(x => x.IdPersonne);
            builder.Property(p => p.Nom).IsRequired();
            builder.Property(p => p.Prenom).IsRequired();
            builder.Property(x => x.Oscars).IsRequired();
        }
    }
}
