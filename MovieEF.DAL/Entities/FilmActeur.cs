using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL.Entities
{
    public class FilmActeur
    {
        public int IdFilm { get; set; }
        public int IdActeur { get; set; }

        public Film Film { get; set; }
        public Acteur Acteur { get; set; }


    }
}
