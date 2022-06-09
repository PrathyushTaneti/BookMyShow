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
        public SeatDetail Get(int Id)
        {
            return this.seatDetailService.GetSeatById(Id);
        }

        [HttpPost]
        public int Post(SeatDetail seat)
        {
            return this.seatDetailService.CreateSeat(seat);
        }

        [HttpPut]
        public bool Put(int Id, SeatDetail seat)
        {
            return this.seatDetailService.UpdateSeatDetail(Id, seat);
        }

        [HttpDelete("id")]
        public bool Delete(int Id)
        {
            return this.seatDetailService.DeleteSeat(Id);
        }
    }
}
