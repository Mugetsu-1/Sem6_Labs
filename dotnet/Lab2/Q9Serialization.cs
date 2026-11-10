#if false
using System;
using System.IO;
using System.Text.Json;

namespace SerializationApp
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            Employee emp = new Employee { Id = 101, Name = "Saugat", Department = "CSIT", Salary = 85000 };

            string json = JsonSerializer.Serialize(emp, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employee.json", json);
            Console.WriteLine($"Serialized JSON:\n{json}");

            string readJson = File.ReadAllText("employee.json");
            Employee deserialized = JsonSerializer.Deserialize<Employee>(readJson);
            Console.WriteLine($"Deserialized: {deserialized.Name}, {deserialized.Department}, ${deserialized.Salary}");

            File.Delete("employee.json");
        }
        */
    }
}

#endif

