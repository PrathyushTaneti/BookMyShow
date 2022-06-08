namespace BookMyShowAPI.Models
{
    public class SeatDetail
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateOnly Date { get; set; }

        public int MovieId { get; set; }

        public int TheatreId { get; set; }
    }
}
