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
    public class RealisateurConfig : IEntityTypeConfiguration<Realisateur>
    {
        public void Configure(EntityTypeBuilder<Realisateur> builder)
        { 
             builder.HasKey(x => x.IdPersonne);
            builder.Property(p => p.Nom).IsRequired();
            builder.Property(p => p.Prenom).IsRequired();
            builder.Property(x => x.LongBarbe).IsRequired();
        }
    }
}
