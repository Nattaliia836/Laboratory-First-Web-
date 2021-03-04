using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2
{
    public partial class Response
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string DataResponse { get; set; }
        public int FilmId { get; set; }

        public virtual Film Film { get; set; }
    }
}
