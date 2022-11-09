﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityAPI.Model
{
    public class BloodPressure
    {
        //ID
        [Key]
        public int BloodPressureId { get; set; }

        //UserID
        public int Id { get; set; }
        [ForeignKey("Id")]
        public User UserId { get; set; }

        //Upper pressure
        [Required]
        public double SystolicPressure { get; set; }

        //Lower pressure
        [Required]
        public double DiastolicPressure { get; set; }

        //Time
        public DateTime BMeasurementDateTime { get; set; }

        //NotificationTime
        public DateTime BNotificationTime { get; set; }
    }
}
