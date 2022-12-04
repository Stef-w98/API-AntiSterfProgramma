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
    public class WeightController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public WeightController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]

        public ActionResult<Weight[]> GetWeight(int id)
        {
            Weight[] weight = _Db.Weights.Where(x => x.UserId == id).ToArray();
            return weight;
        }

        [HttpPost]
        public int PostWeight(Object WeightData)
        {
            if (WeightData != null)
            {
                JsonElement element = (JsonElement)WeightData;
                Weight w = JsonConvert.DeserializeObject<Weight>(element.GetRawText());

                _Db.Weights.Add(w);
                _Db.SaveChanges();
                return w.UserId;
            }
            return 0;
        }

        [HttpDelete]
        public HttpResponseMessage DeleteWeight(int id)
        {
            var weight = _Db.Weights.OrderBy(w => w.WeightId).LastOrDefault(u => u.UserId == id);
            _Db.Weights.Remove(weight);
            _Db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
