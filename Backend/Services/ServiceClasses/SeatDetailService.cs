using BookMyShow.Models;
using PetaPoco;

namespace BookMyShow.Services.ServiceClasses
{
    public class SeatDetailService : ISeatDetailService
    {
        public readonly IDatabase DbContext;

        public SeatDetailService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");

        }

        public List<SeatDetail> GetAllSeats()
        {
            return this.DbContext.Query<SeatDetail>("Select * From SeatDetail").ToList() ?? new List<SeatDetail>();
        }

        public SeatDetail GetSeatById(int id)
        {
            return this.DbContext.SingleOrDefault<SeatDetail>("Select * From SeatDetail where Id = @0", id);
        }

        public int CreateSeat(SeatDetail seatDetail)
        {
            this.DbContext.Insert(seatDetail);
            return this.DbContext.SingleOrDefault<SeatDetail>("Select * from SeatDetail Where Id = @Id", seatDetail.Id).Id;
        }

        public bool UpdateSeatDetail(int id, SeatDetail seatDetail)
        {
            if (this.GetSeatById(id) != null)
            {
                this.DbContext.Update(seatDetail);
                return true;
            }
            return false;
        }

        public bool DeleteSeat(int id)
        {
            if (this.GetSeatById(id) != null)
            {
                this.DbContext.Delete<SeatDetail>(id);
                return true;
            }
            return false;
        }
    }
}

