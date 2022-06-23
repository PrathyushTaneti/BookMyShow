using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieShowsListService
    {
        List<MovieShowsList> GetAllShows();

        MovieShowsList GetShowDetailById(int id);

        int CreateShow(MovieShowsList movieShow);

        bool UpdateShow(int id,MovieShowsList movieShow);

        bool DeleteShow(int id);
    }
}
