using GradesApp3;

namespace GradesTest
{

    public class TypeTests
    {
        [Test]
        public void GetStudentReturnsDifferentObjects()
        {
            var student1 = GetStudent("Krzysiek", "Markowski");
            var student2 = GetStudent("Antek", "Kobuz");

            Assert.AreNotSame(student1, student2);
            Assert.False(student1.Equals(student2));
            Assert.False(Object.ReferenceEquals(student1, student2));
        }

        [Test]
        public void TwoVarsCanReferenceSameObject()
        {
            var student1 = GetStudent("Krzysiek", "Markowski");
            var student2 = student1;

            Assert.AreSame(student1, student2);
            Assert.True(student1.Equals(student2));
            Assert.True(Object.ReferenceEquals(student1, student2));
        }

        private StudentInMemory GetStudent(string name, string surname)
        {
            return new StudentInMemory(name, surname);
        }
    }
}

        