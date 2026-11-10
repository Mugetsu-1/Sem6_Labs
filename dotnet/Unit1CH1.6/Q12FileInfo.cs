#if false
using System;
using System.IO;

namespace Unit1CH1._6
{
    internal class FileInfoDemo
    {
        /*
        static void Main(string[] args)
        {
            string filePath = "testfile.txt";

            // Create a FileInfo instance
            FileInfo fileInfo = new FileInfo(filePath);

            // Check if file exists, if not create it
            if (!fileInfo.Exists)
            {
                Console.WriteLine("Creating file using FileInfo...");
                using (StreamWriter writer = fileInfo.CreateText())
                {
                    writer.WriteLine("This file was created using FileInfo class.");
                    writer.WriteLine("FileInfo provides properties and methods for file operations.");
                }
                Console.WriteLine("File created successfully.\n");
            }

            // Refresh to get latest file info
            fileInfo.Refresh();

            // Display file properties
            Console.WriteLine($"  Name: {fileInfo.Name}");
            Console.WriteLine($"  Full Path: {fileInfo.FullName}");
            Console.WriteLine($"  Directory: {fileInfo.DirectoryName}");
            Console.WriteLine($"  Size: {fileInfo.Length} bytes");
            Console.WriteLine($"  Extension: {fileInfo.Extension}");
            Console.WriteLine($"  Created: {fileInfo.CreationTime}");
            Console.WriteLine($"  Last Modified: {fileInfo.LastWriteTime}");
            Console.WriteLine($"  Last Accessed: {fileInfo.LastAccessTime}");
            Console.WriteLine($"  Attributes: {fileInfo.Attributes}");
            Console.WriteLine($"  Exists: {fileInfo.Exists}");

            // Demonstrate copying
            string copyPath = "testfile_copy.txt";
            Console.WriteLine($"\nCopying file to {copyPath}...");
            fileInfo.CopyTo(copyPath, overwrite: true);
            Console.WriteLine("File copied successfully.");

            // Demonstrate deletion
            Console.WriteLine($"\nDeleting original file...");
            fileInfo.Delete();
            Console.WriteLine("Original file deleted.");

            // Delete copy too
            FileInfo copyInfo = new FileInfo(copyPath);
            if (copyInfo.Exists)
            {
                copyInfo.Delete();
                Console.WriteLine("Copy file also deleted.");
            }
        }
        */
    }
}

#endif

