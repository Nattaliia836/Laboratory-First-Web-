using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class ActorPlay
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int? Salary { get; set; }
        public int QuantityScenes { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
