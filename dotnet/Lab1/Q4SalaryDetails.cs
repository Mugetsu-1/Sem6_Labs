using System;

namespace EmployeeApp
{
    class SalaryInfo : EmployeeDetails
    {
        public double salary;

        public SalaryInfo(int id, string name, string gender, string address, string position, double sal)
            : base(id, name, gender, address, position) { salary = sal; }

        public void CalcTax()
        {
            double taxRate = salary <= 400000 ? 0.01 : salary <= 800000 ? 0.10 : 0.20;
            double tax = salary * taxRate;
            double finalSalary = salary - tax;
            Console.WriteLine($"Annual Salary: Rs. {salary}\nTax Rate: {taxRate * 100}%\nTax Amount: Rs. {tax}\nFinal Salary: Rs. {finalSalary}");
        }
    }
}