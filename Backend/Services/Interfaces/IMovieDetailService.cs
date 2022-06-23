using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieDetailService
    {
        List<MovieDetail> GetAllMovies();

        MovieDetail GetMovieDetailById(int id);

        int CreateMovie(MovieDetail movieDetail);

        bool UpdateMovieDetail(int id,MovieDetail movie);

        bool DeleteMovieDetail(int id);
    }
}
