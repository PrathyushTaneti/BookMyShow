using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public List<Ticket> Get()
        {
            return this.ticketService.GetAllTickets();
        }

        [HttpGet("id")]
        public Ticket Get(int id)
        {
            return this.ticketService.GetTicketById(id);
        }

        [HttpPost]
        public int Post(Ticket ticket)
        {
            return this.ticketService.CreateTicket(ticket);
        }

        [HttpPut("id")]
        public bool Put(int id, Ticket ticket)
        {
            return this.ticketService.UpdateTicketDetail(id, ticket);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.ticketService.DeleteTicket(id);
        }
    }
}
