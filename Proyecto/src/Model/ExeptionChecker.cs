using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class ExeptionChecker
    {
        virtual public void CheckHours(IList<Technician> t)
        {
            foreach(var item in t)
            {
                if(item.hours<0)
                {
                    throw new ArgumentOutOfRangeException("Hours", "Is negative"); 
                }

            }
        
        }
    }
}