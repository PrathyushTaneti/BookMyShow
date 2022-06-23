using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class MovieShowsList
    {
        public int Id { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public DateTime? Date { get; set; }

        public int? MovieId { get; set; }

        public int? TheatreId { get; set; }
    }
}
