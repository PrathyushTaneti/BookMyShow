using System;
using System.Collections.Generic;

namespace BookMyShow.Models
{
    public partial class SeatDetail
    {
        public int Id { get; set; }
        public string? SeatNumber { get; set; }
        public string? SeatType { get; set; }
    }
}
