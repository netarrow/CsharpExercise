using GradeBook.Models;
using GradeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            IStudentRepository studentRepository = new DatabaseStudentRepository();
            Classroom classroom = new Classroom();
            classroom.Students = studentRepository.GetAllStudents();
            return View(classroom);
        }
    }

}