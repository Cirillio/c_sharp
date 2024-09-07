using GuessTheNumber;
using System;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game NewGame = new();
            NewGame.StartGame();
            Console.WriteLine($"{NewGame.MinNumber} {NewGame.MaxNumber} {NewGame.GameDifficulty.DifficultyID}");


        }
    }
}