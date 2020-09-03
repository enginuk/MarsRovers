using System;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            var roverManager = new RoversManager();
            string input = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
            var output = roverManager.Execute(input);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
