using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class Assignment
    {
        [Key]
        public int TechnicianID { get; set; }

        [Key]
        public int ProjectID { get; set; }

        [Required]
        public Technician Technician { get; set; }

        [Required]
        public Project Project { get; set; }
    }
}