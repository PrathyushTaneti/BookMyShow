using BookMyShowAPI.Models;
using BookMyShowAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowsListController : ControllerBase
    {
        private readonly ISeatDetailService movieShowListService;

        public MovieShowsListController(ISeatDetailService movieShowListService)
        {
            this.movieShowListService = movieShowListService;
        }

        [HttpGet]
        public List<SeatDetail> Get()
        {
            return this.movieShowListService.GetAllShows();
        }

        [HttpGet("id")]
        public SeatDetail Get(int Id)
        {
            this.movieShowListService.GetShowDetailById(Id);
        }

        [HttpPost]
        public int Post(SeatDetail movieShow)
        {
            return this.movieShowListService.CreateShow(movieShow);
        }

        [HttpPut]
        public bool Put(int Id, SeatDetail movieShow)
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
