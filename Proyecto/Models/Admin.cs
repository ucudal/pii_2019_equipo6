using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Admin : Person
    {

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}