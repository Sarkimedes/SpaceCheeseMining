using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class Dice
    {
        public int GetRoll()
        {
            var random = new Random();
            return random.Next(1, 7);
        }
    }
}
