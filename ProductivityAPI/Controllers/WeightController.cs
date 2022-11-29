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

        //public Weight[] GetWeight()
        //{
        //    Weight[] weights = _Db.Weights.Where(x => x.Id == 1).ToArray();
        //    return weights;
        //}

    }
}
