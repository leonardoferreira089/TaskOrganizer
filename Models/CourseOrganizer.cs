using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSO_LF089.Models
{
    public class CourseOrganizer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} required")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public string Subjects { get; set; }
        [Display(Name = "Time")]
        public int CourseDuration { get; set; }
        [Required(ErrorMessage = "{0} required")]
        public string Status { get; set; }
        public string Localization { get; set; }
        [Display(Name = "Purchased")]
        public bool purchased { get; set; }
    }
}
