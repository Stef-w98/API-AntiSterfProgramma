using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityAPI.Model
{
    public class Medications
    {
        //MedicationID
        [Key]
        public int MedicationId { get; set; }

        //UserID
        public int Id { get; set; }
        [ForeignKey("Id")]
        public User UserId { get; set; }

        //Medication Name
        [Required]
        public string MedicationName { get; set; }

        //MedicationUse
        [Required]
        public string MedicationUse { get; set; }

        //Afbeelding URL
        public string MedicationUrl { get; set; }
    }
}
