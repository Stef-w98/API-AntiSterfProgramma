using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductivityAPI.Data;
using ProductivityAPI.Model;
using System.Text.Json;

namespace ProductivityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public RegisterUserController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpPost]
        public int PostRegisterUser(Object NewUser)
        {
            if (NewUser != null)
            {
                JsonElement element = (JsonElement)NewUser;
                User u = JsonConvert.DeserializeObject<User>(element.GetRawText());


                _Db.Users.Add(u);
                _Db.SaveChanges();
                return u.Id;

            }
            return 0;
        }
    }
}
