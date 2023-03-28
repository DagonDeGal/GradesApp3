using static GradesApp3.StudentBase;

namespace GradesApp3
{
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }
        void AddGrade(float grade);
        void AddGrade(string grade);
        void AddGrade(int grade);

        public event GradeAddedDelegate GradeAdded;
        Statistics GetStatistics();
    }
}

