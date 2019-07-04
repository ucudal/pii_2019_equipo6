using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{

/* Creamos la clase Person para reutilizar código y que a partir de esta las clases sucesoras Technician y Client
tengan estos atributos que son comunes a ellas */
    public class Person
    {
        public int ID { get; set; }
    
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Name { get; set; }
            
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        [EmailAddress]
        public string Email {get; set;}




    }
}