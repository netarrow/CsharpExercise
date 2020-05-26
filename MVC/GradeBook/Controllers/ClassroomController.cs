using GradeBook.Models;
using GradeBook.Repository;
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
            StudentRepository studentRepository = new StudentRepository();

            Classroom classroom = new Classroom();
            classroom.Students = studentRepository.GetAllStudents();

            return View(classroom);
        }
    }
}