#if false
using System;
using System.IO;
using System.Text.Json;

namespace Unit1CH1._6
{
    // Serializable class
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public void Display()
        {
            Console.WriteLine($"  Name: {Name}");
            Console.WriteLine($"  Age: {Age}");
            Console.WriteLine($"  Email: {Email}");
        }
    }

    internal class SerializationDemo
    {
        /*
        static void Main(string[] args)
        {
            string filePath = "person.json";

            // Create an object
            Person originalPerson = new Person
            {
                Name = "Saugat Thapa",
                Age = 21,
                Email = "saugat@example.com"
            };

            Console.WriteLine("Serialization:");
            Console.WriteLine("Original person object:");
            originalPerson.Display();

            string jsonString = JsonSerializer.Serialize(originalPerson);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("\nObject serialized to JSON successfully.\n");

            Console.WriteLine("\nDeserialization:");
            string readJson = File.ReadAllText(filePath);
            Person deserializedPerson = JsonSerializer.Deserialize<Person>(readJson);

            Console.WriteLine("Deserialized person object:");
            deserializedPerson.Display();

            // Clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("\nTemporary file deleted.");
            }
        }
        */
    }
}

#endif

