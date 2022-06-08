using BookMyShowAPI.Models;

namespace BookMyShowAPI.Services
{
    public interface ISeatDetailService
    {
        List<SeatDetail> GetAllShows();

        SeatDetail GetShowDetailById(int Id);

        int CreateShow(SeatDetail movieShow);

        bool UpdateShow(int Id,SeatDetail movieShow);

        bool DeleteShow(int Id);
    }
}
