using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ISeatDetailService
    {
        List<SeatDetail> GetAllSeats();

        SeatDetail GetSeatById(int id);

        int CreateSeat(SeatDetail seatDetail);

        bool UpdateSeatDetail(int id, SeatDetail seatDetail);

        bool DeleteSeat(int id);
    }
}
