using BookMyShow.Models;
using PetaPoco;

namespace BookMyShow.Services.ServiceClasses
{
    public class TicketService : ITicketService
    {

        public readonly IDatabase DbContext;

        public TicketService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<Ticket> GetAllTickets()
        {
            return this.DbContext.Query<Ticket>("Select * From Ticket").ToList() ?? new List<Ticket>();
        }

        public Ticket GetTicketById(int id)
        {
            return this.DbContext.SingleOrDefault<Ticket>("Select * From Ticket where Id = @0", id);
        }

        public int CreateTicket(Ticket ticket)
        {
            this.DbContext.Insert(ticket);
            return this.GetTicketById(ticket.Id).Id;
        }       

        public bool UpdateTicketDetail(int id, Ticket ticket)
        {
            if (this.GetTicketById(id) != null)
            {
                this.DbContext.Update(ticket);
                return true;
            }
            return false;
        }

        public bool DeleteTicket(int id)
        {
            if (this.GetTicketById(id) != null)
            {
                this.DbContext.Delete<Ticket>(id);
                return true;
            }
            return false;
        }       
    }
}
