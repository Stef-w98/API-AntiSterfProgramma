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


        [HttpPost]
        public int PostMedication(Object MedData)
        {
            if (MedData != null)
            {
                JsonElement element = (JsonElement)MedData;
                Medications m = JsonConvert.DeserializeObject<Medications>(element.GetRawText());

                _Db.Medications.Add(m);
                _Db.SaveChanges();
                return m.UserId;

            }
            return 0;
        }

        [HttpPut]
        public int UpdateMedication(Object MedData)
        {
            if (MedData != null)
            {
                JsonElement element = (JsonElement)MedData;
                Medications m = JsonConvert.DeserializeObject<Medications>(element.GetRawText());

                // Find the medication with UserId and MedicationId.
                Medications existingMed = _Db.Medications
                    .Where(x => x.UserId == m.UserId && x.MedicationId == m.MedicationId)
                    .FirstOrDefault();

                if (existingMed == null)
                {
                    return 0;
                }

                // Update properties.
                existingMed.MedicationName = m.MedicationName;
                existingMed.MedicationUse = m.MedicationUse;
                _Db.SaveChanges();
                return m.UserId;
            }
            return 0;
        }

        [HttpDelete]
        public int DeleteMedication(int userId, int medicationId)
        {
            // Find the medication with UserId and MedicationId.
            Medications medDelete = _Db.Medications
            .Where(x => x.UserId == userId && x.MedicationId == medicationId)
            .FirstOrDefault();

            if (medDelete == null)
            {
                return 0;
            }

            _Db.Medications.Remove(medDelete);
            _Db.SaveChanges();
            return userId;

        }
    }
}
