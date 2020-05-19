using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Linq;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistic()
        {
            var countgrades = grades.Count();
            var sumgrades = grades.Sum();
            var media = sumgrades / countgrades;
            var max = grades.Max();
            var lowest = grades.Min();
            return new Statistics() { Average = media, Max = max, Lowest = lowest }; ;
        }

        private List<double> grades;
        public string Name { get; private set; }

    }
}