using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class Creator
    {
        public Creator()
        {
            CreattionFilms = new HashSet<CreattionFilm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Awards { get; set; }
        public string Info { get; set; }

        public virtual ICollection<CreattionFilm> CreattionFilms { get; set; }
    }
}
