using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieShowsListService
    {
        List<MovieShowsList> GetAllShows();

        MovieShowsList GetShowDetailById(int Id);

        int CreateShow(MovieShowsList movieShow);

        bool UpdateShow(int Id,MovieShowsList movieShow);

        bool DeleteShow(int Id);
    }
}
