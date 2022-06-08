using BookMyShowAPI.Models;
using BookMyShowAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
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
        public List<IMovieDetailService> Get()
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

        [HttpPut]
        public bool Put(int Id, MovieDetail movieDetail)
        {
            return this.movieDetailService.UpdateMovieDetail(Id, movieDetail);
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            return this.movieDetailService.DeleteMovieDetail(Id);
        }
    }
}
