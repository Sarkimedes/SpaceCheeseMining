using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceCheeseMining
{
    class Game
    {
        private List<Player> _players;

        private readonly IDice _dice;

        public Game(IDice dice)
        {
            this._players = new List<Player>();
            this._dice = dice;
        }

        public void AddPlayer(string playerName)
        {
            this._players.Add(new Player()
            {
                Name = playerName
            });
        }

        public void SetupGame()
        {
            var playerCount = this._players.Count;
            if (playerCount >= 4)
            {
                this._players[3].Position = new Square(7, 7);                            
            }
            if (playerCount >= 3)
            {
                this._players[2].Position = new Square(0, 7);
            }
            if (playerCount >= 2)
            {
                this._players[1].Position = new Square(7, 0);
            }
            if (playerCount >= 1)
            {
                this._players[0].Position = new Square(0, 0);
            }
        }        

        public void Play()
        {
            bool hasWinner = false;
            Player winner = null;
            while (!hasWinner)
            {
                foreach (var player in this._players)
                {
                    player.TakeTurn(this._dice);
                    if (player.IsWinner)
                    {
                        Console.WriteLine($"{player.Name} has won the game! Congratulations, {player.Name}!");
                        hasWinner = true;
                        winner = player;
                        break;
                    }
                }
            }    

            Console.WriteLine("Sending score to the server.");
            var sender = new HighScoreSender();
            sender.SendHighScore(winner.Score);

            Console.WriteLine("Retrieving high scores from the server.");
            var receiver = new HighScoreGetter();
            var allHighScores = receiver.GetScores();
            Console.WriteLine("High scores:\nName\tMoves");
            for (int i = 0; i < 5 && i < allHighScores.Length; i++)
            {
                Console.WriteLine($"{allHighScores[i].PlayerName}\t{allHighScores[i].Moves}");
            }
        }


    }
}
