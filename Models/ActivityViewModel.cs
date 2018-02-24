using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace beltPlate.Models
{
    public class ActivityViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [MinLength(2, ErrorMessage = "Title must be at least two characters")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Time")]
        public DateTime timeOfActivity { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime dateOfActivity { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int duration { get; set; }

        [Required]
        [Display(Name = "Minutes/ Hours/ Days")]
        public string timeIncrement { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MinLength(1, ErrorMessage = "Description mustn't be blank")]
        public string description { get; set; }
    }
}