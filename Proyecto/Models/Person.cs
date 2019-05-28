using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name {get;set;}
        public string IdentificationNumber { get; set; }
        public string EMail { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}