using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class MovieDetail
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Language { get; set; }
        public string? Duration { get; set; }
        public string? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Rating { get; set; }
        public byte[]? Poster { get; set; }
    }
}
