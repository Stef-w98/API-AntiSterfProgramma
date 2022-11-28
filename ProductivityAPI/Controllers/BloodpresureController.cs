using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityAPI.Data;
using ProductivityAPI.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace ProductivityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodpresureController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public BloodpresureController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]

        public ActionResult<BloodPressure[]> GetBloodPresure(int id)
        {
            BloodPressure[] bloodPressures = _Db.BloodPressures.Where(x => x.UserId == id).ToArray();
            return bloodPressures;
        }

        
        [HttpPost]
        public int PostBloodpresure(Object Bloodpresure)
        {
            if (Bloodpresure != null)
            {
                JsonElement element = (JsonElement)Bloodpresure;
                BloodPressure b = JsonConvert.DeserializeObject<BloodPressure>(element.GetRawText());

                _Db.BloodPressures.Add(b);
                _Db.SaveChanges();
                return b.UserId;

            }
            return 0;
        }

        [HttpDelete]
        public HttpResponseMessage DeleteBloodPresure(int id) 
        {
            var bloodpresure = _Db.BloodPressures.OrderBy(b => b.BloodPressureId).LastOrDefault(u => u.UserId == id);
            _Db.BloodPressures.Remove(bloodpresure);            
            _Db.SaveChanges();
            
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
