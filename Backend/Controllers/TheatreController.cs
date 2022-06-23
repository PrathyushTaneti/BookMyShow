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
        public Theatre Get(int id)
        {
            return this.theatreService.GetTheatreById(id);
        }

        [HttpPost]
        public int Post(Theatre theatre)
        {
            return this.theatreService.CreateTheatre(theatre);
        }

        [HttpPut("id")]
        public bool Put(int id, Theatre theatre)
        {
            return this.theatreService.UpdateTheatreDetail(id, theatre);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.theatreService.DeleteTheatre(id);
        }
    }
}
