using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, double args);
    public delegate void HeightGradeDelegate(string name, double average);
    public class Book
    {
        public Book(string name, IBookRepository repository = null)
        {
            Name = name;
            if (repository == null)
                repository = new InMemoryRepository();
            else
                this.repository = repository;
        }

        public string Name
        {
            get;
            set;
        }

        public const string CATEGORY = "Science";

        private IBookRepository repository;

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;

            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                repository.AddGrade(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, grade);
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;
        public event HeightGradeDelegate GoodStudentFound;
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            var grades = repository.GetGrades();

            for (var index = 0; index < grades.Count; index += 1)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    //GoodStudentFound?.Invoke(Name, result.Average);

                    if (GoodStudentFound != null)
                        GoodStudentFound(Name, result.Average);
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;



            }

            return result;
        }


    }
}