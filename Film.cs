using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class Film
    {
        public Film()
        {
            ActorPlays = new HashSet<ActorPlay>();
            CreattionFilms = new HashSet<CreattionFilm>();
            Responses = new HashSet<Response>();
            SortSelections = new HashSet<SortSelection>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string YearRelease { get; set; }
        public string Duration { get; set; }
        public int? Awards { get; set; }
        public int? Cost { get; set; }

        public virtual ICollection<ActorPlay> ActorPlays { get; set; }
        public virtual ICollection<CreattionFilm> CreattionFilms { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<SortSelection> SortSelections { get; set; }
    }
}
