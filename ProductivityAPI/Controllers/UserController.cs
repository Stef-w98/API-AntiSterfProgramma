using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityAPI.Data;
using ProductivityAPI.Model;

namespace ProductivityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public UserController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]
        public User GetUser()
        {
            User user = _Db.Users.FirstOrDefault(x => x.Id == 1);
            return user;
        }


    }
}
