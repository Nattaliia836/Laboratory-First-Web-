using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class SortSelection
    {
        public int Id { get; set; }
        public string SortingInfo { get; set; }
        public string Genre { get; set; }
        public int SelectionId { get; set; }
        public int FilmId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Selection Selection { get; set; }
    }
}
