using BookMyShowAPI.Models;
using PetaPoco;

namespace BookMyShowAPI.Services.ServiceClasses
{
    public class UserDetailService : IUserDetailService
    {
        public readonly IDatabase DbContext;
        public UserDetailService()
        {
            this.DbContext = new Database("Server = IRON - MAN\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<UserDetail> GetAllUserDetails()
        {
            return this.DbContext.Query<UserDetail>("Select * From UserDetail").ToList() ?? new List<UserDetail>();
        }

        public UserDetail GetUserDetailById(int Id)
        {
            return this.DbContext.SingleOrDefault<UserDetail>("Select * From UserDetail where Id = @0", Id) ?? null;
        }

        public int CreateUserDetail(UserDetail user)
        {
            this.DbContext.Insert(user);
            return this.GetUserDetailById(user.Id).Id;
        }

        public bool UpdateUserDetail(int Id, UserDetail user)
        {
            if (this.GetUserDetailById(Id) != null)
            {
                this.DbContext.Update(user);
                return true;
            }
            return false;
        }

        public bool DeleteUserDetail(int Id)
        {
            if (this.GetUserDetailById(Id) != null)
            {
                this.DbContext.Delete<UserDetail>(Id);
                return true;
            }
            return false;
        }
    }
}
