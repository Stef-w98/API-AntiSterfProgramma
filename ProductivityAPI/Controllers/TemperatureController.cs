using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityAPI.Data;
using ProductivityAPI.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductivityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public TemperatureController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]

        public ActionResult<Temperature[]> GetWeight(int id)
        {
            Temperature[] temps = _Db.Temperatures.Where(x => x.UserId == id).ToArray();
            return temps;
        }

        
        [HttpPost]
        public int PostRegisterUser(Object TempData)
        {
            if (TempData != null)
            {
                JsonElement element = (JsonElement)TempData;
                Temperature t = JsonConvert.DeserializeObject<Temperature>(element.GetRawText());

                _Db.Temperatures.Add(t);
                _Db.SaveChanges();
                return t.UserId;

            }
            return 0;
        }

    }
}
