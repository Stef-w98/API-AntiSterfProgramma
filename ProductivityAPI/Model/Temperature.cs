﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityAPI.Model
{
    public class Temperature
    {
        //ID
        [Key]
        public int TemperatureId { get; set; }

        //UserID
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }


        //Temp
        [Required]
        public double TemperatureParameter { get; set; }

        //Time
        public DateTime TMeasurementDateTime { get; set; }

        //NotificationTime
        public DateTime? TNotificationTime { get; set; }
    }
}
