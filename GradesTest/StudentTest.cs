using GradesApp3;

namespace GradesTest
{
    public class StudentTest
    {
        [Test]
        public void Test1()
        {
            // arrange
            var student = new StudentInMemory("Krzysiek", "Markowski");
            student.AddGrade(5.0f);
            student.AddGrade(6.0f);
            student.AddGrade(4.5f);
            student.AddGrade(3.5f);
            student.AddGrade(5.0f);

            // act
            var result = student.GetStatistics();

            // assert
            Assert.AreEqual(4.8, result.Average);
            Assert.AreEqual(6.0, result.Max);
            Assert.AreEqual(3.5, result.Min);
        }
    }
}


