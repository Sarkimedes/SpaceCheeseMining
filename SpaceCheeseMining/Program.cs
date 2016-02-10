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
            bool playAgain = false;
            do
            {
                bool testMode = false;
                var testModeSuccess = false;
                do
                {
                    Console.Write("Would you like to play in test mode (Y/N)? ");
                    string rawInput = Console.ReadLine();
                    string trimmedInput = rawInput.Trim();
                    bool trueEntered = trimmedInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase);
                    bool falseEntered = trimmedInput.Equals("N", StringComparison.InvariantCultureIgnoreCase);
                    testModeSuccess = trueEntered || falseEntered;

                    if (testModeSuccess)
                    {
                        if (trueEntered)
                        {
                            testMode = true;
                        }

                        if (falseEntered)
                        {
                            testMode = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid value.");
                    }

                } while (!testModeSuccess);

                IDice dice = null;
                if (testMode)
                {
                    dice = new TestDice();
                }
                else
                {
                    dice = new Dice();
                }
                var game = new Game(dice);
                Console.WriteLine("How many people are playing?");
                var numberOfPlayers = 0;
                bool success;
                do
                {
                    Console.Write("Please enter a number between 1 and 4: ");
                    var input = Console.ReadLine();
                    success = int.TryParse(input, out numberOfPlayers) && (numberOfPlayers >= 1 && numberOfPlayers <= 4);
                } while (!success);
                for (int i = 0; i < numberOfPlayers; ++i)
                {
                    Console.Write($"Please enter a name for player {i + 1}: ");
                    var name = Console.ReadLine();
                    game.AddPlayer(name);
                }
                game.SetupGame();
                game.Play();

                bool playAgainSuccess = false;
                while (!playAgainSuccess)
                {
                    Console.Write("Would you like to play again?");
                    string rawInput = Console.ReadLine();
                    string trimmedInput = rawInput.Trim();
                    bool trueEntered = trimmedInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase);
                    bool falseEntered = trimmedInput.Equals("N", StringComparison.InvariantCultureIgnoreCase);
                    playAgainSuccess = trueEntered || falseEntered;

                    if (playAgainSuccess)
                    {
                        playAgain = trueEntered;
                    }
                    Console.WriteLine("Please enter a valid value.");
                }

            } while (playAgain);
            
        }
    }
}
