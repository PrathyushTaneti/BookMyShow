using BookMyShowAPI.Models;
using PetaPoco;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class TicketService : ITicketService
    {

        public readonly IDatabase DbContext;

        public TicketService()
        {
            this.DbContext = new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<Ticket> GetAllTickets()
        {
            return this.DbContext.Query<Ticket>("Select * From Ticket").ToList() ?? new List<Ticket>();
        }

        public Ticket GetTicketById(int Id)
        {
            return this.DbContext.SingleOrDefault<Ticket>("Select * From Ticket where Id = @0", Id) ?? null;
        }

        public int CreateTicket(Ticket ticket)
        {
            this.DbContext.Insert(ticket);
            return this.GetTicketById(ticket.Id).Id;
        }       

        public bool UpdateTicket(int Id, Ticket ticket)
        {
            if (this.GetTicketById(Id) != null)
            {
                this.DbContext.Update(ticket);
                return true;
            }
            return false;
        }

        public bool DeleteTicket(int Id)
        {
            if (this.GetTicketById(Id) != null)
            {
                this.DbContext.Delete<Ticket>(Id);
                return true;
            }
            return false;
        }       
    }
}
