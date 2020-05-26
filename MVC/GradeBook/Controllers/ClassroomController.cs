using GradeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace GradeBook.Controllers
{
    public class ClassroomController : Controller
    {
        // GET: Classroom
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Mario" });
            students.Add(new Student() { Name = "Giacomo" });
            students.Add(new Student() { Name = "Franco" });
            Classroom classroom = new Classroom();
            classroom.Students = students;
            return View(classroom);
        }
    }
}