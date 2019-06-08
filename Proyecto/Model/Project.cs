using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Project
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]  
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(360, MinimumLength = 3)]
        [Required] 
        public string Description { get; set; }

        public string AssignedTechnicians { get; set; }

        public string PostulatedTechnicians { get; set; }

        public string RequiredSpecialization { get; set; }

        public string Creator {get;set;}
    }
}