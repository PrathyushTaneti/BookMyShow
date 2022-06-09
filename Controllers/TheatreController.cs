using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService theatreService;

        public TheatreController(ITheatreService theatreService)
        {
            this.theatreService = theatreService;
        }

        [HttpGet]
        public List<Theatre> Get()
        {
            return this.theatreService.GetAllTheatres();
        }

        [HttpGet("id")]
        public Theatre Get(int Id)
        {
            return this.theatreService.GetTheatreById(Id);
        }

        [HttpPost]
        public int Post(Theatre theatre)
        {
            return this.theatreService.CreateTheatre(theatre);
        }

        [HttpPut("id")]
        public bool Put(int Id, Theatre theatre)
        {
            return this.theatreService.UpdateTheatreDetail(Id, theatre);
        }

        [HttpDelete("id")]
        public bool Delete(int Id)
        {
            return this.theatreService.DeleteTheatre(Id);
        }
    }
}
