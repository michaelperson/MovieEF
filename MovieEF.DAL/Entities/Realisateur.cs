using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieEF.DAL.Entities
{
    public class Realisateur:Personne
    {
        public double LongBarbe { get; set; }
        public List<Film> Films { get; set; }
    }
}
