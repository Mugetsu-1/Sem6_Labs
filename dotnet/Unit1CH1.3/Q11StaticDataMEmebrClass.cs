#if false
using System;

namespace Unit1CH1._3
{
    class Employeee
    {
        // Static data members (shared across all objects)
        public static string companyName = "TechCorp";
        public static int totalEmployees = 0;
        public static double bonusPercentage = 0.10;

        // Instance data members
        public int empId;
        public string empName;
        public double salary;

        // Static constructor (called once when class is first accessed)
        static Employeee()
        {
            Console.WriteLine("Static constructor called");
            companyName = "TechCorp Solutions";
            totalEmployees = 0;
        }

        // Instance constructor
        public Employeee(int id, string name, double sal)
        {
            empId = id;
            empName = name;
            salary = sal;
            totalEmployees++; // Increment static counter
            Console.WriteLine("Employee " + empName + " created");
        }

        // Static method
        public static void DisplayCompanyInfo()
        {
            Console.WriteLine("Company: " + companyName);
            Console.WriteLine("Total Employees: " + totalEmployees);
            Console.WriteLine("Bonus Percentage: " + (bonusPercentage * 100) + "%");
        }

        // Static method to update bonus
        public static void UpdateBonus(double newBonus)
        {
            bonusPercentage = newBonus;
            Console.WriteLine("Bonus updated to: " + (bonusPercentage * 100) + "%");
        }

        // Instance method
        public void DisplayEmployeeeInfo()
        {
            Console.WriteLine("ID: " + empId + ", Name: " + empName + ", Salary: " + salary);
            double bonus = salary * bonusPercentage;
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine();
        }
    }

    internal class staticDataMemberClass
    {
        /*
        static void Main(string[] args)
        {
            // Access static members without creating object
            Console.WriteLine("Initial Company Info:");
            Employeee.DisplayCompanyInfo();
            Console.WriteLine();

            
            Employeee emp1 = new Employeee(101, "Johnny", 50000);
            Employeee emp2 = new Employeee(102, "Alice", 60000);
            Employeee emp3 = new Employeee(103, "Bobby", 55000);

            Console.WriteLine();

            
            Console.WriteLine("Employee Details:");
            emp1.DisplayEmployeeeInfo();
            emp2.DisplayEmployeeeInfo();
            emp3.DisplayEmployeeeInfo();

            // Modify static member
            Employeee.UpdateBonus(0.15);

            Console.WriteLine("Updated Company Info:");
            Employeee.DisplayCompanyInfo();

            Console.WriteLine();

            // Static members are shared - all objects see the change
            Console.WriteLine("Employee 1's updated bonus:");
            emp1.DisplayEmployeeeInfo();
        }
        */
    }
}

#endif

