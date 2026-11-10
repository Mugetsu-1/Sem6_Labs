using System;

namespace EmployeeApp
{
    class EmployeeDetails
    {
        public int empId;
        public string empName;
        public string empGender;
        public string empAddress;
        public string empPosition;

        public EmployeeDetails(int id, string name, string gender, string address, string position)
        {
            empId = id;
            empName = name;
            empGender = gender;
            empAddress = address;
            empPosition = position;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {empId}\nName: {empName}\nGender: {empGender}\nAddress: {empAddress}\nPosition: {empPosition}");
        }
    }
}