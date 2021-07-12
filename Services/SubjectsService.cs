using CSO_LF089.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSO_LF089.Services
{
    public class SubjectsService
    {
        public static List<CourseOrganizer> GetSubjects()
        {
            var listSubjects = new List<CourseOrganizer>()
            {
                new CourseOrganizer(){ Subjects = "Asp.Net Core"},
                new CourseOrganizer(){ Subjects = "C# - Fundamentals"},
                new CourseOrganizer(){ Subjects = "SqlServer"},
                new CourseOrganizer(){ Subjects = "Front-end"},
                new CourseOrganizer(){ Subjects = "French"},
                new CourseOrganizer(){ Subjects = "Marketing"},
                new CourseOrganizer(){ Subjects = "Computer skills"},
                new CourseOrganizer(){ Subjects = "Dev-Skills"},

            };
            return listSubjects;
        }
        
    }
}
