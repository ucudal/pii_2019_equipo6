using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*Cumplimos con el principio de responsabilidad única ya que lo que tiene
que ver con el look & field no las puedo tocar desde el controlador */

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

        public IList<Assignment> Assignments { get; set; }
    }
}