using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace GradeBook.Tests
{
    public class FileRepositoryTest : IDisposable
    {
        public void Dispose()
        {
            File.Delete("file.txt");
        }

        [Fact]
        public void TestAddGrade()
        {
            FileRepository file = new FileRepository("file.txt");
            file.AddGrade(5);
            string[] array = File.ReadAllLines("file.txt");
            Assert.Single(array);
        }
        [Fact]
        public void TestAddGrade_Append_MultipleGrade()
        {
            //Arrange
            FileRepository file = new FileRepository("file.txt");
            //Act
            file.AddGrade(5);
            file.AddGrade(10);
            file.AddGrade(15);
            //Assert
            string[] array = File.ReadAllLines("file.txt");
            Assert.Equal(3, array.Length);
        }
        [Fact]
        public void Test_GetGrades_AddGrades_ReturnListOfGrades()
        {
            //Arrange
            FileRepository file = new FileRepository("file.txt");
            file.AddGrade(20);
            file.AddGrade(25);
            file.AddGrade(30);
            //Act
            var result = file.GetGrades();
            //Assert
            Assert.Equal(20, result.First());
            Assert.Equal(25, result[1]);
            Assert.Equal(30, result.ElementAt(2));
        }

    }
}
