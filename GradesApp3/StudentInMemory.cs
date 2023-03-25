using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesApp3
{
    public class StudentInMemory : StudentBase
    { 
        private List<float> grades = new List<float>();
        public StudentInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(float grade) => grades.Add(grade);


        public override void AddGrade(string gradeStr)
        {
            int grade = 0;
            var isValidPercentInt = gradeStr.EndsWith("%") && int.TryParse(gradeStr.TrimEnd('%'), out grade);
            if (isValidPercentInt && grade >= 0 && grade <= 100)
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
            else
            {
                throw new Exception("Invalid grade percent value");
            }
        }

        public override void AddGrade(int grade) => AddGrade((float)grade);

        public override Statistics GetStatistics()
            {
                var statistics = new Statistics();

                foreach (var grade in this.grades)
                {
                    statistics.AddGrade(grade);
                }

                return statistics;
            }
    }
    }





