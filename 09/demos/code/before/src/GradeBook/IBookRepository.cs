using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public interface IBookRepository
    {
        void AddGrade(double grade);
        List<double> GetGrades();
    }

}
