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
        public ActionResult Index(int? id)
        {
            var student = new Student();
            student.Id = 1;
            if (student.Id == id)
            {
                student.Name = "Marco";
                student.Grade.Add(new Grade() { Letter = "A", Rate = 95, Subject = "Hystory" });
                student.Grade.Add(new Grade() { Letter = "B", Rate = 80, Subject = "Math" });
                ViewBag.IsError = false;
            }
            else
            {
                ViewBag.Message = "Nessuno studente trovato per questo id";
                ViewBag.IsError = true;
            }
            
            
            return View(student);

        }
    }
}