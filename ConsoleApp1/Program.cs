using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string directory = "C:/Users/rupakal/Documents/SF_module_8";
            while (true)
            {
                CleanDirectory(directory);
            }
        }
        static void CleanDirectory(string directory)
        {
            if (Directory.Exists(directory)) 
            {
                string[] files = Directory.GetFiles(directory);
                for (int i = 0; i < files.Length; i++) 
                {
                    if ((DateTime.Now - File.GetLastAccessTime(files[i])) >= TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            File.Delete(files[i]);
                            Console.WriteLine("File deleted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                string[] directories = Directory.GetDirectories(directory);
                for (int i = 0; i < directories.Length; i++)
                {
                    if ((DateTime.Now - Directory.GetLastAccessTime(directories[i])) >= TimeSpan.FromMinutes(30))
                    {
                        try
                        {
                            Directory.Delete(directories[i],true);
                            Console.WriteLine("Directory deleted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No folder fouded with the specific name {0}", directory);
                return;
            }
        }
    }

}
