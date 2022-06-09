using BookMyShow.Models;
using PetaPoco;

namespace BookMyShow.Services.ServiceClasses
{
    public class MovieShowsListService : IMovieShowsListService
    {
        public readonly IDatabase DbContext;

        public MovieShowsListService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");

        }

        public List<MovieShowsList> GetAllShows()
        {
            return this.DbContext.Query<MovieShowsList>("Select * From MovieShowsList").ToList() ?? new List<MovieShowsList>();
        }

        public MovieShowsList GetShowDetailById(int Id)
        {
            return this.DbContext.SingleOrDefault<MovieShowsList>("Select * from MovieShowsList Where Id = @0", Id);
        }
        public int CreateShow(MovieShowsList movieShow)
        {
            this.DbContext.Insert(movieShow);
            return this.DbContext.SingleOrDefault<MovieShowsList>("Select * From MovieShowsList Where Id = @0", movieShow.Id).Id;
        }

        public bool UpdateShow(int Id, MovieShowsList movieShow)
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
                this.DbContext.Delete<MovieShowsList>(Id);
                return true;
            }
            return false;
        }     
    }
}
