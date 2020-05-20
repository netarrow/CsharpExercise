using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class InMemoryRepository : IBookRepository
    {
        private List<double> grades;
        public InMemoryRepository()
        {
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }


        public List<double> GetGrades()
        {
            List<double> cloned = new List<double>(grades);
            return cloned;
        }
    }
}
