using BookMyShowAPI.Models;
using PetaPoco;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class TheatreService : ITheatreService
    {
        public readonly IDatabase DbContext;

        public TheatreService()
        {
            this.DbContext = new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<Theatre> GetAllTheatres()
        {
            return this.DbContext.Query<Theatre>("Select * From Theatre").ToList() ?? new List<Theatre>();
        }

        public Theatre GetTheatreById(int Id)
        {
            return this.DbContext.SingleOrDefault<Theatre>("Select * from Theatre Where Id = @0", Id) ?? null;
        }        

        public int CreateTheatre(Theatre theatreDetail)
        {
            this.DbContext.Insert(theatreDetail);
            return this.DbContext.SingleOrDefault<Theatre>("Select * from Theatre Where Id = @0", theatreDetail.Id).Id;
        }

        public bool UpdateTheatreDetail(int Id, Theatre theatreDetail)
        {
            if(this.GetTheatreById(Id) != null)
            {
                this.DbContext.Update(theatreDetail);
                return true;
            }
            return false;
        }

        public bool DeleteTheatre(int Id)
        {
            if(this.GetTheatreById(Id) != null)
            {
                this.DbContext.Delete<Theatre>(Id);
            }
            return false;
        }
    }
}
