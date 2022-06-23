using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IUserDetailService
    {
        List<UserDetail> GetAllUserDetails();

        UserDetail GetUserDetailById(int id);

        int CreateUserDetail(UserDetail user);

        bool UpdateUserDetail(int id,UserDetail user);

        bool DeleteUserDetail(int id);
    }
}
