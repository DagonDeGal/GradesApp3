using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesApp3
{
    public abstract class StudentBase : IStudent
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);
        public abstract event GradeAddedDelegate GradeAdded;
        public StudentBase(string name, string surname)
            
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get;set; }

        public string Surname { get; set; }

        public abstract void AddGrade(float grade);

        public abstract void AddGrade(string grade);
        
        public abstract void AddGrade(int grade);

            public abstract Statistics GetStatistics();

    }
}

