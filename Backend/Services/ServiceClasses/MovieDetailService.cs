using BookMyShow.Models;
using PetaPoco;
using System;
using System.Collections.Generic;

namespace BookMyShow.Services.ServiceClasses
{
    public class MovieDetailService : IMovieDetailService
    {

        public readonly IDatabase DbContext;

        public MovieDetailService()
        {
            this.DbContext= new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<MovieDetail> GetAllMovies()
        {
            return this.DbContext.Query<MovieDetail>("Select * From MovieDetail").ToList() ?? new List<MovieDetail>();
        }

        public MovieDetail GetMovieDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<MovieDetail>("Select * from MovieDetail Where Id = @0", id);
        }

        public int CreateMovie(MovieDetail movieDetail) 
        {
            this.DbContext.Insert(movieDetail);
            return movieDetail.Id;
        }
         
        public bool UpdateMovieDetail(int id,MovieDetail movieDetail)
        {
           if(this.GetMovieDetailById(id) != null){
                this.DbContext.Update(movieDetail); 
                return true;
            }
            return false;
        }

        public bool DeleteMovieDetail(int id)
        {
            if(this.GetMovieDetailById(id) != null)
            {
                this.DbContext.Delete<MovieDetail>(id);
                return true;
            }
            return false;
        }
       
    }
}
