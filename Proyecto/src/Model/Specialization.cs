using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class Specialization
    {
        public int ID { get; set; }
        public string Name;
        public string Salary;

    }
}