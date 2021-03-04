using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class Actor
    {
        public Actor()
        {
            ActorPlays = new HashSet<ActorPlay>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public int? Awards { get; set; }
        public string Info { get; set; }

        public virtual ICollection<ActorPlay> ActorPlays { get; set; }
    }
}
