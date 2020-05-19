using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {               

            var book = new Book("Scott's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            
            var stats = book.GetStatistic();
            Console.WriteLine($"La tua media è : {stats}");
            Console.ReadKey();
        }        
    }
}
