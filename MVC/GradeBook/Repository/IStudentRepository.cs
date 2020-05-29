using GradeBook.Models;
using System.Collections.Generic;

namespace GradeBook.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddGradeToStudent(Grade grade);
    }
}