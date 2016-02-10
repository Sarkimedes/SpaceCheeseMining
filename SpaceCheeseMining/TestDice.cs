using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class TestDice : IDice
    {
        public int GetRoll()
        {
            bool success;
            int roll;
            do
            {
                Console.Write("Enter the dice value: ");
                var input = Console.ReadLine();
                success = int.TryParse(input, out roll);
            } while (!success);
            return roll;
        }
    }
}
