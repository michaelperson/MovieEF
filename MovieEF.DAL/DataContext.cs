using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieEF.DAL.Config;
using MovieEF.DAL.Datasets;
using MovieEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL
{
    public class DataContext : DbContext
    {
        #region DbSet
            public DbSet<Film> Films { get; set; }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Realisateur> Realisateurs { get; set; }
        //public DbSet<Personne> Personnes { get; set; }
        #endregion


        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(message => Console.WriteLine(message));
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MoviesEf;User Id=EFUser;Password=Test1234=;");
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // new FilmConfig().Configure(modelBuilder.Entity<Film>());        
            modelBuilder.ApplyConfiguration(new FilmConfig());
            //Pour le dataset
           // modelBuilder.ApplyConfiguration(new DataSet());



           

            //Pour les personnes et les acteurs et les réalisateurs
            //modelBuilder.ApplyConfiguration(new PersonneConfig());
            modelBuilder.ApplyConfiguration(new ActeurConfig());
            modelBuilder.ApplyConfiguration(new RealisateurConfig());

            //Apliquer la réalision n-n
             modelBuilder.ApplyConfiguration(new FilmActeurConfig());
        }
    }
}
