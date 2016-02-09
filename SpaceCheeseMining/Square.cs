using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class Square
    {
        public Square(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool HasCheese { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }

        public override bool Equals(object obj)
        {
            var square = obj as Square;
            if (square == null)
            {
                return false;
            }
            return this.X == square.X && this.Y == square.Y;
        }
    }
}
