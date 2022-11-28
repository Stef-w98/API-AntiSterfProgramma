﻿using Microsoft.AspNetCore.Mvc;
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
    public class MedicationController : ControllerBase
    {
        private readonly ApplicationDbContext _Db;
        public MedicationController(ApplicationDbContext db)
        {
            _Db = db;
        }

        [HttpGet]

        public ActionResult<Medications[]> GetMedication(int id)
        {
            Medications[] medications = _Db.Medications.Where(x => x.UserId == id).ToArray();
            return medications;
        }

        
        //[HttpPost]
        //public int PostTemps(Object TempData)
        //{
        //    if (TempData != null)
        //    {
        //        JsonElement element = (JsonElement)TempData;
        //        Temperature t = JsonConvert.DeserializeObject<Temperature>(element.GetRawText());

        //        _Db.Temperatures.Add(t);
        //        _Db.SaveChanges();
        //        return t.UserId;

        //    }
        //    return 0;
        //}

        //[HttpDelete]
        //public HttpResponseMessage DeleteTemps(int id) 
        //{
        //    var temps = _Db.Temperatures.OrderBy(t => t.TemperatureId).LastOrDefault(u => u.UserId == id);
        //    _Db.Temperatures.Remove(temps);            
        //    _Db.SaveChanges();
            
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}

    }
}
