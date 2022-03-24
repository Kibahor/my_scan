using Model;
using System;
namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Scan scan = new Scan("Test", "Description", "Auteur", "genre", "classification", "status", 2, 5, new DateTime(), "./", null);
            Console.WriteLine(scan.ScanToFile("./monscan.json"));
            Scan scan2 = Scan.FileToScan("./monscan.json");
            Console.WriteLine(scan2.Auteur + scan2.Classification + scan2.Description);
        }
    }
}
