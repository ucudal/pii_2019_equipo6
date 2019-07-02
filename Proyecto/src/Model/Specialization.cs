using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    //La clase Specialization nos va a permitir asignar un salario y con él calcular el presupuesto de cada proyecto.
    public class Specialization
    {
        public int ID { get; set; }
        public string Name {get; set;}

        public int Salary {get;set;}

        public IList<AssignmentSpecialization> AssignmentSpecializations { get; set; }

    }
}