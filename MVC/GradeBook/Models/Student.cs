using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradeBook.Models
{
    public class Student
    {
        public string Name { get; set; }
        public List<Grade> Grade { get; set; }
        public Student()
        {
            Grade = new List<Grade>();
        }
    }
}