using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ISeatDetailService
    {
        List<SeatDetail> GetAllSeats();

        SeatDetail GetSeatById(int Id);

        int CreateSeat(SeatDetail seatDetail);

        bool UpdateSeatDetail(int Id, SeatDetail seatDetail);

        bool DeleteSeat(int Id);
    }
}
