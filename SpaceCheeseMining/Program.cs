using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Space Cheese Mining!");
            Console.WriteLine("How many people are playing?");
            var numberOfPlayers = 0;
            bool success;
            do
            {
                Console.Write("Please enter a number between 1 and 4: ");
                var input = Console.ReadLine();
                success = int.TryParse(input, out numberOfPlayers) && (numberOfPlayers >= 0 && numberOfPlayers <= 4);
            } while (!success);

        }
    }
}
