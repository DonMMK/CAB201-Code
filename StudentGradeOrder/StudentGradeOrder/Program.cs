using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeOrder
{
    class Student : IComparable
    {
        // Implement the Student class here
        private string First;
        private string Last;
        private string Degree;
        private int Grade;

        public Student(string firstName, string lastName, string degree, int grade)
        {
            First = firstName;
            Last = lastName;
            Degree = degree;
            Grade = grade;
        }

        public override string ToString()
        {
            string somethingmeaningful = Last + ", " + First + " (" + Degree + ") Grade: " + Grade;
            return somethingmeaningful;

        }
        public int CompareTo(object obj)
        {
            return 0;
        }
   
                   
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student("Jane", "Bloggs", "Bachelor of IT", 7),
                new Student("John", "Bloggs", "Bachelor of IT", 7),  
                new Student("Jane", "Smith", "Bachelor of IT", 7),
                new Student("John", "Smith", "Bachelor of IT", 7),
                new Student("Jane", "Bloggs", "Bachelor of IT", 6),
                new Student("John", "Bloggs", "Bachelor of IT", 6),
                new Student("Jane", "Smith", "Bachelor of IT", 6),
                new Student("John", "Smith", "Bachelor of IT", 6),
                new Student("Jane", "Bloggs", "Bachelor of Engineering", 7),
                new Student("John", "Bloggs", "Bachelor of Engineering", 7),
                new Student("Jane", "Smith", "Bachelor of Engineering", 7),
                new Student("John", "Smith", "Bachelor of Engineering", 7),
                new Student("Jane", "Bloggs", "Bachelor of Engineering", 6),
                new Student("John", "Bloggs", "Bachelor of Engineering", 6),
                new Student("Jane", "Smith", "Bachelor of Engineering", 6),
                new Student("John", "Smith", "Bachelor of Engineering", 6),
                
                
                
                
                
                
                
            };

            Array.Sort(students);
            foreach (Student student in students)
            {
                Console.WriteLine("{0}", student);
            }

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }

}

