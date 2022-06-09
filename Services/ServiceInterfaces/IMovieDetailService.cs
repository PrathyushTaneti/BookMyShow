using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieDetailService
    {
        List<MovieDetail> GetAllMovies();

        MovieDetail GetMovieDetailById(int Id);

        int CreateMovie(MovieDetail movieDetail);

        bool UpdateMovieDetail(int Id,MovieDetail movie);

        bool DeleteMovieDetail(int Id);
    }
}
