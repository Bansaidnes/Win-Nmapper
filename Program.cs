using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Games
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Nmapper";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Nmapper!");
            Console.WriteLine("Please enter the first Vlan");
            int Vlan1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the last Vlan");
            int Vlan2 = Convert.ToInt32(Console.ReadLine()) + 1;
            Console.WriteLine("Include -sn flag? (y/n)");
            String sn = Console.ReadLine();
            String sn2;
            if (sn == "y")
            {
                sn2 = "-sn ";
            } else { sn2 = ""; }
            string nmap;
            string name;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = Vlan1; i < Vlan2; i++)
            {
                Console.WriteLine("Starting terminal...");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press any key to see current progress");
                Console.WriteLine("Current nmap is for Vlan: " + i);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                nmap = "nmap " +sn2+ "10.19."+i+".0/24";
                Console.WriteLine(nmap);
                Process proc = new System.Diagnostics.Process ();
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + nmap + " \"";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start ();
                name = "nmap: " + i;
                while (!proc.StandardOutput.EndOfStream) {
                Console.WriteLine (proc.StandardOutput.ReadLine ());
            }
                 Console.WriteLine();
            }
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("Nmap complete!");
                 Thread.Sleep(5000);
        }
    }
}
