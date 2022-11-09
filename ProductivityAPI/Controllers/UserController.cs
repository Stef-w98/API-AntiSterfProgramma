using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductivityAPI.Data;
using ProductivityAPI.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            User user = _Db.Users.FirstOrDefault(x => x.UserId == 1);
            return user;
        }

        [HttpPost]
        public int PostUser(Object loginInfo)
        {
            if(loginInfo != null)
            {
                JsonElement element = (JsonElement)loginInfo;
                User u = JsonConvert.DeserializeObject<User>(element.GetRawText());

                User userName = _Db.Users.FirstOrDefault(x => x.UserName == u.UserName);
                if(userName != null)
                {
                    if (userName.Password == u.Password)
                    {
                        return userName.UserId;
                    }
                }
                
            }
            return 0;
        }
        
    }
}
