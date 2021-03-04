using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class CreattionFilm
    {
        public int Id { get; set; }
        public string Profession { get; set; }
        public int? Salary { get; set; }
        public int FilmId { get; set; }
        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; }
        public virtual Film Film { get; set; }
    }
}
