using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using MovieEF.DAL;
using MovieEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Movie EF");

            using(DataContext dc = new DataContext())
            {
                Console.WriteLine("Création d'un acteur");

                Acteur Actor = new Acteur()
                {
                    Nom = "Reinolds",
                    Prenom = "Ryan",
                    Oscars = 52
                };

                dc.Acteurs.Add(Actor);
                Realisateur Rea = new Realisateur()
                {
                    Nom = "Spielberg",
                    Prenom = "Steven",
                    LongBarbe=37.5
                };

                dc.Realisateurs.Add(Rea);
                dc.SaveChanges();

                List<Acteur> la = dc.Acteurs.ToList();
                List<Realisateur> lr = dc.Realisateurs.ToList();
                List<Personne> lp = new List<Personne>();
                lp.AddRange(la);
                lp.AddRange(lr);

            Console.WriteLine("Ajout de Pacific Rim");
            Film FPAcific = new Film()
            {
                ActeurPrincipal = "Charlie Hunnam",
                Annee = 2013,
                Realisateur = new Realisateur() { Nom="Del Toro", Prenom="Guillermo" },
                Genre = "Action",
                Titre = "Pacific Rim"
            };
            
                if(dc.Films.FirstOrDefault(m=>m.Titre=="Pacific Rim")!= null)
                {
                    Console.WriteLine("Le film Pacific Rim est déjà présent dans la DB");
                }
                else
                {
                    dc.Films.Add(FPAcific);
                }

                Console.WriteLine("Films sortis avant 2001");
            
                foreach(Film f in dc.Films.Where(m=>m.Annee<2001))
                {
                    Console.WriteLine($"Titre : {f.Titre} ({f.Annee})");
                }

                List<Film> mesfilms = new List<Film>()
                {
                    new Film(){ Titre="Star Wars" },
                    new Film(){ Titre="ça" }
                };
                foreach (Film f in mesfilms.Where(m => GetFilter("Star Wars", m)))
                {
                    Console.WriteLine(f.Titre);
                }


                Console.WriteLine("Harrison Ford - Le seul Jedi");
                foreach (Film f in dc.Films.ToList().Where(m => GetFilter("Star Wars",m)))
                {
                    f.ActeurPrincipal = "Harrison Ford";
                    Console.WriteLine($"Remplacement de l'acteur dans : {f.Titre}");
                }

                Console.WriteLine("Sauvegarde en DB");
                try
                {
                    dc.SaveChanges();
                    Console.WriteLine("Succeed");
                }
                catch (DbUpdateException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Error : {ex.Message}");
                    if(ex.InnerException!=null)
                    {
                        Console.WriteLine($"InnerException: {ex.InnerException.Message}");
                    }
                    Console.WriteLine("Entities on Error");
                    foreach (EntityEntry item in ex.Entries)
                    {
                        Console.WriteLine($"Entity State : {item.State}");
                        Console.WriteLine($"Entity Type : {item.Entity.GetType().Name}");
                        Console.WriteLine("Values :");
                        foreach (IProperty pv in item.CurrentValues.Properties)
                        {
                            object o = null;
                             item.CurrentValues.TryGetValue(pv.Name, out o); 
                            Console.WriteLine($"    --> Property : {pv.Name} - Value :{o?.ToString()}");
                        }
                       
                    }
                    Console.ResetColor();
                }

                Console.WriteLine("Suppression des films avec Charlie Hunnam");
                foreach (Film item in dc.Films.Where(a=>a.ActeurPrincipal== "Charlie Hunnam"))
                {
                    dc.Remove(item);
                }
                try
                {
                    dc.SaveChanges();
                    Console.WriteLine("Deleted!");
                }
                catch (DbUpdateException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Error : {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"InnerException: {ex.InnerException.Message}");
                    }
                    Console.WriteLine("Entities on Error");
                    foreach (EntityEntry item in ex.Entries)
                    {
                        Console.WriteLine($"Entity State : {item.State}");
                        Console.WriteLine($"Entity Type : {item.Entity.GetType().Name}");
                        Console.WriteLine("Values :");
                        foreach (IProperty pv in item.CurrentValues.Properties)
                        {
                            object o = null;
                            item.CurrentValues.TryGetValue(pv.Name, out o);
                            Console.WriteLine($"    --> Property : {pv.Name} - Value :{o?.ToString()}");
                        }

                    }
                    Console.ResetColor();
                }
            }
        }

        private static bool GetFilter(string search, Film ZeFilm)
        {
            return ZeFilm.Titre.Contains(search);
        }
    }
}
