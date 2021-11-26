using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL.Entities
{
    public class Acteur : Personne
    {
        public int Oscars { get; set; }

        public IEnumerable<FilmActeur> AFilm { get; set; }
    }
}
