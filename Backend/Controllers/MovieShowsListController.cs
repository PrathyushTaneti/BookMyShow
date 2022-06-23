using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowsListController : ControllerBase
    {
        private readonly IMovieShowsListService movieShowListService;

        public MovieShowsListController(IMovieShowsListService movieShowListService)
        {
            this.movieShowListService = movieShowListService;
        }

        [HttpGet]
        public List<MovieShowsList> Get()
        {
            return this.movieShowListService.GetAllShows();
        }

        [HttpGet("id")]
        public MovieShowsList Get(int id)
        {
            return this.movieShowListService.GetShowDetailById(id);
        }

        [HttpPost]
        public int Post(MovieShowsList movieShow)
        {
            return this.movieShowListService.CreateShow(movieShow);
        }

        [HttpPut("id")]
        public bool Put(int id, MovieShowsList movieShow)
        {
            return this.movieShowListService.UpdateShow(id, movieShow);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.movieShowListService.DeleteShow(id);
        }
    }
}
