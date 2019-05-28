using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Description {get;set;}
        public string RequiredSpecializations { get; set; }
        public string AssignedTechnicians { get; set; }
        public string PostulatedTechnicians { get; set; }
    }
}