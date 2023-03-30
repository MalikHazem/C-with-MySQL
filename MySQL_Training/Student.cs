using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Training
{
    internal class Student
    {
        public string Name { get; set; }
        public int City { get; set; }
        public float GPA { get; set; }
        public bool IS_Graduate { get; set; }

        public Student(string name, int city, float gpa, bool is_graduate)
        {
            Name = name;
            City = city;
            GPA = gpa;
            IS_Graduate = is_graduate;
        }
    }
}
