using System;
using System.Diagnostics;
using System.IO;

// 
// Why there is no new cmd window?
//
namespace MultipleConsoles
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process p = Process.Start(psi);
            StreamWriter sw = p.StandardInput;
            StreamReader sr = p.StandardOutput;
            sw.WriteLine("Hello world @new_console");
            Console.WriteLine("Hello world @native_console");
            Console.ReadKey();
        }
    }
}