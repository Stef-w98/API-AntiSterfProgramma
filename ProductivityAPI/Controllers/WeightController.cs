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

        public Weight GetWeight()
        {
            Weight weight = _Db.Weights.FirstOrDefault(x => x.Id == 2);
            return weight;
        }
        //public Weight[] GetWeight()
        //{
        //    Weight[] weights = _Db.Weights.Where(x => x.Id == 1).ToArray();
        //    return weights;
        //}

    }
}
