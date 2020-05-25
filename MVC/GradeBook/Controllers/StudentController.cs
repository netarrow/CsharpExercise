using GradeBook.Models;
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
        public ActionResult Index()
        {
            var student = new Student();
            student.Name = "Marco";
            student.Grade.Add(new Grade() { Letter = "A", Rate = 95, Subject = "Hystory" });
            student.Grade.Add(new Grade() { Letter = "B", Rate = 80, Subject = "Math" });
            return View(student);

        }
    }
}