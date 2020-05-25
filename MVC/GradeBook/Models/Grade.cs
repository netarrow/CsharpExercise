using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradeBook.Models
{
    public class Grade
    {
        public double Rate { get; set; }
        public string Letter { get; set; }
        public string Subject { get; set; }
    }
}