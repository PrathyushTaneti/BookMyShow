using BookMyShowAPI.Models;
using PetaPoco;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class MovieShowsListService : ISeatDetailService
    {
        public readonly IDatabase DbContext;

        public MovieShowsListService()
        {
            this.DbContext = new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");

        }

        public List<SeatDetail> GetAllShows()
        {
            return this.DbContext.Query<SeatDetail>("Select * From MovieShowsList").ToList() ?? new List<SeatDetail>();
        }

        public SeatDetail GetShowDetailById(int Id)
        {
            return this.DbContext.SingleOrDefault<SeatDetail>("Select * from MovieShowsList Where Id = @0", Id);
        }
        public int CreateShow(SeatDetail movieShow)
        {
            this.DbContext.Insert(movieShow);
            return this.DbContext.SingleOrDefault<SeatDetail>("Select * From MovieShowsList Where Id = @0", movieShow.Id).Id;
        }

        public bool UpdateShow(int Id, SeatDetail movieShow)
        {
            if (this.GetShowDetailById(Id) != null)
            {
                this.DbContext.Update(movieShow);
                return true;
            }
            return false;
        }

        public bool DeleteShow(int Id)
        {
            if (this.GetShowDetailById(Id) != null)
            {
                this.DbContext.Delete<SeatDetail>(Id);
                return true;
            }
            return false;
        }     
    }
}
