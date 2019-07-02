using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{

/*Esta Clase tendrá las asignaciones a Technician de las Specialization, Specialization y Technician tendrán
una lista de AssignmentSpecialization. Donde los tecnicos tendrán su especialización y con ella su salario. */ 
    public class AssignmentSpecialization
    {
        [Key]
        public int SpecializationID { get; set; }

        [Key]
        public int TechnicianID { get; set; }

        [Required]
        public Specialization Specialization { get; set; }

        [Required]
        public Technician Technician { get; set; }
    }
}