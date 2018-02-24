using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beltPlate.Models
{
    public class User
    {
        [Key]
        public int userId {get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<Rsvp> rsvps { get; set; }
        public string password { get; set; }
        public DateTime createdAt {get; set; }
        public DateTime updatedAt {get; set; }
        public User()
        {
            rsvps = new List<Rsvp>();
        }
    }

}