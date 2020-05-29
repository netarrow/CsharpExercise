using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GradeBook.Models
{
    public class Grade
    {
        [DisplayName("Inserire voto numerico")]
        public double Rate { get; set; }
        public string Letter
        {
            get
            {
                if (Rate >= 90)
                    return "A";
                if (Rate >= 80 && Rate < 90)
                    return "B";
                if (Rate >= 70 && Rate < 80)
                    return "C";
                else
                    return "F";

            }
        }
        [DisplayName("Inserire una materia")]
        public string Subject { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}