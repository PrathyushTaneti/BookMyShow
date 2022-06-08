namespace BookMyShowAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public DateTime ShowTime { get; set; }

        public int UserId { get; set; }

        public int TheatreId { get; set; }

        public int SeatId { get; set; }
    }
}
