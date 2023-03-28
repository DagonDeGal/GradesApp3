namespace GradesApp3
{
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public event GradeAddedDelegate GradeAdded;
        public StudentBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        protected abstract void SaveGradeToStorage(float grade);
        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6)
            {
                SaveGradeToStorage(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid grade value");
            }
        }
        public void AddGrade(string gradeStr)
        {
            int grade = 0;

            if (IsUserInputPercentValue(gradeStr, ref grade))
            {
                ConvertPercentsToGradeAndAdd(grade);
            }
            else if (int.TryParse(gradeStr, out grade))
            {
                AddGrade(grade);
            }
            else
            {
                throw new Exception("Invalid grade value");
            }
        }
        private bool IsUserInputPercentValue(string gradeStr, ref int grade) =>
            gradeStr.EndsWith("%") && int.TryParse(gradeStr.TrimEnd('%'), out grade) 
            && grade >= 0 && grade <= 100;
        private void ConvertPercentsToGradeAndAdd(int grade)
        {
            switch (grade)
            {
                case var switchedGrade when switchedGrade < 30:
                    AddGrade(1);
                    break;
                case var switchedGrade when switchedGrade < 50:
                    AddGrade(2);
                    break;
                case var switchedGrade when switchedGrade < 70:
                    AddGrade(3);
                    break;
                case var switchedGrade when switchedGrade < 80:
                    AddGrade(4);
                    break;
                case var switchedGrade when switchedGrade < 90:
                    AddGrade(5);
                    break;
                default:
                    AddGrade(6);
                    break;
            }
        }
        public void AddGrade(int grade) => AddGrade((float)grade);
        public abstract Statistics GetStatistics();
    }
}

