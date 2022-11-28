using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductivityAPI.Model
{
    public class Notification
    {
        //ID
        [Key]
        public int NotificationId { get; set; }

        //UserID
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

        //Title
        [Required]
        public string Title { get; set; }

        //Description
        [Required]
        public string Description { get; set; }

        //NotificationTime
        public DateTime NotificationTime { get; set; }
    }
}
