using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITicketService
    {     
        List<Ticket> GetAllTickets();

        Ticket GetTicketById(int Id);

        int CreateTicket(Ticket ticket);

        bool UpdateTicket(int Id,Ticket ticket);

        bool DeleteTicket(int Id);

    }
}
