using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beltPlate.Models
{
    public class Activity
    {
        [Key]
        public int activityId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public DateTime dateOfActivity { get; set; }
        public DateTime timeOfActivity { get; set; }
        public int duration { get; set; }
        public List<Rsvp> rsvps { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Activity()
        {
            rsvps = new List<Rsvp>();
        }


    }

}