using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITicketService
    {     
        List<Ticket> GetAllTickets();

        Ticket GetTicketById(int id);

        int CreateTicket(Ticket ticket);

        bool UpdateTicketDetail(int id,Ticket ticket);

        bool DeleteTicket(int id);

    }
}
