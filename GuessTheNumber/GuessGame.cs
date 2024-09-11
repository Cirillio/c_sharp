using GuessTheNumber;
using System;
using GuessTheNumber.Output;
using GuessTheNumber.Output.Interfaces;

namespace GuessTheNumber
{
    class GuessGame
    {
        static void Main(string[] args)
        {

            Game GuessTheNumber = new();

            GuessTheNumber.PlayGame();


        }
    }
}