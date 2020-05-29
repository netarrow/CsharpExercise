using System;
using System.Linq;
using GradeBook.Repository.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
