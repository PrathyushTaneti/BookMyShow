﻿using BookMyShowAPI.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class MovieDetailService : IMovieDetailService
    {

        public readonly IDatabase DbContext;

        public MovieDetailService() // SimpleInjector
        {
            this.DbContext= new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<MovieDetail> GetAllMovies()
        {
            return this.DbContext.Query<MovieDetail>("Select * From MovieDetail").ToList() ?? new List<MovieDetail>();
        }

        public MovieDetail GetMovieDetailById(int Id)
        {
            return this.DbContext.SingleOrDefault<MovieDetail>("Select * from MovieDetail Where Id = @0", Id);
        }

        public int CreateMovie(MovieDetail movieDetail) // check
        {
            this.DbContext.Insert(movieDetail);
            return this.DbContext.SingleOrDefault<MovieDetail>("Select * From MovieDetail Where Id = @0", movieDetail.Id).Id;
        }

        public bool UpdateMovieDetail(int Id,MovieDetail movieDetail)
        {
           if(this.GetMovieDetailById(Id) != null){
                this.DbContext.Update(movieDetail);  // check
                return true;
            }
            return false;
        }

        public bool DeleteMovieDetail(int Id)
        {
            if(this.GetMovieDetailById(Id) != null)
            {
                this.DbContext.Delete<MovieDetail>(Id);
                return true;
            }
            return false;
        }
       
    }
}
