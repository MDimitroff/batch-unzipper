using System;
using System.IO;
using System.IO.Compression;

namespace BatchUnzipper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Consonole app configuration
            Console.Write("Insert the full path to the directory containing the .zip files: ");
            string zipDir = Console.ReadLine().Trim();
            Console.Write("Insert the full path to the directory where you want to unzip your files: ");
            string unzippedDir = Console.ReadLine().Trim();
            Console.Write("Should I replace something in the file name? ");
            string toReplace = Console.ReadLine().Trim();
            string replacement = string.Empty;
            string fileExtension = string.Empty;
            if (!string.IsNullOrEmpty(toReplace))
            {
                Console.Write("Replace this ocurrence with? ");
                replacement = Console.ReadLine().Trim();
                Console.Write("What's the file extension? ");
                fileExtension = Console.ReadLine().Trim();
            }

            // Find all files
            var files = Directory.GetFiles(zipDir);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                if (fileInfo.Extension != ".zip")
                {
                    Console.WriteLine($"File {fileInfo.Name} is not a valid .zip file.");
                    continue;
                }

                ZipFile.ExtractToDirectory(fileInfo.FullName, unzippedDir, overwriteFiles: true);

                try
                {
                    string renamedFileFullPath = string.Empty;
                    if (!string.IsNullOrEmpty(toReplace))
                    {
                        var newFile = new FileInfo(Path.Combine(unzippedDir, fileInfo.Name.Replace(".zip", fileExtension)));
                        renamedFileFullPath = newFile.FullName.Replace(toReplace, replacement).Trim();
                        File.Move(newFile.FullName, $"{renamedFileFullPath}");
                    }
                }
                catch (Exception) 
                {
                    Console.WriteLine($"File {fileInfo.Name} wasn't renamed.");
                }
            }

            Console.WriteLine($"Operation Completed. Files extracted to directory {unzippedDir}");
            Console.ReadLine();
        }
    }
}
