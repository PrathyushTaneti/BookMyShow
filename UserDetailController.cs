using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService userDetailService;

        public UserDetailController(IUserDetailService userDetailService)
        {
            this.userDetailService = userDetailService;
        }

        [HttpGet]
        public List<UserDetail> Get()
        {
            return this.userDetailService.GetAllUserDetails();
        }

        [HttpGet("id")]
        public UserDetail Get(int id)
        {
            return this.userDetailService.GetUserDetailById(id);
        }

        [HttpPost]
        public int Post (UserDetail userDetail)
        {
            return this.userDetailService.CreateUserDetail(userDetail);
        }

        [HttpPut("id")]
        public bool Put(int id, UserDetail userDetail)
        {
            return this.userDetailService.UpdateUserDetail(id, userDetail);
        }

        [HttpDelete("id")]
        public bool Delete(int id)
        {
            return this.userDetailService.DeleteUserDetail(id);
        }
    }
}
