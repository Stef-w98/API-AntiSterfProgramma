using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityAPI.Model
{
    public class Saturation
    {
        //ID
        [Key]
        public int SaturationId { get; set; }

        //UserID
        public int Id { get; set; }
        [ForeignKey("Id")]
        public User UserId { get; set; }

        //Saturation
        public double SaturationO2 { get; set; }

        //Time
        public DateTime SMeasurementDateTime { get; set; }

        //NotificationTime
        public DateTime SNotificationTime { get; set; }
    }
}
