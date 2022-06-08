using BookMyShowAPI.Models;
using PetaPoco;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class SeatDetailService : ISeatDetailService
    {
        public readonly IDatabase DbContext;

        public SeatDetailService()
        {
            this.DbContext = new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");

        }

        public List<SeatDetail> GetAllSeats()
        {
            return this.DbContext.Query<SeatDetail>("Select * From SeatDetail").ToList() ?? new List<SeatDetail>();
        }

        public SeatDetail GetSeatById(int Id)
        {
            return this.DbContext.SingleOrDefault<SeatDetail>("Select * From SeatDetail where Id = @0", Id);
        }

        public int CreateSeat(SeatDetail seatDetail)
        {
            this.DbContext.Insert(seatDetail);
            SeatDetail seat = this.GetSeatById(seatDetail.Id);
            return seat.Id;
        }

        public bool UpdateSeatDetail(int Id, SeatDetail seatDetail)
        {
            if(this.GetSeatById(Id) != null)
            {
                this.DbContext.Update(seatDetail);
                return true;
            }
            return false;
        }

        public bool DeleteSeat(int Id)
        {
            if(this.GetSeatById(Id) != null)
            {
                this.DbContext.Delete<SeatDetail>(Id);
                return true;
            }
            return false;
        }
    }
}
