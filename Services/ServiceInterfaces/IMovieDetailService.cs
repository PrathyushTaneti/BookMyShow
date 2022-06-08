using BookMyShowAPI.Models;

namespace BookMyShowAPI.Services
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
