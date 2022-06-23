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

        public MovieShowsList GetShowDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<MovieShowsList>("Select * from MovieShowsList Where Id = @0", id);
        }

        public int CreateShow(MovieShowsList movieShow)
        {
            this.DbContext.Insert(movieShow);
            return this.DbContext.SingleOrDefault<MovieShowsList>("Select * From MovieShowsList Where Id = @0", movieShow.Id).Id;
        }

        public bool UpdateShow(int id, MovieShowsList movieShow)
        {
            if (this.GetShowDetailById(id) != null)
            {
                this.DbContext.Update(movieShow);
                return true;
            }
            return false;
        }

        public bool DeleteShow(int id)
        {
            if (this.GetShowDetailById(id) != null)
            {
                this.DbContext.Delete<MovieShowsList>(id);
                return true;
            }
            return false;
        }     
    }
}
