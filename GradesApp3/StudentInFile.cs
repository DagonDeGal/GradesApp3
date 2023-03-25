using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GradesApp3
{
    public class StudentInFile : StudentBase
    {
        private const string fileName = "student.txt";
        public override event GradeAddedDelegate GradeAdded;
        public StudentInFile(string name, string surname) : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 6)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
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


        public override void AddGrade(string gradeStr)
        {
            int grade = 0;
            var isValidPercentInt = gradeStr.EndsWith("%") && int.TryParse(gradeStr.TrimEnd('%'), out grade);
            if(isValidPercentInt && grade >= 0 && grade <= 100)
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
            var gradesFromFile = this.ReadGradesFromFile();
            var result = this.CountStatistics(gradesFromFile);
            return result;
        }

        private List<float> ReadGradesFromFile()
        {
            var grades = new List<float>();

            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        grades.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }
        private Statistics CountStatistics(List<float> grades)
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);

            }
            return statistics;
        }
    }
}

