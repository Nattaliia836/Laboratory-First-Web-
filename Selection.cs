using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class Selection
    {
        public Selection()
        {
            SortSelections = new HashSet<SortSelection>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityFilm { get; set; }
        public string Info { get; set; }

        public virtual ICollection<SortSelection> SortSelections { get; set; }
    }
}
