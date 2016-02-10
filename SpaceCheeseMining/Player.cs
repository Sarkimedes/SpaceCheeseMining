using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    public class Player
    {
        private const int WinningCheese = 2;
        private int _amountOfCheese;
        private int _totalMoves;
        public bool IsWinner
        {
            get { return this._amountOfCheese >= WinningCheese; }
        }

        public string Name { get; set; }
        public Square Position { get; set; }

        public Score Score
        {
            get { return new Score(this.Name, this._totalMoves); }
        }

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

        public void TakeTurn(IDice dice)
        {
            this._totalMoves++;
            int roll = dice.GetRoll();

            Console.WriteLine($"{this.Name} has thrown a {roll}! Which direction would you like to move in, {this.Name}?");
            var moveFunction = this.DetermineDirection();
            moveFunction(roll);
            Console.WriteLine($"\n{this.Name} moves to position {this.Position}.");
            if (this.Position.HasCheese)
            {
                this._amountOfCheese++;
                Console.WriteLine($"{this.Name} has picked up some cheese! {this.Name} now has {this._amountOfCheese} bits of cheese.");                
            }
        }

        private Action<int> DetermineDirection()
        {
            while (true)
            {
                Console.Write($"Press the arrow key for the direction you would like to move.");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        return MoveUp;
                    case ConsoleKey.DownArrow:
                        return MoveDown;
                    case ConsoleKey.LeftArrow:
                        return MoveLeft;
                    case ConsoleKey.RightArrow:
                        return MoveRight;
                    default:
                        Console.WriteLine("Please enter a valid direction.");
                        break;
                }
            }
        }
    }
}
