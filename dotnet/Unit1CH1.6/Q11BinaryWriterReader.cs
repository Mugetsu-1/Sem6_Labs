#if false
using System;
using System.IO;

namespace Unit1CH1._6
{
    internal class BinaryWriterReaderDemo
    {
        /*
        static void Main(string[] args)
        {
            string filePath = "binarydata.dat";

            // Write using BinaryWriter
            Console.WriteLine("Writing binary data using BinaryWriter...");
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(42);                   // int
                writer.Write(3.14159);              // double
                writer.Write(true);                 // bool
                writer.Write("Hello Binary!");      // string
                writer.Write(255);                  // byte (as int)
            }
            Console.WriteLine("Binary data written successfully.");

            // Read using BinaryReader
            Console.WriteLine("\nReading binary data using BinaryReader...");
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                int intVal = reader.ReadInt32();
                double doubleVal = reader.ReadDouble();
                bool boolVal = reader.ReadBoolean();
                string stringVal = reader.ReadString();
                int byteVal = reader.ReadInt32();

                Console.WriteLine($"  int: {intVal}");
                Console.WriteLine($"  double: {doubleVal}");
                Console.WriteLine($"  bool: {boolVal}");
                Console.WriteLine($"  string: {stringVal}");
                Console.WriteLine($"  extra int: {byteVal}");
            }

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

