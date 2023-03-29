namespace GradesApp3
{
    public class StudentInMemory : StudentBase
    {
        private List<float> grades = new List<float>();

        public StudentInMemory(string name, string surname)
            : base(name, surname)
        {
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in this.grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
        protected override void SaveGradeToStorage(float grade)
        {
            grades.Add(grade);
        }
    }
}





