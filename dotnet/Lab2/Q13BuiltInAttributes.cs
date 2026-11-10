#if false
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BuiltInAttributesApp
{
    [Serializable]
    class Person
    {
        [Description("Person's full name")]
        public string Name { get; set; }
        [Description("Person's age")]
        public int Age { get; set; }
    }

    [Flags]
    enum Permissions { None = 0, Read = 1, Write = 2, Execute = 4 }

    class Program
    {
        [Obsolete("Use NewMethod instead")]
        static void OldMethod() => Console.WriteLine("Old method");
        static void NewMethod() => Console.WriteLine("New method");

        [Conditional("DEBUG")]
        static void DebugLog(string msg) => Console.WriteLine($"DEBUG: {msg}");

        /*
        static void Main(string[] args)
        {
            NewMethod();

            Console.WriteLine($"Person serializable? {typeof(Person).IsSerializable}");

            var props = typeof(Person).GetProperties();
            foreach (var p in props)
            {
                var desc = (DescriptionAttribute)Attribute.GetCustomAttribute(p, typeof(DescriptionAttribute));
                if (desc != null) Console.WriteLine($"{p.Name}: {desc.Description}");
            }

            Permissions p2 = Permissions.Read | Permissions.Write;
            Console.WriteLine($"Permissions: {p2}, Has Read? {p2.HasFlag(Permissions.Read)}");

            DebugLog("This only shows in DEBUG mode");
        }
        */
    }
}

#endif

