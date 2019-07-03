using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class Technician : Person
    {
        //Conocer Especialización

        //Conocer Nivel (Experto/Básico)

        public float hours { get; set; }

        [RegularExpression(@"^[1-5]*$")]
        public float score { get; set; }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        public List<Assignment> Assignments { get; set; }
        public IList<AssignmentSpecialization> AssignmentSpecializations { get; set; }
    }
}