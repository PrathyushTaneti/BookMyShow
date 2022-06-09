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
        public MovieShowsList Get(int Id)
        {
            return this.movieShowListService.GetShowDetailById(Id);
        }

        [HttpPost]
        public int Post(MovieShowsList movieShow)
        {
            return this.movieShowListService.CreateShow(movieShow);
        }

        [HttpPut]
        public bool Put(int Id, MovieShowsList movieShow)
        {
            return this.movieShowListService.UpdateShow(Id, movieShow);
        }

        [HttpDelete]
        public bool Delete(int Id)
        {
            return this.movieShowListService.DeleteShow(Id);
        }
    }
}
