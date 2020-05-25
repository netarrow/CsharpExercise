using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book", new InMemoryRepository());
            book.GradeAdded += WriteToConsole;
            book.GradeAdded += SendEmail;
            book.GradeAdded -= SendEmail;
            book.GradeAdded += NotifyBadGrades;
            book.GoodStudentFound += CandidateForPrice;

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void WriteToConsole(object sender, double e)
        {
            Console.WriteLine($"A grade was added {e}");
        }
        static void SendEmail(object sender, double e)
        {
            Console.WriteLine($"Manda una Mail {e}");
        }

        static void NotifyBadGrades(object sender, double e)
        {
            if (e < 60)
                Console.WriteLine("Chiama i genitori");
        }

        static void CandidateForPrice( string name, double average)
        {
            Console.WriteLine($"The Student {name} has an average of {average}");
        }

    }
}
