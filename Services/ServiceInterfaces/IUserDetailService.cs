using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IUserDetailService
    {
        List<UserDetail> GetAllUserDetails();

        UserDetail GetUserDetailById(int Id);

        int CreateUserDetail(UserDetail user);

        bool UpdateUserDetail(int Id,UserDetail user);

        bool DeleteUserDetail(int Id);
    }
}
