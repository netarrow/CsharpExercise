using GradeBook.Models;
using GradeBook.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student = GradeBook.Models.Student;
using Grade = GradeBook.Models.Grade;

namespace GradeBook.Repository
{
    public class DatabaseStudentRepository : IStudentRepository
    {
        public void AddGradeToStudent(Grade grade)
        {
            using (GradeBookDBEntities ctx = new GradeBookDBEntities())
            {
                var efGrade = new DataBase.Grade { Rate = grade.Rate, Subject = grade.Subject, StudentId = grade.StudentId };
                ctx.Grades.Add(efGrade);
                ctx.SaveChanges();
            }
        }

        public List<Student> GetAllStudents()
        {
            using (GradeBookDBEntities ctx = new GradeBookDBEntities())
            {
                var efStudents = ctx.Students;
                return efStudents.ToList().Select(item => new Student { Id = item.Id, Name = item.Name, }).ToList();
            }

        }

        public Student GetStudentById(int id)
        {
            using (GradeBookDBEntities ctx = new GradeBookDBEntities())
            {

                var efStudent = ctx.Students.Where(item => item.Id == id).SingleOrDefault();
                if (efStudent == null)
                {
                    return null;
                }
                else
                {
                    return new Student
                    {
                        Id = efStudent.Id,
                        Name = efStudent.Name,
                        Grade = efStudent.Grades.Select(item =>
                                                    new Grade { StudentId = efStudent.Id, StudentName = efStudent.Name, Subject = item.Subject, Rate = item.Rate }).ToList()
                    };
                }

            }
        }
    }
}