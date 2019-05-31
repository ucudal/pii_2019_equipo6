using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RazorPagesMovie.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the RazorPagesMovieUser class
    public class Technician : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
        [PersonalData]
        public string Specialization{get;set;}
        [PersonalData]
        public int Level{get;set;}
        [PersonalData]
        public int WorkedHours{get;set;}
        [PersonalData]
        public double Qualification{get;set;}
        [PersonalData]
        public string ActiveProjects{get;set;}
        [PersonalData]
        public string PastProjects{get;set;}

    }
}
