using System;
using System.Linq;
using GradeBook.Repository.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Student = GradeBook.Repository.DataBase.Student;
using Grade = GradeBook.Repository.DataBase.Grade;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using AutoMapper;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LearningTestEntityFramework()
        {
            
            using (GradeBookDBEntities ctx = new GradeBookDBEntities())
            {
                var allStudent = ctx.Students;
                Assert.AreEqual(0, allStudent.Count());
                ctx.Students.Add(new Student() { Name = "Francesco" });
                ctx.SaveChanges();
                allStudent = ctx.Students;
                Assert.AreEqual(1, allStudent.Count());
            }
        }
        [TestMethod]
        public void LearningTest_Automapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, GradeBook.Models.Student>());
            var mapper = config.CreateMapper();
            Student student = new Student();
            student.Id = 1;
            student.Name = "William";
            student.Grades = new List<Grade>() { new Grade() { Rate = 70, Subject = "Math", StudentId = 1 } };

            GradeBook.Models.Student modelEntity = mapper.Map<GradeBook.Models.Student>(student);
            Assert.AreEqual("William", modelEntity.Name);
        }
    }
}
