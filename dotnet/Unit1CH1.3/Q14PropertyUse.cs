#if false
using System;

namespace Unit1CH1._3
{
    class Student
    {
        // Private fields
        private int studentId;
        private string studentName;
        private double studentMarks;
        private int studentAge;

        // 1. Auto-implemented property (simple get/set)
        public string Email { get; set; }

        // 2. Read-only property (only get)
        public string College 
        { 
            get { return "ACHS College"; } 
        }

        // 3. Write-only property (only set)
        private string password;
        public string Password 
        { 
            set { password = value; } 
        }

        // 4. Property with validation
        public int StudentId
        {
            get { return studentId; }
            set 
            { 
                if (value > 0)
                    studentId = value;
                else
                    Console.WriteLine("ID must be positive");
            }
        }

        // 5. Property with custom logic
        public string StudentName
        {
            get { return studentName; }
            set 
            { 
                if (!string.IsNullOrEmpty(value))
                    studentName = value;
                else
                    Console.WriteLine("Name cannot be empty");
            }
        }

        // 6. Property with calculation
        public double StudentMarks
        {
            get { return studentMarks; }
            set { studentMarks = value; }
        }

        public string Grade
        {
            get 
            {
                if (studentMarks >= 90)
                    return "A";
                else if (studentMarks >= 75)
                    return "B";
                else if (studentMarks >= 60)
                    return "C";
                else
                    return "F";
            }
        }

        // 7. Property with expression body (C# 6+)
        public int StudentAge
        {
            get => studentAge;
            set => studentAge = (value > 0 && value < 100) ? value : 18;
        }

        // 8. Property with private set
        public DateTime AdmissionDate { get; private set; }

        // Constructor
        public Student()
        {
            AdmissionDate = DateTime.Now;
            Email = "student@college.com";
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Student ID: " + StudentId);
            Console.WriteLine("Student Name: " + StudentName);
            Console.WriteLine("Student Age: " + StudentAge);
            Console.WriteLine("Student Marks: " + StudentMarks);
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("College: " + College);
            Console.WriteLine("Admission Date: " + AdmissionDate);
        }
    }

    internal class PropertyUse
    {
        /*
        static void Main(string[] args)
        {
            Student student = new Student();

            // Setting properties
            student.StudentId = 101;
            student.StudentName = "Saugat Thapa";
            student.StudentAge = 20;
            student.StudentMarks = 85.5;
            student.Email = "saugat.thapa@email.com";
            student.Password = "secure123";

            // Get property values
            Console.WriteLine("Student Information:");
            student.DisplayInfo();

            Console.WriteLine("\nTesting validation:");
            student.StudentId = -5;  // Will show error message
            student.StudentName = ""; // Will show error message

            Console.WriteLine("\nAfter invalid inputs:");
            student.DisplayInfo();

            Console.WriteLine("\nAuto-implemented property: " + student.Email);
            Console.WriteLine("Read-only property: " + student.College);
        }
        */
    }
}

#endif

