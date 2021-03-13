using System;

namespace BatchUnzipper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert the full path to the directory containing the .zip files: ");
            string zipDir = Console.ReadLine().Trim();
            Console.Write("Insert the full path to the directory where you want to unzip your files: ");
            string unzippedDir = Console.ReadLine().Trim();

            Console.WriteLine($"zipDir: {zipDir}; unzippedDir: {unzippedDir}");
            Console.ReadLine();
        }
    }
}
