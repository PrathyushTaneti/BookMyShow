using BookMyShow.Models;
using PetaPoco;

namespace BookMyShow.Services.ServiceClasses
{
    public class TheatreService : ITheatreService
    {
        public readonly IDatabase DbContext;

        public TheatreService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<Theatre> GetAllTheatres()
        {
            return this.DbContext.Query<Theatre>("Select * From Theatre").ToList() ?? new List<Theatre>();
        }

        public Theatre GetTheatreById(int id)
        {
            return this.DbContext.SingleOrDefault<Theatre>("Select * from Theatre Where Id = @0", id);
        }        

        public int CreateTheatre(Theatre theatreDetail)
        {
            this.DbContext.Insert(theatreDetail);
            return this.DbContext.SingleOrDefault<Theatre>("Select * from Theatre Where Id = @0", theatreDetail.Id).Id;
        }

        public bool UpdateTheatreDetail(int id, Theatre theatreDetail)
        {
            if(this.GetTheatreById(id) != null)
            {
                this.DbContext.Update(theatreDetail);
                return true;
            }
            return false;
        }

        public bool DeleteTheatre(int id)
        {
            if(this.GetTheatreById(id) != null)
            {
                this.DbContext.Delete<Theatre>(id);
            }
            return false;
        }
    }
}
