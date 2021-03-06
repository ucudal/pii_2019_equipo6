using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
//Aqui aplicamos herencia, para reutilizar código de person hacemos que Technician sea un Person.
    public class Technician : Person
    {
        public float hours { get; set; }

        public float score { get; set; }

        [NotMapped]
        public List<float> lastScores {get;set;}
        public List<Assignment> Assignments { get; set; }
        public IList<AssignmentSpecialization> AssignmentSpecializations { get; set; }
    }
}