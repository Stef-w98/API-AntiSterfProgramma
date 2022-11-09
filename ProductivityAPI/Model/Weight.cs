using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityAPI.Model
{
    public class Weight
    {
        //ID
        [Key]
        public int WeightId { get; set; }

        //UserID
        public int Id { get; set; }
        [ForeignKey("Id")]
        public User UserId { get; set; }

        //Kg
        [Required]
        public double WeightKg { get; set; }

        //Time
        public DateTime WMeasurementDateTime { get; set; }

        //NotificationTime
        public DateTime WNotificationTime { get; set; }

    }
}
