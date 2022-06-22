using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailController : ControllerBase
    {
        private readonly IMovieDetailService movieDetailService;

        public MovieDetailController(IMovieDetailService movieDetailService)
        {
            this.movieDetailService = movieDetailService;
        }

        [HttpGet]
        public List<MovieDetail> Get()
        {
            return this.movieDetailService.GetAllMovies();
        }

        [HttpGet("id")]
        public MovieDetail Get(int id)
        {
            return this.movieDetailService.GetMovieDetailById(id);
        }

        [HttpPost]
        public int Post(MovieDetail movieDetail)
        {
            return this.movieDetailService.CreateMovie(movieDetail);
        }

        [HttpPut("id")]
        public bool Put(int id, MovieDetail movieDetail)
        {
            return this.movieDetailService.UpdateMovieDetail(id, movieDetail);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.movieDetailService.DeleteMovieDetail(id);
        }
    }
}
