using BookMyShow.Models;
using PetaPoco;

namespace BookMyShow.Services.ServiceClasses
{
    public class UserDetailService : IUserDetailService
    {
        public readonly IDatabase DbContext;
        public UserDetailService()
        {
            this.DbContext = new Database("Server = .\\SQLEXPRESS;" + "Database = BookMyShowDb; Trusted_Connection = True;" + "TrustServerCertificate = True;", "System.Data.SqlClient");
        }

        public List<UserDetail> GetAllUserDetails()
        {
            return this.DbContext.Query<UserDetail>("Select * From UserDetail").ToList() ?? new List<UserDetail>();
        }

        public UserDetail GetUserDetailById(int id)
        {
            return this.DbContext.SingleOrDefault<UserDetail>("Select * From UserDetail where Id = @0", id);
        }

        public int CreateUserDetail(UserDetail user)
        {
            this.DbContext.Insert(user);
            return this.GetUserDetailById(user.Id).Id;
        }

        public bool UpdateUserDetail(int id, UserDetail user)
        {
            if (this.GetUserDetailById(id) != null)
            {
                this.DbContext.Update(user);
                return true;
            }
            return false;
        }

        public bool DeleteUserDetail(int id)
        {
            if (this.GetUserDetailById(id) != null)
            {
                this.DbContext.Delete<UserDetail>(id);
                return true;
            }
            return false;
        }
    }
}
