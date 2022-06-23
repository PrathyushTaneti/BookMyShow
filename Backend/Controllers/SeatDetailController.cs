using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatDetailController : ControllerBase
    {

        private readonly ISeatDetailService seatDetailService;

        public SeatDetailController(ISeatDetailService seatDetailService)
        {
            this.seatDetailService = seatDetailService;
        }

        [HttpGet]
        public List<SeatDetail> Get()
        {
            return this.seatDetailService.GetAllSeats();
        }

        [HttpGet("id")]
        public SeatDetail Get(int id)
        {
            return this.seatDetailService.GetSeatById(id);
        }

        [HttpPost]
        public int Post(SeatDetail seat)
        {
            return this.seatDetailService.CreateSeat(seat);
        }

        [HttpPut("id")]
        public bool Put(int id, SeatDetail seat)
        {
            return this.seatDetailService.UpdateSeatDetail(id, seat);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.seatDetailService.DeleteSeat(id);
        }
    }
}
