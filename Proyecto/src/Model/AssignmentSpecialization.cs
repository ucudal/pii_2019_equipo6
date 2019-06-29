using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
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