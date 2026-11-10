#if false
using System;
using System.Reflection;

namespace CustomAttributesApp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class DeveloperAttribute : Attribute
    {
        public string Name { get; }
        public DeveloperAttribute(string name) => Name = name;
    }

    [Developer("Saugat")]
    class Calculator
    {
        [Developer("Bob")]
        public void Add(int a, int b) => Console.WriteLine($"Sum: {a + b}");
    }

    class Program
    {
        /*
        static void Main(string[] args)
        {
            var classAttr = typeof(Calculator).GetCustomAttribute<DeveloperAttribute>();
            Console.WriteLine($"Class developed by: {classAttr?.Name}");

            var method = typeof(Calculator).GetMethod("Add");
            var methodAttr = method?.GetCustomAttribute<DeveloperAttribute>();
            Console.WriteLine($"Add method developed by: {methodAttr?.Name}");

            Console.WriteLine("\nAll attributes on Calculator:");
            foreach (var attr in typeof(Calculator).GetCustomAttributes(false))
                Console.WriteLine($"  {attr.GetType().Name}: {(attr as DeveloperAttribute)?.Name}");
        }
        */
    }
}

#endif

