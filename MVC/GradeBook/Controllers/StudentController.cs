using GradeBook.Models;
using GradeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradeBook.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException("id");

            IStudentRepository studentRepository = new InMemoryStudentRepository();

            var student = studentRepository.GetStudentById(id.Value);

            if (student == null)
            {
                ModelState.AddModelError("invalid parameter", "Nessuno studente trovato per questo id");
            }
            
            return View(student);

        }

        public ActionResult AddGrade(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException("id");

            Grade grade = new Grade();
            grade.StudentId = id.Value;
            IStudentRepository studentRepository = new InMemoryStudentRepository();
            var student = studentRepository.GetStudentById(id.Value);
            grade.StudentName = student.Name;

            return View(grade);
        }
        [HttpPost]
        public ActionResult AddGrade(Grade grade)
        {
            IStudentRepository studentRepository = new InMemoryStudentRepository();
            studentRepository.AddGradeToStudent(grade);
            
            return RedirectToAction("Index", "Student", new {id = grade.StudentId });
        }

    }
}