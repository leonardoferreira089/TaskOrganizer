using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSO_LF089.Models.ViewModels
{
    public class CourseGenreViewModel
    {
        public List<CourseOrganizer> Courses { get; set; }
        public SelectList Genres { get; set; } 
        public string CourseGenre { get; set; }
        public string SearchString { get; set; }

        public void AddNewCourseGenre(string courseGenre)
        {
            CourseGenre = courseGenre;
            courseGenre = "All";

        }
    }
}
