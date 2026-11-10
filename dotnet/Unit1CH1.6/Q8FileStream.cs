#if false
using System;
using System.IO;

namespace Unit1CH1._6
{
    internal class FileStreamDemo
    {
        /*
        static void Main(string[] args)
        {
            string filePath = "example.dat";

            // Write data using FileStream
            Console.WriteLine("Writing data to file using FileStream...");
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes("Hello, FileStream! This is a test.");
                fs.Write(data, 0, data.Length);
            }
            Console.WriteLine("Data written successfully.");

            // Read data using FileStream
            Console.WriteLine("\nReading data from file using FileStream...");
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[fs.Length];
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                string content = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Content: {content}");
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

