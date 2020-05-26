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

            StudentRepository studentRepository = new StudentRepository();

            var student = studentRepository.GetStudentById(id.Value);

            if (student == null)
            {
                ModelState.AddModelError("invalid parameter", "Nessuno studente trovato per questo id");
            }
            
            return View(student);

        }
    }
}