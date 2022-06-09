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
        public MovieDetail Get(int Id)
        {
            return this.movieDetailService.GetMovieDetailById(Id);
        }

        [HttpPost]
        public int Post(MovieDetail movieDetail)
        {
            return this.movieDetailService.CreateMovie(movieDetail);
        }

        [HttpPut("id")]
        public bool Put(int Id, MovieDetail movieDetail)
        {
            return this.movieDetailService.UpdateMovieDetail(Id, movieDetail);
        }

        [HttpDelete("id")]
        public bool Delete(int Id)
        {
            return this.movieDetailService.DeleteMovieDetail(Id);
        }
    }
}
