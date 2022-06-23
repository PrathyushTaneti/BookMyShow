using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITheatreService
    {
        List<Theatre> GetAllTheatres();

        Theatre GetTheatreById(int id);

        int CreateTheatre(Theatre theatreDetail);

        bool UpdateTheatreDetail(int id,Theatre theatreDetail);

        bool DeleteTheatre(int id);
    }
}
