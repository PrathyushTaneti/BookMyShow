using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITheatreService
    {
        List<Theatre> GetAllTheatres();

        Theatre GetTheatreById(int Id);

        int CreateTheatre(Theatre theatreDetail);

        bool UpdateTheatreDetail(int Id,Theatre theatreDetail);

        bool DeleteTheatre(int Id);
    }
}
