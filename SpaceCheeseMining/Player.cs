using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class Player
    {
        public string Name { get; set; }
        public Square Position { get; set; }

        public void MoveLeft(int amount)
        {
            this.Position.X -= amount;
            if (this.Position.X < 0)
            {
                this.Position.X += 8;
            }
        }

        public void MoveRight(int amount)
        {
            this.Position.X += amount;
            if (this.Position.X > 7)
            {
                this.Position.X -= 8;
            }
        }

        public void MoveUp(int amount)
        {
            this.Position.Y -= amount;
            if (this.Position.Y < 0)
            {
                this.Position.Y += 8;
            }
        }


        public void MoveDown(int amount)
        {
            this.Position.Y += amount;
            if (this.Position.Y > 7)
            {
                this.Position.Y -= 8;
            }
        }
    }
}
