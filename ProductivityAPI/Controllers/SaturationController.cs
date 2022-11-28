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
    public class SaturationController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public SaturationController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]

        public ActionResult<Saturation[]> GetSat(int id)
        {
            Saturation[] sat = _Db.Saturations.Where(x => x.UserId == id).ToArray();
            return sat;
        }

        
        [HttpPost]
        public int PostSat(Object SatData)
        {
            if (SatData != null)
            {
                JsonElement element = (JsonElement)SatData;
                Saturation s = JsonConvert.DeserializeObject<Saturation>(element.GetRawText());

                _Db.Saturations.Add(s);
                _Db.SaveChanges();
                return s.UserId;

            }
            return 0;
        }

        [HttpDelete]
        public HttpResponseMessage DeleteSat(int id) 
        {
            var sat = _Db.Saturations.OrderBy(s => s.SaturationId).LastOrDefault(u => u.UserId == id);
            _Db.Saturations.Remove(sat);            
            _Db.SaveChanges();
            
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
