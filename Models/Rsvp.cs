using System;
using System.ComponentModel.DataAnnotations;

namespace beltPlate.Models
{
    public class Rsvp
    {
        [Key]
        public int rsvpId { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
        public int activityId { get; set; }
        public Activity Activity { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}