using GradeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradeBook.Repository
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private static List<Student> students;
        public InMemoryStudentRepository()
        {
            if (students == null)
            {
                students = new List<Student>();
                students.Add(CreateStudent("Marco", 1, new List<Grade>() { new Grade() { Rate = 90, Subject = "Math" } }));
                students.Add(CreateStudent("Mirco", 2, new List<Grade>() { new Grade() { Rate = 80, Subject = "Math" } }));
                students.Add(CreateStudent("Matteo", 3, new List<Grade>() { new Grade() { Rate = 85, Subject = "Math" } }));
                students.Add(CreateStudent("Giacomo", 4, new List<Grade>() { new Grade() { Rate = 76, Subject = "Math" } }));
                students.Add(CreateStudent("Lorenzo", 5, new List<Grade>() { new Grade() { Rate = 98, Subject = "Math" } }));
            }

        }

        private Student CreateStudent(string name, int id, List<Grade> grades)
        {

            return new Student() { Name = name, Id = id, Grade = grades };
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentsLookUp = students.Select(item => new Student() { Name = item.Name, Id = item.Id, Grade = null }).ToList();
            return studentsLookUp;
        }

        public Student GetStudentById(int id)
        {
            Student studentFound = students.Where(item => item.Id == id).SingleOrDefault();
            return studentFound;
        }

        public void AddGradeToStudent(Grade grade)
        {
            var student = students.Where(item => item.Id == grade.StudentId).SingleOrDefault();
            student.Grade.Add(grade);
        }
    }
}