using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class FileRepository : IBookRepository
    {
        public string filename;
        public FileRepository(string filename)
        {
            this.filename = filename;
        }
        public void AddGrade(double grade)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {
                writer.WriteLine(grade);
            }
        }

        public List<double> GetGrades()
        {
            List<double> list = new List<double>();
            var readlines = File.ReadLines(filename);
            foreach (var line in readlines)
            {
                var linedouble = double.Parse(line);
                list.Add(linedouble);
            }
                return list;
        }
    }
}
