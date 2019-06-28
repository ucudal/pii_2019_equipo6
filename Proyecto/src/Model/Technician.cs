using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using RazorPagesMovie.Areas.Identity.Data;

namespace RazorPagesMovie.Models
{
    public class Technician : ApplicationUser
    {
        //Conocer Especialización

        //Conocer Nivel (Experto/Básico)

        //Horas Trabajadas

        //Conocer Calificación
        public List<Assignment> Assignments { get; set; }
    }
}