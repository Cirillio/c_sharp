using System;
using GuessTheNumber.Output;
using GuessTheNumber.Output.Interfaces;
using GuessTheNumber.Input;
using GuessTheNumber.Input.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.GameInterfaces;


namespace GuessTheNumber
{
    class GuessGame
    {
        static void Main(string[] args)
        {
            NewGame GuessTheNumber = new NewGame();
            GuessTheNumber.Setup();
            GuessTheNumber.Play();


        }
    }
}